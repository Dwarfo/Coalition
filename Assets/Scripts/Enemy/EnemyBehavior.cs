using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {

    public float aggroRadius = 10f;
    public int speedKoef = 2;
    public float topSpeed = 8f;
    public int dragValue = 8;

    [SerializeField]
    private Transform targetObject;
    private Rigidbody2D enemy;
    private Vector2 direction;

    void Start ()
    {
        //Rigidbody has to have huge angular drag in order to face target properly
        //if not the rotation applied to object sums up with rotation provided by script
        gameObject.GetComponent<Rigidbody2D>().angularDrag = 10;
        enemy = gameObject.GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
        if (targetObject != null)
        {
            enemy.drag = 0;
            direction = (targetObject.position - transform.position).normalized;
            lookAtTarget();
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

    private void lookAtTarget()
    {
        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(rotation_z, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }

    private void chaseTarget()
    {
        float distance = Vector2.Distance(gameObject.transform.position, targetObject.position);
        float koef;
        if (distance >= 4f)
        {
            koef = topSpeed;
        }
        else
        {
            koef = -topSpeed;
        }
        enemy.AddForce(direction * koef);
        enemy.velocity = clampVelocity(speedKoef);
    }

    private Vector2 clampVelocity(int modeKoef)
    {
        // clamp between topSpeed negative and positive values depending on mode
        float x = Mathf.Clamp(enemy.velocity.x, -topSpeed / modeKoef, topSpeed / modeKoef);
        float y = Mathf.Clamp(enemy.velocity.y, -topSpeed / modeKoef, topSpeed / modeKoef);

        return new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I see ");
        Transform target = collision.GetComponent<Transform>();
        if (collision.gameObject.layer == 8)
        {
            //Debug.Log("I see Player");
            targetObject = target;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform target = collision.GetComponent<Transform>();
        if (collision.gameObject.layer == 8)
        {
            targetObject = null;
        }
    }

}
