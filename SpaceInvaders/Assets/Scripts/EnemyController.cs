using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 size;

    [SerializeField]
    private int directionChangesToGoDown;

    private int directionChangesCounter;
    private float yLayer;

    [SerializeField]
    private float xVelocity;

    private float movingDistance;

    private Animator animator;
    private bool deleteYourself = false;
    private float deletionTime;
    private float animationTime = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start ()
    {
        startPosition = transform.position;
        size = transform.localScale;

        //transform.position = new Vector3(transform.position.x + size.x / 2f, transform.position.y, 0);
        //transform.position = new Vector3(-WorldHelper.Instance.GetWorldDimensions().xMax, transform.position.y, 0);
    }
	
	void Update ()
    {
        if (transform.position.x + size.x / 2f > startPosition.x + movingDistance || transform.position.x - size.x / 2f < startPosition.x - movingDistance)
        {
            xVelocity *= -1;
            directionChangesCounter++;
        }
        
        // Move down
        if(directionChangesCounter >= directionChangesToGoDown)
        {
            directionChangesCounter = 0;
            startPosition.y -= size.y;
        }

        transform.position = new Vector3(transform.position.x + xVelocity * Time.deltaTime, startPosition.y, 0);

        // Deletion process
        if (deleteYourself && Time.time > deletionTime + animationTime)
            Destroy(gameObject); 
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Destroy(other.gameObject);
            RemoveItself();
        }
    }

    private void RemoveItself()
    {
        deleteYourself = true;
        deletionTime = Time.time;
        animator.Play("Explosion");

        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.Enemies.Remove(this);
    }

    public float MovingDistance
    {
        get
        {
            return movingDistance;
        }

        set
        {
            movingDistance = value;
        }
    }
}
