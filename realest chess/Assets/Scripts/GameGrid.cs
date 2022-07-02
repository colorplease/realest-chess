using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameGrid : MonoBehaviour {
    [SerializeField] private int _width, _height;
 
    [SerializeField] private Tile _tilePrefab;
 
    [SerializeField] private Transform _cam;
 
    private Dictionary<Vector2, Tile> _tiles;
    int realY;
 
    void Start() {
        GenerateGrid();
    }
 
    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (float x = 0; x < _width; x++) {
            for (float y = 0; y < _height; y += 0.9f) {
                realY++;
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {realY}";
 
                var isOffset = (x % 2 == 0 && realY % 2 != 0) || (x % 2 != 0 && realY % 2 == 0);
                var rowNumber = realY;
                spawnedTile.Init(isOffset, rowNumber);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
 
        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height / 2 - 0.5f,-10);
    }
 
    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}