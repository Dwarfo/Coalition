using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour {

    public Rigidbody2D Player;
    public float topSpeed = 10f;
    public float rotSpeed = 10f;
    public bool mode = true;
    //Mode will be provided by PlayerState class
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * topSpeed, Input.GetAxisRaw("Vertical") * topSpeed);
        if(mode)
           modeFly(direction);
    }

    private void modeFly(Vector2 directon)
    {
        Player.velocity = Lerping(direction);
        Debug.Log(Player.velocity);
        Rotate(Player.transform, direction);
    }

    private Vector2 Lerping(Vector2 direction)
    {
        float x = Mathf.Lerp(Player.velocity.x, direction.x, Time.deltaTime * topSpeed);
        float y = Mathf.Lerp(Player.velocity.y, direction.y, Time.deltaTime * topSpeed);

        return new Vector2(x, y);
    }

    private void Rotate(Transform tr, Vector2 direction)
    {
        int xAngle = -(int)tr.rotation.x;
        int yAngle = -(int)tr.rotation.y;
        int angle = (int)tr.rotation.z;
   
        if (direction.x > 0) xAngle = 270;
        if (direction.x < 0) xAngle = 90;
        if (direction.y < 0) yAngle = 180;
        if (direction.y > 0)
        {
            if (direction.x > 0) yAngle = 360;
            else yAngle = 0;
        }

        if (direction.x == 0 && direction.y != 0)
            angle = yAngle;
        if (direction.y == 0 && direction.x != 0)
            angle = xAngle;

        if (direction.x != 0 && direction.y != 0)
        {
            angle = (xAngle + yAngle) / 2;
            //Debug.Log("Rotation x=" + xAngle.ToString() + " , y =" + yAngle.ToString());
            //Debug.Log("Direction x=" + direction.x.ToString() + " , y =" + direction.y.ToString());
        }
        
        if (direction != Vector2.zero)
            tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotSpeed);

    }
}
