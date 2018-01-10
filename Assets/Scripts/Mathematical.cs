using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathematical : MonoBehaviour {

    public static Vector2 clampVelocity(int modeKoef, Rigidbody2D character, float topSpeed)
    {
        // clamp between topSpeed negative and positive values depending on mode
        float x = Mathf.Clamp(character.velocity.x, -topSpeed / modeKoef, topSpeed / modeKoef);
        float y = Mathf.Clamp(character.velocity.y, -topSpeed / modeKoef, topSpeed / modeKoef);

        return new Vector2(x, y);
    }

}
