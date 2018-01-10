using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingMissiles : MonoBehaviour {

    public int speedKoef = 4;
    public float topSpeed = 10;

    private List<Transform> dangers = new List<Transform>();
    [SerializeField]
    private Rigidbody2D character;



    // Use this for initialization
    void Start ()
    {
        character = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        dodge();
	}

    private void dodge()
    {
        float koef;
        foreach (Transform pos in dangers)
        {
            Vector3 direction = (pos.position - transform.position).normalized;
            float distance = Vector2.Distance(gameObject.transform.position, pos.position);
            if (distance <= 3f)
            {
                koef = -10 * 3;
            }
            else
            {
                koef = 0;
            }
            character.AddForce(direction * koef);
            character.velocity = Mathematical.clampVelocity(speedKoef / 4,gameObject.GetComponent<Rigidbody2D>(),topSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I see ");
        Transform target = collision.GetComponent<Transform>();
   
        if (collision.gameObject.layer == 11)
        {
            dangers.Add(collision.transform);
            ProjectileNotificator projectileNotificator = collision.GetComponent<ProjectileNotificator>();
            projectileNotificator.missileLeft += forgetMissile;
        }


    }

    public void forgetMissile(object sender, OnDestructionEventArgs e)
    {
        this.dangers.Remove(e.projectile);
        Debug.Log("Forgot about it");
    }


}
