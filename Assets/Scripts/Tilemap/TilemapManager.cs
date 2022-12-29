using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemapFunc;
    [SerializeField] private List<Tile> tileList;

    private List<TileField> tileFields;
    
    public const int CountOfTiles = 2;

    public void Init()
    {
        InitTileField();

    }

    #region ToDo
    // TODO: переделать инициализацию полей
    private Dictionary<Vector3Int, TileBase> FirstDict(int countOfTiles)
    {
        Dictionary<Vector3Int, TileBase> dict = new Dictionary<Vector3Int, TileBase>(countOfTiles)
        {
            {new Vector3Int(-2,-4,0), tilemapFunc.GetTile(new Vector3Int(-2,-4,0))},
            {new Vector3Int(-2,-5,0), tilemapFunc.GetTile(new Vector3Int(-2,-5,0))},
            {new Vector3Int(-2,-6,0), tilemapFunc.GetTile(new Vector3Int(-2,-6,0))},
            {new Vector3Int(-2,-7,0), tilemapFunc.GetTile(new Vector3Int(-2,-7,0))},
            {new Vector3Int(-3,-4,0), tilemapFunc.GetTile(new Vector3Int(-3,-4,0))},
            {new Vector3Int(-3,-5,0), tilemapFunc.GetTile(new Vector3Int(-3,-5,0))},
            {new Vector3Int(-3,-6,0), tilemapFunc.GetTile(new Vector3Int(-3,-6,0))},
            {new Vector3Int(-3,-7,0), tilemapFunc.GetTile(new Vector3Int(-3,-7,0))},
            {new Vector3Int(-4,-4,0), tilemapFunc.GetTile(new Vector3Int(-4,-4,0))},
            {new Vector3Int(-4,-5,0), tilemapFunc.GetTile(new Vector3Int(-4,-5,0))},
            {new Vector3Int(-4,-6,0), tilemapFunc.GetTile(new Vector3Int(-4,-6,0))},
            {new Vector3Int(-4,-7,0), tilemapFunc.GetTile(new Vector3Int(-4,-7,0))},
            {new Vector3Int(-5,-4,0), tilemapFunc.GetTile(new Vector3Int(-5,-4,0))},
            {new Vector3Int(-5,-5,0), tilemapFunc.GetTile(new Vector3Int(-5,-5,0))},
            {new Vector3Int(-5,-6,0), tilemapFunc.GetTile(new Vector3Int(-5,-6,0))},
            {new Vector3Int(-5,-7,0), tilemapFunc.GetTile(new Vector3Int(-5,-7,0))},
            {new Vector3Int(-6,-4,0), tilemapFunc.GetTile(new Vector3Int(-6,-4,0))},
            {new Vector3Int(-6,-5,0), tilemapFunc.GetTile(new Vector3Int(-6,-5,0))},
            {new Vector3Int(-6,-6,0), tilemapFunc.GetTile(new Vector3Int(-6,-6,0))},
            {new Vector3Int(-6,-7,0), tilemapFunc.GetTile(new Vector3Int(-6,-7,0))}

        };
        return dict;
    }

    private Dictionary<Vector3Int, TileBase> SecondDict(int countOfTiles)
    {
        Dictionary<Vector3Int, TileBase> dict = new Dictionary<Vector3Int, TileBase>(countOfTiles)
        {
            {new Vector3Int(-2,-9,0), tilemapFunc.GetTile(new Vector3Int(-2,-9,0))},
            {new Vector3Int(-2,-10,0), tilemapFunc.GetTile(new Vector3Int(-2,-10,0))},
            {new Vector3Int(-2,-11,0), tilemapFunc.GetTile(new Vector3Int(-2,-11,0))},
            {new Vector3Int(-2,-12,0), tilemapFunc.GetTile(new Vector3Int(-2,-12,0))},
            {new Vector3Int(-3,-9,0), tilemapFunc.GetTile(new Vector3Int(-3,-9,0))},
            {new Vector3Int(-3,-10,0), tilemapFunc.GetTile(new Vector3Int(-3,-10,0))},
            {new Vector3Int(-3,-11,0), tilemapFunc.GetTile(new Vector3Int(-3,-11,0))},
            {new Vector3Int(-3,-12,0), tilemapFunc.GetTile(new Vector3Int(-3,-12,0))},
            {new Vector3Int(-4,-9,0), tilemapFunc.GetTile(new Vector3Int(-4,-9,0))},
            {new Vector3Int(-4,-10,0), tilemapFunc.GetTile(new Vector3Int(-4,-10,0))},
            {new Vector3Int(-4,-11,0), tilemapFunc.GetTile(new Vector3Int(-4,-11,0))},
            {new Vector3Int(-4,-12,0), tilemapFunc.GetTile(new Vector3Int(-4,-12,0))},
            {new Vector3Int(-5,-9,0), tilemapFunc.GetTile(new Vector3Int(-5,-9,0))},
            {new Vector3Int(-5,-10,0), tilemapFunc.GetTile(new Vector3Int(-5,-10,0))},
            {new Vector3Int(-5,-11,0), tilemapFunc.GetTile(new Vector3Int(-5,-11,0))},
            {new Vector3Int(-5,-12,0), tilemapFunc.GetTile(new Vector3Int(-5,-12,0))},
            {new Vector3Int(-6,-9,0), tilemapFunc.GetTile(new Vector3Int(-6,-9,0))},
            {new Vector3Int(-6,-10,0), tilemapFunc.GetTile(new Vector3Int(-6,-10,0))},
            {new Vector3Int(-6,-11,0), tilemapFunc.GetTile(new Vector3Int(-6,-11,0))},
            {new Vector3Int(-6,-12,0), tilemapFunc.GetTile(new Vector3Int(-6,-12,0))}

        };
        return dict;
    }

    #endregion

    private void InitTileField()
    {

        tileFields = new List<TileField>(CountOfTiles)
        {
            new TileField(1),
            new TileField(2)
        };

        tileFields[0].dictOfTiles = FirstDict(tileFields[0].countOfTiles);
        tileFields[1].dictOfTiles = SecondDict(tileFields[1].countOfTiles);

        foreach (var item in tileFields)
        {
            item.listOfTiles = item.dictOfTiles.Keys.ToList();
        }
    }

    public void ReplaceTile(int numberOfField, GroundTileType tileType)
    {
        foreach (var Field in tileFields)
        {
            if (Field.numberOfField == numberOfField)
            {
                foreach (var item in Field.listOfTiles)
                {
                    tilemapFunc.SetTile(item, tileList[(int)tileType]);
                    Field.dictOfTiles[item] = tileList[(int)tileType];
                }
            }
        }
    }

    public int GetField(Vector3Int sellpos)
    {
        foreach (var Field in tileFields)
        {
            if (Field.listOfTiles.Contains(sellpos))
            {
                return Field.numberOfField;
            }
        }
        return 0;
    }

    public bool CheckTile(Vector3Int sellpos)
    {
        if (tilemapFunc.HasTile(sellpos))
        {
            if (tileList.Contains(tilemapFunc.GetTile(sellpos)))
            {
                return true;
            }
        }
        return false;
    }

    public Vector3Int GetSellPosition(Vector3 clickWorldPosition)
    {   
        Vector3Int sellPosition = tilemapFunc.WorldToCell(clickWorldPosition);

        sellPosition.z = 0;

        return sellPosition;
    }

}
