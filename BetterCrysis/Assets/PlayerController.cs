using UnityEngine;

public class PlayerController : MonoBehaviour
{
	void Update ()
	{
		if (MenuState.State.GetType() != typeof(NewGameState))
			return;
		transform.position += MoveSpeed * transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Rotate(0, RotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
		HandleState();
	}

	private void HandleState()
	{
		switch (State)
		{
		case PlayerAnimationStates.Running:
			if (Input.GetKey(KeyCode.Space))
			{
				Debug.Log("start jumping");
				lastHeight = GetHeight();
				GetComponent<Rigidbody>().AddForce(transform.up*200);
				State = PlayerAnimationStates.Jumping;
			}
			if (Input.GetMouseButton(0))
			{
				Debug.Log("start shooting");
				GetComponent<AudioSource>().Play();
				State = PlayerAnimationStates.Shooting;
			}
			break;
		case PlayerAnimationStates.Jumping:
			if (GetHeight() < lastHeight)
			{
				Debug.Log("height apex reached");
				State = PlayerAnimationStates.Falling;
			}
			lastHeight = GetHeight();
			break;
		case PlayerAnimationStates.Falling:
			// Reached ground again?
			if (GetHeight() <= 0.01f)
			{
				Debug.Log("reached ground");
				State = PlayerAnimationStates.Running;
			}
			//else
			//	Debug.Log("still falling");
			break;
		case PlayerAnimationStates.Shooting:
			// Actually fire bullets yo
			var newBullet = Instantiate(Bullet, transform.position + transform.forward * BulletOffset,
				Quaternion.identity);
			GameObject.Find("AmmunitionText").GetComponent<UpdateAmmunition>().CurrentAmmunition--;
			newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
			// Stop shooting when mouse is released
			if (!Input.GetMouseButton(0))
			{
				Debug.Log("stopped shooting");
				State = PlayerAnimationStates.Running;
			}
			break;
		}
	}

	private float GetHeight()
	{
		return GetComponent<Collider>().ClosestPoint(
			new Vector3(transform.position.x, 0, transform.position.z)).y;
	}

	public GameObject Bullet;
	public float BulletOffset = 0.7f;
	public float BulletForce =  500;
	private const float MoveSpeed = 5.0f;
	private const float RotateSpeed = 180f;
	public PlayerAnimationStates State;
	private float lastHeight;
}

public enum PlayerAnimationStates
{
	Running,
	Jumping,
	Falling,
	Shooting
}