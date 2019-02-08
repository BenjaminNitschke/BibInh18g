using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float shootingDelay;

    private float lastShootingTime;

    [SerializeField]
    private float speed;

    private float velocity;
    private float yPosition;

	void Start ()
    {
        yPosition = WorldHelper.Instance.GetWorldDimensions().yMin + transform.localScale.y / 2f + 0.1f;
    }

    private void UpdateMovement()
    {
        float leftSide = transform.position.x - transform.localScale.x / 2f;
        float rightSide = transform.position.x + transform.localScale.x / 2f;

        velocity = 0;
        if (Input.GetAxisRaw("Horizontal") < 0 && leftSide > WorldHelper.Instance.GetWorldDimensions().xMin)
        {
            velocity = -speed;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && rightSide < WorldHelper.Instance.GetWorldDimensions().xMax)
        {
            velocity = speed;
        }

        float newX = transform.position.x + velocity * Time.deltaTime;
        transform.position = new Vector3(newX, yPosition, 0);
    }

    private void UpdateShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float now = Time.time;
            if(now > lastShootingTime + shootingDelay)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                lastShootingTime = now;
            }
        }
    }
	
	void Update ()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
