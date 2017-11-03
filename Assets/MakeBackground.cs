using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBackground : MonoBehaviour {

    public SpriteRenderer background = new SpriteRenderer();
    public SpriteRenderer objects = new SpriteRenderer();
    public int width = 10;
    public int heigth = 10;

	// Use this for initialization
	void Start ()
    {
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
	}

    void CreateBackgroundTile(int i,int j, int k)
    {
         GameObject go = new GameObject();
         
         go.name = "Background" + (k).ToString();
         SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
         go.transform.position = new Vector2(-10 + i * (2.5f), -5 + j * (2.5f));
         renderer.sprite = background.sprite;
         go.transform.SetParent(this.transform, false);
         renderer.sortingLayerName = "Background";
    
    }

    void PopulateWithObjects(int i, int j, int k)
    {
         int meteor = Random.Range(1, 10);
          
         if (meteor >= 9)
         {
             GameObject mGo = new GameObject();
             mGo.name = "Meteor" + (k).ToString(); ;
             SpriteRenderer mRenderer = mGo.AddComponent<SpriteRenderer>();
             mGo.transform.position = new Vector2(-10 + i * (2.5f), -5 + j * (2.5f));
             mRenderer.sprite = Resources.Load("meteorBrown_big1", typeof(Sprite)) as Sprite;
             mRenderer.sortingLayerName = "BackgroundObjects";
             mGo.transform.SetParent(this.transform, false);
         }
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
