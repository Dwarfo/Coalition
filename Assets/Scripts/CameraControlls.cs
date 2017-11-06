using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour {

    public Transform player;
    public MakeBackground mb;
    public float smoothTime = 0.2f;
    public float maxSmoothSpeed;
    private Vector3 velocity = Vector3.zero;
    // Use this for initialization

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;


    void Start ()
    {
        minX = 10f;
        minY = 5f;
        maxX = (mb.width - 1)  * 2.5f - minX;
        maxY = (mb.heigth - 1) * 2.5f - minY;
	}

    /*void computeClamps()
    {

    }
	*/
	// Update is called once per frame
	void Update ()
    {
        //Vector3 newPosition = new Vector3(Mathf.Clamp(player.position.x,minX,maxX), Mathf.Clamp(player.position.y,minY,maxY), transform.position.z);

        Vector3 newPosition = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        transform.position = newPosition;
    }
}
