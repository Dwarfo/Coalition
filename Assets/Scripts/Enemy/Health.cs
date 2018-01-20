using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealthPoint {

    public float maxHealth = 30f;
    public int armor = 1;
    public GameObject explosion;

    [SerializeField]
    private float currentHeath;
 


    void Start()
    {
        currentHeath = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void receiveDamage(float damage)
    {
        currentHeath = currentHeath - damage * (1f - 1f / armor);
        if (currentHeath < 0)
        {
            getDestroyed();
        }

       
    }

    public void getDestroyed()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Debug.Log("Pirate Is Down!");
        Destroy(gameObject);
    }
}
