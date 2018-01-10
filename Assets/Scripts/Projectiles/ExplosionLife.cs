using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour {


    public DamageInfo projectileDmgInfo;

	// Use this for initialization
	void Awake () {
        DamageInfo expDmgInfo = gameObject.GetComponent<DamageInfo>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stopExplosion() {
        Destroy(gameObject);
    }
}
