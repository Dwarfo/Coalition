using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

    public Health health;
    private int colcounter = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();
            float damage;
            //float damage = 1f * PMC.Player.velocity.magnitude;
            if (!dmgInfo.isProjectile)
                damage = dmgInfo.damage * gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            else
                damage = dmgInfo.damage;

                health.receiveDamage(damage);
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
            health.receiveDamage(damage);
            Debug.Log("Hit!" + dmgInfo.damage.ToString());
        }

    }
}
