using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Tile : MonoBehaviour {
    [SerializeField] private Sprite _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
 
    public void Init(bool isOffset, float rowNumber) {
        _renderer.sprite = isOffset ? _offsetColor : _baseColor;
        //int rowNumberInt = (int)rowNumber;
        _renderer.sortingOrder = (int)-rowNumber;
    }
 
    void OnMouseEnter() {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}