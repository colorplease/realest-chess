using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[,] tiles;
    public piece[] whitePieces;
    public piece[] blackPieces;
    public GameObject testPiece;
    public GameObject currentSelectedTile;
    public int tileCountX, tileCountY;
    [SerializeField]GameObject[] tileObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
           SpawnPiece();
        }
    }

    void SpawnPiece()
    {
         GetAllTiles();
            var randomX = Random.Range(0, 8);
            var randomY = Random.Range(0, 8);
            if(tiles[randomX, randomY].GetComponent<tile>().isOccupied)
            {
                SpawnPiece();
            }
            else
            {
                GameObject testPieceObject = Instantiate(testPiece, tiles[randomX, randomY].transform.position, Quaternion.identity);
            }
            GetAllPieces();
    }

    public void SelectTile(GameObject newSelectedTile)
    {
        if (currentSelectedTile == null)
        {
            currentSelectedTile = newSelectedTile;
        }
        else
        {
            currentSelectedTile.GetComponentInChildren<tile>().Deselect();
            currentSelectedTile = newSelectedTile;
        }
    }

    public void GetAllPieces()
    {
        GameObject[] blackPieceObjects = GameObject.FindGameObjectsWithTag("black");
        blackPieces = new piece[blackPieceObjects.Length];
        for(int i = 0; i < blackPieceObjects.Length; i++)
        {
            blackPieces[i] = blackPieceObjects[i].GetComponent<piece>();
            blackPieces[i].indexNumber = i;
        }
    }

    public void GetAllTiles()
    {
         tileObjects = GameObject.FindGameObjectsWithTag("tile");
        tiles = new GameObject[tileCountX, tileCountY];
         for(int i = 0; i < tileObjects.Length; i++)
         {
            tile currentTile = tileObjects[i].GetComponent<tile>();
            tiles[(int)currentTile.location.x - 1, (int)currentTile.location.y - 1] = tileObjects[i];
         }
    }
}
