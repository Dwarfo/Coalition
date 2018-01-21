using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInput : MonoBehaviour {

    public PlayerMovementControl pmc;
    public ShieldControlls shieldControl;
    public FireProjectile playerFiring;
    public IHealthPoint playerHealth;
    public AudioClip[] shooting;
    public AudioClip shieldsUp;

    private bool shieldActive;
    private bool mode;
    private AudioSource audioSource;

    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("q"))
        {
            pmc.changeMode();
        }

        if (Input.GetKeyDown("e"))
        {
            shieldControl.setShield();
            audioSource.PlayOneShot(shieldsUp);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(!pmc.showMode())
            playerFiring.Fire();
            int randomClip = Random.Range(0, 4);
            audioSource.PlayOneShot(shooting[randomClip]);
        }
    }

    public bool getMode() {
        return mode;
    }

    public bool getShieldStatus()
    {
        return shieldActive;
    }
}
