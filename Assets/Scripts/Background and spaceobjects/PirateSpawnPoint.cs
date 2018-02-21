using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpawnPoint  {

    private Vector2 lowerLeft;
    private Vector2 higherRight;
    private Vector2 spawnPoint;


    public PirateSpawnPoint()
    {
        spawnPoint = new Vector2(2.5f, 2.5f);
        lowerLeft = new Vector2(spawnPoint.x - 10, spawnPoint.y - 10);
        higherRight = new Vector2(spawnPoint.x + 10, spawnPoint.y + 10);
    }

    public PirateSpawnPoint(int size, List<PirateSpawnPoint> SpawnPoints)
    {
        MakeSpawnPoint(size, SpawnPoints);
    }

    private void MakeSpawnPoint(int size, List<PirateSpawnPoint> SpawnPoints)
    {
        bool done = true;
        int numberOfTries = 0;

        do
        {
            int randomX = Random.Range(0, size);
            int randomY = Random.Range(0, size);

            spawnPoint = new Vector2(2.5f * randomX, 2.5f * randomY);

            done = true;

            foreach (PirateSpawnPoint pos in SpawnPoints)
            {
                if (IsWithin(spawnPoint.x, pos.lowerLeft.x, pos.higherRight.x) && IsWithin(spawnPoint.y, pos.lowerLeft.y, pos.higherRight.y))
                {
                    done = false;
                    break;
                }
            }

            numberOfTries++;
        }

        while (!done || (numberOfTries < 10));
        lowerLeft = new Vector2(spawnPoint.x - 10, spawnPoint.y - 10);
        higherRight = new Vector2(spawnPoint.x + 10, spawnPoint.y + 10);
    }

    public static bool IsWithin(float value, float minimum, float maximum)
    {
        return value >= minimum && value <= maximum;
    }

    public Vector2 getSpawnPoint()
    {
        return spawnPoint;
    }
}
