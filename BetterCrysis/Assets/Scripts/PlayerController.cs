using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider coll;

    private const float MoveSpeed = 5.0f;
    private const float RotateSpeed = 180f;

    private float previousY;
    private float crouchScale;
    private float normalScale;

    public PlayerAnimationStates state;
    public float jumpTime;

    void Start()
    {
        coll = GetComponent<Collider>();

        normalScale = transform.localScale.y;
        crouchScale = transform.localScale.y / 2f;
    }

    void Update ()
	{
		transform.position += MoveSpeed * transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Rotate(0, RotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        CheckState();        
	}

    private void CheckState()
    {
        float currentY = transform.position.y;
        float velocity = currentY - previousY;
        previousY = currentY;

        if (Input.GetKey(KeyCode.LeftShift))
            state = PlayerAnimationStates.Crouching;
        else
            state = PlayerAnimationStates.Running;

        switch (state)
        {
            case PlayerAnimationStates.Running:
                if(Input.GetKey(KeyCode.Space) && isGrounded())
                {
                    StartCoroutine(Jump());
                    state = PlayerAnimationStates.Jumping;
                }

                if (velocity < 0)
                    state = PlayerAnimationStates.Falling;
                break;

            case PlayerAnimationStates.Falling:
                if (isGrounded())
                    state = PlayerAnimationStates.Running;
                break;
                
            case PlayerAnimationStates.Jumping:
                if (velocity < 0)
                    state = PlayerAnimationStates.Falling;
                break;

            case PlayerAnimationStates.Crouching:
                transform.localScale = new Vector3(transform.localScale.x, crouchScale, transform.localScale.z);
                break;
        }

        if(state != PlayerAnimationStates.Crouching)
            transform.localScale = new Vector3(transform.localScale.x, normalScale, transform.localScale.z);

        Debug.Log(state);
    }

    private IEnumerator Jump()
    {
        float timePassed = 0;
        float progress = 0;

        float y = transform.position.y + 1;

        while(progress < 1f)
        {
            progress = timePassed / jumpTime;

            Vector3 position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, y, transform.position.z), progress);
            transform.position = position;

            timePassed += Time.deltaTime;

            yield return null;
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
    }
}