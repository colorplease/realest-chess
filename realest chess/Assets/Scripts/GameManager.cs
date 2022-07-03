using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject testPiece;
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
        }
    }
}
