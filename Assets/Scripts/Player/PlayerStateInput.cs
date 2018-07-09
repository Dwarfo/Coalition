using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInput : MonoBehaviour {

    public PlayerMovementControl pmc;
    public ShieldControlls shieldControl;
    public FireProjectile playerFiring;
    private bool mode;


    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackGroundObjects.instance.Pause();
        }
        if (Input.GetKeyDown("q"))
        {
            pmc.changeMode();
        }

        if (Input.GetKeyDown("e"))
        {
            shieldControl.SetShield();
            
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


}
