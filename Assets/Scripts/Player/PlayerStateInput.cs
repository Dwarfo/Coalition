using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInput : MonoBehaviour {

	private bool shieldActive;
    private bool mode;
    public PlayerMovementControl pmc;
    public ShieldControlls shieldControl;
    public IHealthPoint playerHealth;

	void Start () {
		
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
    }

    public bool getMode() {
        return mode;
    }

    public bool getShieldStatus()
    {
        return shieldActive;
    }
}
