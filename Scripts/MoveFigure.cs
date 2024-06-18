using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Animations;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveFigure : MonoBehaviour, GlobalData
{
    public TilesData TilesData;
    private Vector2 _spawnPosition;
    [SerializeField] private bool Placeble;
    [SerializeField] private Transform _preset;
    [SerializeField] private Transform _parent;

    private RectTransform _RectTransform;

    [Header("SCRIPTs")]
    [SerializeField] private PlaceTile _placeTile;
    [SerializeField] private AddFigures _addFigures;
    private void Start()
    {
        _RectTransform = GetComponent<RectTransform>();
        _spawnPosition = transform.position;
    }
    public void OnPointerDown()
    {
        _RectTransform.localScale = new Vector3(140,140,140);
    }
    public new void OnPointerDrag()
    {
        _preset.gameObject.tag = "SelectedFigure";

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        TilesData.CleanTileMap();
        GlobalData.Placeble = true;
        for (int i = 0; i < transform.childCount; i++)
        { 
            Transform child = transform.GetChild(i);
            child.GetComponent<TilesData>().SetTilesOnField(child.transform.position);
        }
    }
    public void OnPointerUp()
    {
        _placeTile.PlaceFigure(transform);
        GoToSpawnPoint();
        if (GlobalData.Placeble)
            _addFigures.NewFigure(gameObject.transform);
    }
    public void GoToSpawnPoint()
    {
        transform.position = _spawnPosition;
        _RectTransform.localScale = new Vector3(96, 96, 96);
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<TilesData>().CleanTileMap();
        }
    }
    public void SetTagEmptyToPreset()
    {
        for(int i = 0; i <=3; i++)
        {
            Vector2 pos = _preset.position;
            if (pos != _spawnPosition)
                _preset.gameObject.tag = "emptyFigure";
        }
    }
}
