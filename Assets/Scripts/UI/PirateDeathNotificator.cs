using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateDeathNotificator : MonoBehaviour {

    public virtual void OnDestruction(OnDeathEventArgs e)
    {
        EventHandler<OnDeathEventArgs> handler = pirateKilled;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public event EventHandler<OnDeathEventArgs> pirateKilled;
}

public class OnDeathEventArgs : EventArgs
{
    public OnDeathEventArgs()
    {
        
    }
    
}
