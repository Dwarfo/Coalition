using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public GameObject firingPosition;
    public PlayerStateInput psi;

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
        if (!psi.getMode())
        {
            GameObject firedProjectile = Instantiate(Projectile, firingPosition.transform.position, firingPosition.transform.rotation);
        }
        //SpriteRenderer mRenderer = firedProjectile.GetComponent<SpriteRenderer>();
       // firedProjectile.transform.SetParent(firingPosition.transform, false);
    }
}
