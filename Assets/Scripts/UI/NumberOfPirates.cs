using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfPirates : MonoBehaviour {

    int numberOfPirates;
    private void Start()
    {
        numberOfPirates = Mathematical.worldSize / 20;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Pirates left: " + numberOfPirates;
    }

    public void show(object sender, OnDeathEventArgs e)
    {
        numberOfPirates--;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Pirates left: " + numberOfPirates;

    }
    
}
