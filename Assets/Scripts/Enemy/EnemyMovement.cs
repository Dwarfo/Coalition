using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public float aggroRadius = 10f;
    public int speedKoef = 2;
    public float topSpeed = 8f;
    public int dragValue = 8;
    public float engageDistance = 8;
    //Question of the age! How to serialize interface ?
    //public IEnemyBehavior behavior;
    public PirateBehavior behavior;
    public AudioSource audioSource;
    public AudioClip running;

    [SerializeField]
    private Transform targetObject;
    private Rigidbody2D enemy;
    private Vector2 direction;

    void Start()
    {
        //Rigidbody has to have huge angular drag in order to face target properly
        //if not the rotation applied to object sums up with rotation provided by script
        gameObject.GetComponent<Rigidbody2D>().angularDrag = 10;
        CircleCollider2D[] colliders = gameObject.transform.GetComponents<CircleCollider2D>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
        foreach (CircleCollider2D collider in colliders)
        {
            if (collider.isTrigger)
            {
                collider.radius = aggroRadius;
            }
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if (targetObject != null)
        {
            enemy.drag = 0;
            direction = (targetObject.position - transform.position).normalized;
            Mathematical.RotateTowards(transform, targetObject.position, 90);
            chaseTarget();
        }
        else
            enemy.drag = dragValue;
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,aggroRadius);
    }

    private void chaseTarget()
    {
        float distance = Vector2.Distance(gameObject.transform.position, targetObject.position);
        float koef = 0;

        audioSource.volume = (1f - distance / aggroRadius);

        if (distance >= engageDistance)
        {
            koef = topSpeed;
        }
        else
        {
            // If enemy has engaged player, he starts using his stances
            enemy.drag = dragValue;
            behavior.run(direction, targetObject);
        }
        enemy.AddForce(direction * koef);
        enemy.velocity = Mathematical.clampVelocity(enemy, topSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I see ");
        Transform target = collision.GetComponent<Transform>();
        if (collision.gameObject.layer == 8)
        {
            //Debug.Log("I see Player");
            targetObject = target;
            //audioSource.Play();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform target = collision.GetComponent<Transform>();
        if (collision.gameObject.layer == 8)
        {
            targetObject = null;
            audioSource.Stop();
            audioSource.volume = 0.05f;
            //audioSource.PlayOneShot(running);
        }
        
    }

    public Transform getTarget()
    {
        return targetObject;
    }

}
