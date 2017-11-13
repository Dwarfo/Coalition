using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour {

    //Player that is going to be watched by camera
    public Transform player;
    //MakeBackgroud script provides sizes of map
    public MakeBackground mb;
    public float smoothTime = 0.2f;
    public float maxSmoothSpeed = 5f;
    private Vector3 velocity = Vector3.zero;
    private PlayerMovementControl PMC;
    private Vector3 newPosition;

    //Clamp values
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;


    void Start ()
    {
        computeClamps();
        PMC = player.gameObject.GetComponent<PlayerMovementControl>();
	}

    void computeClamps()
    {
        Camera thisCamera = gameObject.GetComponent<Camera>();
        //Getting Clamp values depending on camera Size and AspectRatio
        minX = thisCamera.orthographicSize * thisCamera.aspect;
        minY = thisCamera.orthographicSize;
        maxX = mb.width * 2.5f - minX;
        maxY = mb.heigth * 2.5f - minY;
    }
	
    void Update ()
    {
        //Vector3 newPosition = new Vector3(player.position.x,player.position.y, transform.position.z);
        //Computing and updating Camera position
        if(PMC.mode)
           newPosition = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
        else
           newPosition = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
        //Camera.main.ScreenToWorldPoint(Input.mousePosition) - tr.position
        transform.position = newPosition;
    }
}
