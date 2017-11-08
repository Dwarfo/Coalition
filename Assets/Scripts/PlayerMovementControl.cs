using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour {

    public Rigidbody2D Player;
    public float topSpeed = 10f;
    public float Acceleration = 10f;
    public float rotSpeed = 10f;
    public bool mode = true;

    private int dragValue = 10;
    //Mode will be provided by PlayerState class
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * Acceleration, Input.GetAxisRaw("Vertical") * Acceleration);
    }

    private void FixedUpdate()
    {
        //Player.velocity = direction;
        if (mode)
            modeFly(direction);
    }

    private void modeFly(Vector2 direction)
    {
        //Depending on mode, topSpeed and direction addForce to move player
        Player.AddForce(direction);
        Player.velocity = clampVelocity();
        Debug.Log(Player.velocity);

        if (Player.velocity.x != 0 && direction.x == 0 && direction.y !=0)
            Player.velocity = new Vector2(Mathf.Lerp(Player.velocity.x, 0, 0.2f), Player.velocity.y);
        if (Player.velocity.y != 0 && direction.y == 0 && direction.x != 0)
            Player.velocity = new Vector2(Player.velocity.x, Mathf.Lerp(Player.velocity.y, 0, 0.2f));
            
        if (direction == Vector2.zero)
            Player.drag = dragValue;
        else
            Player.drag = 0;

        Rotate(Player.transform, direction);
    }

    private Vector2 clampVelocity()
    {
        // clamp between topSpeed negative and positive values
        float x = Mathf.Clamp(Player.velocity.x, -topSpeed, topSpeed);
        float y = Mathf.Clamp(Player.velocity.y, -topSpeed, topSpeed);

        return new Vector2(x, y);
    }

    private void Rotate(Transform tr, Vector2 direction)
    {
        int xAngle = -(int)tr.rotation.x;
        int yAngle = -(int)tr.rotation.y;
        int angle = (int)tr.rotation.z;

        //Depending on input compute "Z" Vector rotation value
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
        //Make sure you don't rotate when there is no input
        if (direction != Vector2.zero)
            tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotSpeed);

    }
}
