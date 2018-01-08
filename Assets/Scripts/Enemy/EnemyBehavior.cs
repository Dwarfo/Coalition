using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {

    public float aggroRadius = 10f;
    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= aggroRadius)
        {
            lookAtPlayer();
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,aggroRadius);
    }

    private void lookAtPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        //Quaternion lookAt = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, Time.deltaTime * 5f);

        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, rotation_z), Time.deltaTime * 5f);
    }



}
