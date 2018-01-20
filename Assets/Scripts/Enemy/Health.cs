using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealthPoint {

    public float maxHealth = 30f;
    public int armor = 1;

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
        Debug.Log("Pirate Is Down!");
    }
}
