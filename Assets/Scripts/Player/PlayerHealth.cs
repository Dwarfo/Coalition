using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Make UI elements easily accesible
public class PlayerHealth : MonoBehaviour, IHealthPoint {

    public static float playerMaxHealth;
    
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHeath;
    public int armor = 5;
    public GameObject healthBar;
    public GameObject explosion;

    private ShieldControlls Shields;
    private int colcounter = 0;
    private Vector3 backgroundTransform;

    void Start ()
    {
        Shields = gameObject.GetComponent<ShieldControlls>();
        currentHeath = maxHealth;
        playerMaxHealth = maxHealth;



        backgroundTransform = healthBar.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}


    public void receiveDamage(float damage)
    {
        //TODO If Shieldz are up damage shield instead

        if (Shields.getShieldStatus())
        {
            Shields.receiveDamage(damage);
            return;
        }

        currentHeath = currentHeath - damage;
        if (currentHeath < 0)
        {
            getDestroyed();
        }
        if (currentHeath > maxHealth)
        {
            currentHeath = maxHealth;
        }

        BackGroundObjects.instance.updateBar(currentHeath, maxHealth, backgroundTransform, healthBar);
    }

    public void getDestroyed()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        BackGroundObjects.instance.gameOver();
        Destroy(gameObject);
    }

}
