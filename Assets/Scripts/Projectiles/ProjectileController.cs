using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour{

    public float projectileSpeed;
    public Rigidbody2D projectile;
    public GameObject explosion;
    public float destroingDelay;
    
    private ProjectileNotificator projectileNotificator;


    void Awake ()
    {
        Destroy(gameObject, destroingDelay);
        projectileNotificator = gameObject.GetComponent<ProjectileNotificator>();
	}
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
	
	void Update () {
		
	}

    private void OnDestroy()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        projectileNotificator.OnDestruction(new OnDestructionEventArgs(gameObject.transform));
    }

}
