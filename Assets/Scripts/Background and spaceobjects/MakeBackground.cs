﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBackground : MonoBehaviour {

    public NumberOfPirates pirateNumbers;
    public SpriteRenderer background = new SpriteRenderer();
    public SpriteRenderer objects = new SpriteRenderer();
    public int width;
    public int heigth;
    public GameObject BigMeteor;
    public GameObject Pirate;

    private List<PirateSpawnPoint> spawnPoints = new List<PirateSpawnPoint>();


    // Use this for initialization
    void Start ()
    {
        width = Mathematical.worldSize;
        heigth = Mathematical.worldSize;

        spawnPoints.Add(new PirateSpawnPoint());
        int k = 0;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                CreateBackgroundTile(i, j, k);
                PopulateWithObjects(i, j, k);
                k++;
            }
        }

        CreateBounds();
        SpawnPirates();

    }

    void CreateBounds()
    {
        //getting a gameObject that represents Bounds
        GameObject bounds = transform.Find("Bounds").gameObject;

        bounds.transform.position = new Vector2((width * 2.5f) / 2, (heigth * 2.5f) / 2);

        GameObject[] boundaries = new GameObject[4];
        BoxCollider2D[] bColliders = new BoxCollider2D[4];
        // 4 gameObject's, all having it's own colider, on each side of the map
        for (int i = 0; i < 4; i++)
        {
            boundaries[i] = new GameObject();
            boundaries[i].transform.SetParent(bounds.transform, false);
            boundaries[i].name = "Boundary" + i.ToString();

            bColliders[i] = boundaries[i].AddComponent<BoxCollider2D>();
            boundaries[i].layer = 9;
            //bColliders[i].usedByComposite = true;
        }

        //Placing bound gameObject's on the sides of the map
        boundaries[0].transform.position = new Vector2(0, (heigth * 2.5f) / 2);
        boundaries[1].transform.position = new Vector2((width * 2.5f) / 2, heigth * 2.5f);
        boundaries[2].transform.position = new Vector2(width * 2.5f, (heigth * 2.5f) / 2);
        boundaries[3].transform.position = new Vector2((width * 2.5f) / 2, 0);
        //Adjusting collider sizes according to the map size
        bColliders[0].size = new Vector2(1, heigth * 2.5f);
        bColliders[1].size = new Vector2(width * 2.5f, 1);
        bColliders[2].size = new Vector2(1, heigth * 2.5f);
        bColliders[3].size = new Vector2(width * 2.5f, 1);
    }

    void CreateBackgroundTile(int i,int j, int k)
    {
        //Creating a tile gameObject and placing on some coordinates
        GameObject go = new GameObject();

        go.name = "Background" + (k).ToString();
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        go.transform.position = new Vector2(i * (2.5f) + 1.25f, j * (2.5f) + 1.25f);
        renderer.sprite = background.sprite;
        //Make tile a child of a BackGround creator and putting in Background sorting layer
        go.transform.SetParent(this.transform, false);
        renderer.sortingLayerName = "Background";
       
    }

    void PopulateWithObjects(int i, int j, int k)
    {
        string[] meteorSprites = {"MB1", "MB2", "MB3", "MB4", "MG1", "MG2", "MG3", "MG4" };
        //Randomly generate objects taken from Resources
        int meteor = Random.Range(1, 10);

        if (j != heigth && j != 0)
        {
            if (meteor >= 9)
            {
                GameObject mGo = Instantiate(BigMeteor, new Vector2(i * (2.5f) + 1.25f + Random.Range(0, 2), j * (2.5f) + Random.Range(0, 2)), Quaternion.Euler(transform.rotation.x,transform.rotation.y, Random.Range(0, 180)) );
                SpriteRenderer mRenderer = mGo.GetComponent<SpriteRenderer>();
                int meteorSprite = Random.Range(1, 8);
                mRenderer.sprite = Resources.Load(meteorSprites[meteorSprite], typeof(Sprite)) as Sprite;
                mRenderer.sortingLayerName = "BackgroundObjects";
                mGo.transform.SetParent(this.transform, false);
               
            }
        }
      
    }

    private void SpawnPirates()
    {

        int numberOfPirates = width / 20;

        for (int i = 0; i < numberOfPirates; i++)
        {
            PirateSpawnPoint spawnPoint = new PirateSpawnPoint(width,spawnPoints);
            spawnPoints.Add(spawnPoint);

            GameObject pirate = Instantiate(Pirate, spawnPoint.getSpawnPoint(), gameObject.transform.rotation);
            PirateDeathNotificator pdn = pirate.GetComponent<PirateDeathNotificator>();

            pdn.pirateKilled += pirateNumbers.show;
        }

    }


	void Update () {
		
	}
}
