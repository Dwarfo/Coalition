using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject Projectile;
    public Transform firingPosition;
    public AudioClip[] shooting;

    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (firingPosition == null)
            firingPosition = gameObject.transform.Find("FirePosition");
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Fire()
    {
            GameObject firedProjectile = Instantiate(Projectile, firingPosition.position, firingPosition.rotation);
            int randomClip = Random.Range(0, 4);
            audioSource.PlayOneShot(shooting[randomClip]);
    }
}
