using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthPoint
{
    void receiveDamage(float damage);
    void getDestroyed();
}
