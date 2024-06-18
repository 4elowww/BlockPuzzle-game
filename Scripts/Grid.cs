using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour, GlobalData
{
     public Tilemap _tileMap;
    [SerializeField] protected Tile _block;

    private void Awake()
    {
       /* Debug.Log("RandomMap Generate");
        
        #region RandomMap
        for (int i = -4; i <= 4; i++)
        {
            for (int j = -4; j <= 4; j++)
            {
                if (Random.Range(0, 2) == 1)
                    _tileMap.SetTile(new Vector3Int(i, j, 0), _block);
            }
        }
        #endregion
        */
    }
    public void LoadBlockMap()
    {
        for (int i = -4; i <= 4; i++)
        {
            for (int j = -4; j <= 4; j++)
            {
                if (GlobalData._blockMap[j + 4][i + 4] == 1)
                    _tileMap.SetTile(new Vector3Int(i, j, 0), _block);
            }
        }
    }
}
