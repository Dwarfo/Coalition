using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnFire : MonoBehaviour {

    public AudioClip[] shooting;
    private AudioSource audioSource;
    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        int random = Random.Range(0, 4);
        audioSource.PlayOneShot(shooting[random]);
    }
}
