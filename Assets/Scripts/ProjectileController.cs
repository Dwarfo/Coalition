using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

    public float projectileSpeed;
    public Rigidbody2D projectile;
    public GameObject explosion;
    public float destroingDelay;
    private Vector2 direction;
    

    void Awake () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        projectile.AddForce(player.transform.up * projectileSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, destroingDelay);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        getDestroyed(collision);
    }
	
	void Update () {
		
	}

    public void receiveDamage(float damage)
    {
       //I should have made 2 interfaces =(
    }

    public void getDestroyed(Collision2D collision)
    {
        //if(collision)
        GameObject expl = Instantiate(explosion, transform.position,transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}
