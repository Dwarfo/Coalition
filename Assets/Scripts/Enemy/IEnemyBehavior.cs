using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBehavior  {

    void run(Vector2 direction, Transform targetObject);
    void stop();
}
