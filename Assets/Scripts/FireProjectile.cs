using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public Transform firingPosition;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Fire()
    {
            GameObject firedProjectile = Instantiate(Projectile, firingPosition.position, firingPosition.rotation);
    }
}
