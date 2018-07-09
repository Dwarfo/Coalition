using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObjects : MonoBehaviour {

    public static BackGroundObjects instance;
    public GameObject healthBar;
    public GameObject gameOverText;
    public GameObject shieldBar;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateBar(float currentPos, float cap, Vector3 barStartPositiom, GameObject bar)
    {
        float xVec = 200 * ((currentPos / cap) - 1) + barStartPositiom.x;
        bar.transform.position = new Vector3(xVec, bar.transform.position.y, bar.transform.position.z);
    }

    public void gameOver()
    {
        gameOverText.SetActive(true);
    }
}
