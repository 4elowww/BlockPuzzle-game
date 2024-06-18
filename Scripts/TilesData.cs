using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesData : MonoBehaviour, GlobalData
{
    public Tilemap TileMap;

    [SerializeField] protected Tile _block;
    [SerializeField] private Tilemap  _tileMapLayer2;
    [SerializeField] private Tile _blockShadow, _blockClosed, _emptyTile;

    [Header("SCRIPT")]
    public AddFigures AddFigures;

    private TileBase GetDataTile(Vector3Int pos)
    {
        return TileMap.GetTile(pos);
    }

    private Vector3Int _lateGridPos;
    private Vector3Int _gridPosition;

    public void SetTilesOnField(Vector2 pos)
    {
        _gridPosition = TileMap.WorldToCell(pos);

        if (Mathf.Abs(_gridPosition.x) > 4 || Mathf.Abs(_gridPosition.y) > 4)
        {
                GlobalData.Placeble = false;
        }

        if (_gridPosition != _lateGridPos)
        {
            TileBase content = GetDataTile(_gridPosition);

            if (content != _block)
                _tileMapLayer2.SetTile(_gridPosition, _blockShadow);
            else if (content == _block)
            {
                // _tileMapLayer2.SetTile(_gridPosition, _blockClosed);
                GlobalData.Placeble = false;
            }
        }
        PlacebleCheck(pos);
    }
    private void PlacebleCheck(Vector2 pos)
    {
        if (GlobalData.Placeble == false)
            CleanTileMap();

    }
    public void DeleteTiles()
    {
        _tileMapLayer2.SetTile(_lateGridPos, _emptyTile);
        _lateGridPos = _gridPosition;
    }
    public void OnPointerDrag()
    {
        /*Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SetTilesOnField(mousePosition); */
    }
    public void CleanTileMap()
    {
        _tileMapLayer2.ClearAllTiles();
    }
}
