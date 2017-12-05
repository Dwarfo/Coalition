using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public GameObject firingPosition;
    public PlayerMovementControl PMC;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}

    void Fire()
    {
        if (!PMC.mode)
        {
            GameObject firedProjectile = Instantiate(Projectile, firingPosition.transform.position, PMC.Player.transform.rotation);
        }
        //SpriteRenderer mRenderer = firedProjectile.GetComponent<SpriteRenderer>();
       // firedProjectile.transform.SetParent(firingPosition.transform, false);
    }
}
