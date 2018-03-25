using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickapble : MonoBehaviour {

    private Action pickableAction; 
	
	void Start ()
    {
        pickableAction = new ActionRepair();
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
