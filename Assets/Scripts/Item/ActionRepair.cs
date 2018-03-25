using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRepair : Action {

    public override void perform(GameObject picker)
    {
        PlayerHealth ph = picker.GetComponent<PlayerHealth>();
        ph.receiveDamage(-20);
    }
}
