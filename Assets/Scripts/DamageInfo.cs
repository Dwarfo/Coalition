using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo : MonoBehaviour {

    public float damage = 0;
    public float mass = 0;
    public bool isProjectile = false;

	// Use this for initialization
	void Start ()
    {
 	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float calculateDamage(GameObject owner)
    {
        if (!isProjectile)
        {
            Rigidbody2D ownerRigidbody = owner.GetComponent<Rigidbody2D>();
            damage = ownerRigidbody.velocity.magnitude * damage;
        }

        return damage;
    }

  
}
