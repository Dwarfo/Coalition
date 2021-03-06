﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingMissiles : MonoBehaviour {

    public int speedKoef = 4;
    public float topSpeed = 10;
    public float reactionDistance = 3f;

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
            if (distance <= reactionDistance)
            {
                koef = -topSpeed * speedKoef;
            }
            else
            {
                koef = 0;
            }
            character.AddForce(direction * koef);
            character.velocity = Mathematical.clampVelocity(gameObject.GetComponent<Rigidbody2D>(),topSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I see ");
        
   
        if (collision.gameObject.layer == 11)
        {
            Transform target = collision.GetComponent<Transform>();
            dangers.Add(collision.transform);
            collision.GetComponent<ProjectileNotificator>().missileLeft += forgetMissile;
        }


    }

    public void forgetMissile(object sender, OnDestructionEventArgs e)
    {
        this.dangers.Remove(e.projectile);
        Debug.Log("Forgot about it");
    }


}
