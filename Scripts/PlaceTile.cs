using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTile : MonoBehaviour, GlobalData
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tile _block;
    [SerializeField] private Transform[] _figurePreset;

    protected TileBase _tileBase;

    [Header("SCRIPTs")]
    [SerializeField] private GameObject[] _moveFigure;
    [SerializeField] private AddFigures _addFigures;
    private Vector3Int[] FindTilePosition(Transform _groupParent)
    {
        Vector3Int[] output = { 
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0),
        new Vector3Int(0, 0, 0)
        };
        for (int i = 0; i < _groupParent.childCount; i++)
        {
            output[i] = _tileMap.WorldToCell(_groupParent.transform.GetChild(i).position);
        }
        return output;
    }
    public void PlaceFigure(Transform _groupParent)
    {
        if (GlobalData.Placeble)
        {
            Debug.Log("Place");

            for (int i = 0; i < _groupParent.childCount; i++)
            {
                _tileMap.SetTile(FindTilePosition(_groupParent)[i], _block);
            }

            for (int i = 0; i < 3; i++)
            {
                if (_figurePreset[i].tag == "SelectedFigure")
                    _moveFigure[i].GetComponent<MoveFigure>().SetTagEmptyToPreset();
                    _moveFigure[i].GetComponent<MoveFigure>().GoToSpawnPoint();
            }
        }
    }
}
