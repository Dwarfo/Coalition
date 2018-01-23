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
    private IEnumerator coroutine;

    void Start ()
    {
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

    }

    public void run(Vector2 direction)
    {
        targetObject = gameObject.GetComponent<EnemyMovement>().getTarget();

        float distance = Vector2.Distance(gameObject.transform.position, targetObject.position);

        if (distance <= 3f)
        {
            enemy.AddForce(-1 * direction * 5, ForceMode2D.Impulse);
        }

        int random = Random.Range(0,100);

        if (random < 10 && shootCounter == 0)
        {
            enemyFire();
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

        /*if (random >= 58 && random <= 60 && rotCounter == 0 && !rotating)
        {
            coroutine = circle(random);
            StartCoroutine(coroutine);
        }*/

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
            enemyFire();
        }
    }

    private IEnumerator circle(int random)
    {
        if (random > 59)
            koef = -1;
        else
            koef = 1;

        transform.RotateAround(targetObject.position, transform.forward, koef * 1f);
        yield return new WaitForSeconds(2f);
    }

    private void enemyFire()
    {
        fireProjectile.Fire();
    }
}
