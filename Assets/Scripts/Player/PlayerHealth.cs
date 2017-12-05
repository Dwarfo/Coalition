using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IHealthPoint {

    /*For some reason position of Healthbar transform was counted using a position of
     * background , thus i needed to get it's coordinates
     */
    public Transform backgroundTransform;
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHeath;
    public int armor = 5;
    public GameObject healthBar;
    public PlayerMovementControl PMC;
    private int colcounter = 0;
	// Use this for initialization
	void Start ()
    {
        currentHeath = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();

            //float damage = 1f * PMC.Player.velocity.magnitude;
            if (!dmgInfo.isProjectile)
            {
                receiveDamage(dmgInfo.damage * PMC.Player.velocity.magnitude);
            }
            else
            {
                receiveDamage(dmgInfo.damage);
            }
            Debug.Log("Hit!" + dmgInfo.damage.ToString());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        colcounter++;
        if (colcounter == 10 && collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();

            receiveDamage(dmgInfo.damage);
            Debug.Log("Hit!" + dmgInfo.damage.ToString());
        }

    }

    public void receiveDamage(float damage)
    {
        currentHeath = currentHeath - damage * (1f - 1f / armor);
        float xVec = 200*((currentHeath / maxHealth) - 1) + backgroundTransform.position.x;
        Debug.Log(xVec.ToString());
        if (currentHeath < 0)
        {
            getDestroyed();
            PMC.enabled = false;
        }

        healthBar.transform.position = new Vector3(xVec, healthBar.transform.position.y, healthBar.transform.position.z);
    }

    public void getDestroyed()
    {
        Debug.Log("GAME OVER!");
    }
}
