using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControlls : MonoBehaviour
{

    public float shieldCap;
    public float regenRate;
    public GameObject shieldBar;
    public GameObject shield;
    public AudioClip shieldsAudio;

    private AudioSource audioSource;
    private Animator shieldAnim;
    [SerializeField]
    private float currentShield;
    private bool shieldActive;
    private int colcounter = 0;
    private bool broken;
    private Vector3 shieldBarPosition;


    // Use this for initialization
    void Start ()
    {
        broken = false;
        shieldActive = false;
        currentShield = shieldCap;
        audioSource = gameObject.GetComponent<AudioSource>();
        if (shieldBar == null)
            shieldBar = BackGroundObjects.instance.shieldBar;

        shieldAnim = shield.GetComponent<Animator>();
        shieldBarPosition = shieldBar.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        RegenerateShield();
        if (broken && currentShield > shieldCap * 0.4f)
            broken = false;
    }

    private void RegenerateShield()
    {
        currentShield = Mathf.Clamp(currentShield + regenRate * Time.deltaTime, 0, shieldCap);
        BackGroundObjects.instance.updateBar(currentShield, shieldCap, shieldBarPosition, shieldBar);
    }

    public void SetShield()
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

        audioSource.PlayOneShot(shieldsAudio);

    }

    public void receiveDamage(float damage)
    {
        currentShield = currentShield - damage ;
        if (currentShield < 0)
            getDestroyed();
        BackGroundObjects.instance.updateBar(currentShield, shieldCap, shieldBarPosition, shieldBar);
    }
    /*
    public void updateBar()
    {
        float xVec = 200 * ((currentShield / shieldCap) - 1) + shieldBarPosition.x;
        shieldBar.transform.position = new Vector3(xVec, shieldBar.transform.position.y, shieldBar.transform.position.z);
    }*/

    public void getDestroyed()
    {
        Debug.Log("Shield's out!");
        SetShield();
        broken = true;

    }

    public bool getShieldStatus()
    {
        return shieldActive;
    }
    
}
