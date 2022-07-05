using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems; 

public class tile : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]GameObject _highlight;
    public bool selected;
    public GameManager gameManager;
    public GameObject position;
    public GameObject pieceOnTop;
    public bool isOccupied;
    public Vector2 location;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
     void OnMouseEnter() {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        if (!selected)
        {
            _highlight.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "black" || other.tag == "white")
        {
            isOccupied = true;
            pieceOnTop = other.gameObject;
            pieceOnTop.GetComponent<piece>().pos = location;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "black" || other.tag == "white")
        {
            isOccupied = false;
            pieceOnTop = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!selected)
        {
            gameManager.SelectTile(position);
            Select();
        }
        else
        {
            Deselect();
        }
    }

    public void Select()
    {
        selected = true;
        _highlight.SetActive(true);
    }

    public void Deselect()
    {
        selected = false;
         _highlight.SetActive(false);
    }
}
