using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public PlayerStateInput psi;

    private Rigidbody2D player;
    private PlayerHealth playerHealth;
    private ShieldControlls playerShield;
    private int colcounter;

	// Use this for initialization
	void Start ()
    {
        colcounter = 0;
        player = gameObject.GetComponent<Rigidbody2D>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        playerShield = gameObject.GetComponent<ShieldControlls>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();
            float damage; 
            //float damage = 1f * PMC.Player.velocity.magnitude;
            if (!dmgInfo.isProjectile)
                damage = dmgInfo.damage * player.velocity.magnitude;
            else
                damage = dmgInfo.damage;

            if (playerShield.getShieldStatus())
                playerShield.receiveDamage(damage);
            else
                playerHealth.receiveDamage(damage);
            Debug.Log("Hit!" + dmgInfo.damage.ToString());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        colcounter++;
        if (colcounter == 10 && collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();

            float damage = dmgInfo.damage;
            if (playerShield.getShieldStatus())
                playerShield.receiveDamage(damage);
            else
                playerHealth.receiveDamage(damage);
            Debug.Log("Hit!" + dmgInfo.damage.ToString());
        }

    }



}
