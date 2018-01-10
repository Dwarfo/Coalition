using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNotificator : MonoBehaviour {

    public virtual void OnDestruction(OnDestructionEventArgs e)
    {
        EventHandler<OnDestructionEventArgs> handler = missileLeft;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public event EventHandler<OnDestructionEventArgs> missileLeft;
}

public class OnDestructionEventArgs : EventArgs
{
    public OnDestructionEventArgs(Transform transform)
    {
        this.projectile = transform;
    }
    public Transform projectile { get; set; }
}
