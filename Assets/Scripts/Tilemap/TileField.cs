using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileField
{
    public int numberOfField;
    public int countOfTiles = 20;
    public List<Vector3Int> listOfTiles;
    public Dictionary<Vector3Int, TileBase> dictOfTiles;

    public TileField(int _numberOfField)
    {
        numberOfField = _numberOfField;
    }
}
