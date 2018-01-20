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
    private int colcounter = 0;
	

	void Start ()
    {
        currentHeath = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void receiveDamage(float damage)
    {
        currentHeath = currentHeath - damage * (1f - 1f / armor);
        float xVec = 200*((currentHeath / maxHealth) - 1) + backgroundTransform.position.x;
        Debug.Log(xVec.ToString());
        if (currentHeath < 0)
        {
            getDestroyed();
        }

        healthBar.transform.position = new Vector3(xVec, healthBar.transform.position.y, healthBar.transform.position.z);
    }

    public void getDestroyed()
    {
        Debug.Log("GAME OVER!");
    }
}
