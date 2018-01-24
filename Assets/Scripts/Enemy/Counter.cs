using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter {

    private int counter;
    private int cap;
    private bool countStatus;
    // Use this for initialization

    public Counter(int Cap)
    {
        this.cap = Cap;
        countStatus = true;
        counter = 0;
    }

    public void iterateCounter()
    {
        if (counter != 0)
        {
            counter++;
            if (counter >= cap)
            {
                counter = 0;
                countStatus = true;
            }
        }
    }

    public static Counter operator ++(Counter ctr)
    {
        ctr.counter++;
        ctr.countStatus = false;
        return ctr;
    }

    public void setCap(int newCap)
    {
        this.cap = newCap;
    }

    public bool getCountStatus()
    {
        return countStatus;
    }


}
