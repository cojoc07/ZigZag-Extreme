using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;    

    public GameObject currentTile;

    private static TileManager instance;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles
    {
        get
        {
            return leftTiles;
        }

        set
        {
            leftTiles = value;
        }
    }


    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles
    {
        get
        {
            return topTiles;
        }

        set
        {
            topTiles = value;
        }
    }


    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return TileManager.instance;
        }
    }

   

    void Start () {

        CreateTiles(100);

        for(int i = 0; i < 50; i++)
        {
            //SpawnTile();
            SpawnTileEasyMode();
        }
        
	}
	
	
	void Update () {
		
	}


    public void CreateTiles(int amount)
    {
        for (int i = 0; i<amount; i++)
        {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));

            TopTiles.Peek().name = "TopTile";
            LeftTiles.Peek().SetActive(false);

            LeftTiles.Peek().name = "LeftTile";
            TopTiles.Peek().SetActive(false);
            
        }
    }


    public void SpawnTile()
    {

        if (LeftTiles.Count == 0 || TopTiles.Count == 0)
        {
            CreateTiles(10);
        }

        //generam numere intre 0 si 1
        int randomIndex = Random.Range(0, 2);  

        if (randomIndex == 0)
        {
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;

            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;

            currentTile = tmp;
        }

        int spawnPickup = Random.Range(0, 10);
        if (spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }

        
    }



    /////////////////////////////////////////////
    public void SpawnTileEasyMode()
    {

        int catePiese = Random.Range(1, 4);

        if (LeftTiles.Count == 0 || TopTiles.Count == 0)
        {
            CreateTiles(10);
        }

        //generam numere intre 0 si 1
        int randomIndex = Random.Range(0, 2);


        //daca e 0, spawnam left tile
        if (randomIndex == 0)
        {
            for (int i = 0; i<catePiese; i++)
            {
                GameObject tmp = LeftTiles.Pop();
                tmp.SetActive(true);
                tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;

                currentTile = tmp;
            }
            
        }

        //daca e 1, spawnam top tile

        else if (randomIndex == 1)
        {
            for (int i = 0; i < catePiese; i++)
            {
                GameObject tmp = TopTiles.Pop();
                tmp.SetActive(true);
                tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;

                currentTile = tmp;
            }
            
        }

        int spawnPickup = Random.Range(0, 10);
        if (spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }

        //currentTile = Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
    }
}
