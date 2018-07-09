using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathematical : MonoBehaviour {

    public static int worldSize = 40;


    public static Vector2 clampVelocity( Rigidbody2D character, float topSpeed)
    {
        // clamp between topSpeed negative and positive values depending on mode
        float x = Mathf.Clamp(character.velocity.x, -topSpeed , topSpeed );
        float y = Mathf.Clamp(character.velocity.y, -topSpeed , topSpeed );

        return new Vector2(x, y);
    }

    public static void RotateTowards(Transform character, Vector3 direction, float adjustion)
    {
        Vector3 difference = direction - character.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + adjustion;
        character.rotation = Quaternion.Slerp(character.rotation, Quaternion.Euler(0f, 0f, rotation_z), Time.deltaTime * 5f);
    }

    public static void RotateTowards(Transform character, Vector3 direction)
    {
        RotateTowards(character, direction, 0);
    }

}
