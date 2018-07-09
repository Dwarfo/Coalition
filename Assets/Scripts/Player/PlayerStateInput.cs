using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInput : MonoBehaviour {

    public PlayerMovementControl pmc;
    public ShieldControlls shieldControl;
    public FireProjectile playerFiring;
    public GameObject PauseMenu;
    public static bool GamePaused;

    private bool shieldActive;
    private bool mode;


    void Start ()
    {
        GamePaused = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
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

    public bool getShieldStatus()
    {
        return shieldActive;
    }

    private void Pause()
    {
        if (!GamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        GamePaused = !GamePaused;
        PauseMenu.SetActive(GamePaused);
    }
}
