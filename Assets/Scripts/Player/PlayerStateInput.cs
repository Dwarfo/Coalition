using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInput : MonoBehaviour {

    public PlayerMovementControl pmc;
    public ShieldControlls shieldControl;
    public FireProjectile playerFiring;
    public IHealthPoint playerHealth;
    
    private bool shieldActive;
    private bool mode;

    void Start ()
    {
       
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
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(!pmc.showMode())
            playerFiring.Fire();
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
