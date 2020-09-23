    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int gridSizeX, gridSizeY;
    public Vector2 startPos, offset;

    //array untuk menampung prefab tile
    public GameObject tilePrefab;
    
    //array 2D untuk membuat tile
    public GameObject[,] tiles;
    public GameObject[] candies;


    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        tiles = new GameObject[gridSizeX, gridSizeY];

        offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        startPos = transform.position + (Vector3.left * (offset.x * gridSizeX / 2)) + (Vector3.down * (offset.y * gridSizeY / 3));

        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                Vector2 pos = new Vector3(startPos.x + (x * offset.x), startPos.y + (y * offset.y));

                GameObject backgroundTile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation);
                backgroundTile.transform.parent = transform;
                backgroundTile.name = "(" + x + "." + y + ")";

                int index = Random.Range(0, candies.Length);

                //create object
                GameObject candy = Instantiate(candies[index], pos, Quaternion.identity);

                candy.name = "(" + x + "." + y + ")";
                tiles[x, y] = candy;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
