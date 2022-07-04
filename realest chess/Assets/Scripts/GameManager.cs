using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] tiles;
    public piece[] whitePieces;
    public piece[] blackPieces;
    public GameObject testPiece;
    public GameObject currentSelectedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            var random = Random.Range(0, tiles.Length);
             GameObject found = new List<GameObject>(GameObject.FindGameObjectsWithTag("tilePosition")).Find(g => g.transform.IsChildOf(tiles[random].transform));
            GameObject testPieceObject = Instantiate(testPiece, found.transform.position, Quaternion.identity);
            GetAllPieces();
        }
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
}
