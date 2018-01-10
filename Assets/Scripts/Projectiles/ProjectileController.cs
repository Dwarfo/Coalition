using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

    public float projectileSpeed;
    public Rigidbody2D projectile;
    public GameObject explosion;
    public float destroingDelay;

    private Vector2 direction;
    private ProjectileNotificator projectileNotificator;
    

    void Awake () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        projectile.AddForce(player.transform.up * projectileSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, destroingDelay);
        projectileNotificator = gameObject.GetComponent<ProjectileNotificator>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        getDestroyed();
    }
	
	void Update () {
		
	}

    public void receiveDamage(float damage)
    {
       //I should have made 2 interfaces =(
    }

    private void OnDestroy()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        projectileNotificator.OnDestruction(new OnDestructionEventArgs(gameObject.transform));
        Destroy(gameObject);
    }

    public void getDestroyed()
    {
        Destroy(gameObject);
    }
}
