using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GenerateMenuScript : MonoBehaviour {

    public Button generateButton;
    public InputField worldSize;
	// Use this for initialization
	void Start ()
    {
        generateButton.onClick.AddListener(GenerateWorld);
    }

    private void GenerateWorld()
    {
        if (int.TryParse(worldSize.text, out Mathematical.worldSize))
        {
            SceneManager.LoadScene("Basic Scene");
        }
        else
        {
            worldSize.text = "Try numbers";
        }
    }
}
