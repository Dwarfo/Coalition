using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBehavior : MonoBehaviour, IEnemyBehavior {

    public Rigidbody2D enemy;
    public FireProjectile fireProjectile;
    public int difficultySettings = 1;

    private int shootCounter;
    private int dashCounter;
    private int rotCounter;
    private int koef;
    private bool rotating;
    private IEnumerator coroutine;

    private Dictionary<string,Counter> counters;
    private Counter currentCounter;


    void Start ()
    {
        Mathf.Clamp(difficultySettings,1,4);
        shootCounter = 0;
        dashCounter = 0;
        rotCounter = 0;
        rotating = false;
        enemy = gameObject.GetComponent<Rigidbody2D>();
        if (fireProjectile == null)
            fireProjectile = gameObject.GetComponent<FireProjectile>();
        counters = new Dictionary<string, Counter>();
        counters.Add("shootCounter", new Counter(120 / difficultySettings));
        counters.Add("dashCounter", new Counter(180 / difficultySettings));
        counters.Add("rotCounter", new Counter(360 / difficultySettings));

    }

	void Update ()
    {

    }

    public void run(Vector2 direction, Transform targetObject)
    {

        float distance = Vector2.Distance(gameObject.transform.position, targetObject.position);

        if (distance <= 3f)
        {
            enemy.AddForce(-1 * direction * 5, ForceMode2D.Impulse);
        }

        int random = Random.Range(0,100);

        currentCounter = counters["shootCounter"];
        if (currentCounter.getCountStatus())
        {
            enemyFire();
            currentCounter.setCap(Random.Range(80/difficultySettings, 200/difficultySettings));
            currentCounter++;
        }

        currentCounter = counters["dashCounter"];

        if (currentCounter.getCountStatus())
        {
            if (random > 50)
                enemy.AddForce(transform.right * 40, ForceMode2D.Impulse);
            else
                enemy.AddForce(-transform.right * 40, ForceMode2D.Impulse);
            currentCounter.setCap(Random.Range(120 / difficultySettings, 300 / difficultySettings));
            currentCounter++;
            coroutine = dashStrike();
            StartCoroutine(coroutine);
        }

        currentCounter = counters["rotCounter"];

        if (currentCounter.getCountStatus())
        {
            coroutine = circle(random);
            StartCoroutine(coroutine);
            currentCounter.setCap(Random.Range(240 / difficultySettings, 500 / difficultySettings));
            currentCounter++;
        }

        if (rotating)
            rotate(koef, targetObject);

        iterateCounters();
    }

    public void stop()
    {
        throw new System.NotImplementedException();
    }

    private void iterateCounters()
    {
        foreach (KeyValuePair<string, Counter> ctr in counters)
        {
            ctr.Value.iterateCounter();
        }
    }

    private void rotate(int koef, Transform targetObject)
    {
        transform.RotateAround(targetObject.position, transform.forward, koef * (1 + difficultySettings/2));
    }

    private IEnumerator dashStrike()
    {
        for (int i = 0; i < 3 + difficultySettings/2; i++)
        {
            yield return new WaitForSeconds(0.1f);
            enemyFire();
        }
    }

    private IEnumerator circle(int random)
    {
        if (random > 50)
            koef = -1;
        else
            koef = 1;

        rotating = true;
        yield return new WaitForSeconds(3f);
        rotating = false;
    }

    private void enemyFire()
    {
        fireProjectile.Fire();
    }
}
