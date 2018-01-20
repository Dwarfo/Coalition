using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBehavior : MonoBehaviour, IEnemyBehavior {

    public Rigidbody2D enemy;
    public FireProjectile fireProjectile;

    private int shootCounter;
    private int dashCounter;
    private int rotCounter;
    private int koef;
    private Transform targetObject;
    [SerializeField]
    private bool rotating;
    private IEnumerator coroutine;

    void Start ()
    {
        rotating = false;
        shootCounter = 0;
        dashCounter = 0;
        rotCounter = 0;
        enemy = gameObject.GetComponent<Rigidbody2D>();
        if (fireProjectile == null)
            fireProjectile = gameObject.GetComponent<FireProjectile>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rotating)
            rotate(koef);
    }

    public void run()
    {
        targetObject = gameObject.GetComponent<EnemyMovement>().getTarget();
        int random = Random.Range(0,100);

        if (random < 10 && shootCounter == 0)
        {
            fireProjectile.Fire();
            shootCounter++;
        }

        if (random > 90 && dashCounter == 0)
        {
            if (random > 95)
                enemy.AddForce(transform.right * 40, ForceMode2D.Impulse);
            else
                enemy.AddForce(-transform.right * 40, ForceMode2D.Impulse);
            dashCounter++;
            coroutine = dashStrike();
            StartCoroutine(coroutine);
        }

        if (random >= 58 && random <= 60 && rotCounter == 0 && !rotating)
        {
            if (random > 59)
                koef = -1;
            else
                koef = 1;
            rotating = true;
            Invoke("changeRot",2);
            rotCounter++;
                
        }

        iterateCounter(ref shootCounter, Random.Range(60, 180), true);
        iterateCounter(ref dashCounter, 180, true);
        iterateCounter(ref rotCounter, 360, true);

    }

    public void stop()
    {
        throw new System.NotImplementedException();
    }

    private void iterateCounter(ref int counter, int cap, bool iterate)
    {
        if (counter != 0 && iterate)
        {
            counter++;
            if (counter >= cap)
                counter = 0;
        }
    }

    private void changeRot()
    {
        this.rotating = false;
    }

    private void rotate(int koef)
    {
        transform.RotateAround(targetObject.position, transform.forward, koef*1f);
    }

    private IEnumerator dashStrike()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            fireProjectile.Fire();
        }
    }
}
