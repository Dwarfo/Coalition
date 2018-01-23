using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControlls : MonoBehaviour, IHealthPoint
{

    public float shieldCap;
    public float regenRate;
    public GameObject shieldBar;
    public GameObject shield;
    public Transform backgroundTransform;
    public AudioClip shieldsUp;

    private AudioSource audioSource;
    private Animator shieldAnim;
    [SerializeField]
    private float currentShield;
    private int regenTime;
    private bool shieldActive;
    private Rigidbody2D player;
    private int colcounter = 0;
    private bool broken;



    // Use this for initialization
    void Start ()
    {
        broken = false;
        player = gameObject.GetComponent<Rigidbody2D>();
        currentShield = shieldCap;
        regenTime = 0;
        shieldActive = false;
        shieldAnim = shield.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        regenTime++;
        if (regenTime >= 20 && currentShield < shieldCap)
        {
            regenerateShield();
            regenTime = 0;
            if (broken && currentShield > shieldCap * 0.4f)
                broken = false;
        }

    }

    private void regenerateShield() {
        currentShield = Mathf.Clamp(currentShield + regenRate, 0, shieldCap);
        updateBar();
        
    }

    public void setShield()
    {
        if (!shieldActive)
        {
            shieldAnim.Play("ShieldAnim");
            gameObject.GetComponent<CircleCollider2D>().radius = 0.6f;
        }
        if (shieldActive || broken)
        {
            shieldAnim.Play("ShieldAnimOff");
            gameObject.GetComponent<CircleCollider2D>().radius = 0.4f;
        }

        if(!broken)
            shieldActive = !shieldActive;

        audioSource.PlayOneShot(shieldsUp);

    }

    public void receiveDamage(float damage)
    {
        currentShield = currentShield - damage ;
        if (currentShield < 0)
            getDestroyed();
        updateBar();
    }

    public void updateBar()
    {
        //Width of bars is 200
        float xVec = 200 * ((currentShield / shieldCap) - 1) + backgroundTransform.position.x;
        //Debug.Log(xVec.ToString());
        shieldBar.transform.position = new Vector3(xVec, shieldBar.transform.position.y, shieldBar.transform.position.z);
    }

    public void getDestroyed()
    {
        Debug.Log("Shield's out!");
        setShield();
        broken = true;

    }

    public bool getShieldStatus()
    {
        return shieldActive;
    }
    
}
