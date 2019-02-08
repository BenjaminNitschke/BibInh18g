using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float yVelocity;

    private Rect dimension;

	void Start ()
    {
        dimension = WorldHelper.Instance.GetWorldDimensions();
	}
	
	void Update ()
    {
        transform.position += new Vector3(0, yVelocity * Time.deltaTime, 0);

        if (transform.position.y > dimension.yMax)
            Destroy(gameObject);
	}
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision" + collision.gameObject.tag);
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
