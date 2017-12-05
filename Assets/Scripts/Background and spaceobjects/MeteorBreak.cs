using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBreak : MonoBehaviour, IHealthPoint
{

    public float meteorHealth = 10;
    public GameObject SmallerMeteor = null;
    public float hardness = 5f;
    private int colcounter = 0;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void receiveDamage(float damage)
    {
        this.meteorHealth -= damage;
        if (this.meteorHealth <= 0)
            getDestroyed();
    }

    public void getDestroyed()
    {
        string BiggerMeteor = gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(0,2);
        //Debug.Log(BiggerMeteor);
        
        if (SmallerMeteor != null)
        {
            GameObject[] partMeteor = { Instantiate(SmallerMeteor, gameObject.transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(0, 180))),
                Instantiate(SmallerMeteor, gameObject.transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(0, 180))) };
            Rigidbody2D pM1 = partMeteor[0].GetComponent<Rigidbody2D>();
            pM1.AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
            Rigidbody2D pM2 = partMeteor[0].GetComponent<Rigidbody2D>();
            pM2.AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));

            for (int i = 0; i < partMeteor.Length; i++)
            {
                int meteor = Random.Range(1, 2);
                partMeteor[i].GetComponent<SpriteRenderer>().sprite = Resources.Load(BiggerMeteor + "S" + meteor.ToString(), typeof(Sprite)) as Sprite;
            }
        }
      
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9)
        {
            DamageInfo dmgInfo = collision.gameObject.GetComponent<DamageInfo>();
            float objVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            float damage = dmgInfo.damage;
            if (!dmgInfo.isProjectile)
            {
                objVelocity /= hardness;
                damage *= objVelocity;
            }
            receiveDamage(damage);
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
}