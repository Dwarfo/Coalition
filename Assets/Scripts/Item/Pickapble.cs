using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickapble : MonoBehaviour {

    public string PickableType = "default";
    private Action pickableAction; 
	
	void Start ()
    {
        switch (PickableType)
        {
            case "repair":
                pickableAction = new ActionRepair();
                break;
            case "default":
                pickableAction = new Action();
                break;
        }
        //pickableAction = new ActionRepair();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            pickableAction.perform(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
