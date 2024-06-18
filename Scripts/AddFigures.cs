using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
public class AddFigures : TilesData
{

    private int[][] FigureBuilder()
    {
        int Num = Random.Range(1, 14);
        switch (Num)
        {
            case 1:
                return new int[][] {
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 1 }
                };
            case 2:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 1, 1, 0 },
                    new int[] { 1, 1, 0 }
                };
            case 3:
                return new int[][] {
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1, 1 }
                };
            case 4:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 0, 1 },
                    new int[] { 1, 1, 1 }
                };
            case 5:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 1, 1, 1 },
                    new int[] { 0, 0, 0 }
                };
            case 6:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 1 }
                };
            case 7:
                return new int[][] {
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 0 }
                };
            case 8:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 1, 1, 0 },
                    new int[] { 0, 0, 0 }
                };
            case 9:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 0, 0 }
                };
            case 10:
                return new int[][] {
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 1 },
                    new int[] { 0, 1, 0 }
                };
            case 11:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 1, 0, 1 },
                    new int[] { 1, 1, 1 }
                };
            case 12:
                return new int[][] {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 0 }
                };       
            case 13:
                return new int[][] {
                    new int[] { 0, 0, 1 },
                    new int[] { 0, 1, 1 },
                    new int[] { 0, 1, 0 }
                };
            default:
                Debug.LogError("Õ≈¬≈–Õ¿ﬂ ‘»√”–¿");
                int[][] error = {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 0, 0 }
                };
                return error;
        }
    }
    [SerializeField] private GameObject _blockGameObject;
    [SerializeField] private Transform[] _figurePreset;
    [SerializeField] private RectTransform[] _groupParent;

    private void Start()
    {
        generateAll();
    }
    private void Update()
    {
        Debug.Log(_figurePreset[0] + "  " + _groupParent[0]);
    }
    private void generateAll()
    {
        GenerateFigure(_figurePreset[0], _groupParent[0]);
        GenerateFigure(_figurePreset[1], _groupParent[1]);
        GenerateFigure(_figurePreset[2], _groupParent[2]);
    }
    public void AddFigure()
    {
        bool[] ReFillFigures = { false, false, false };
        for(int i = 0; i < 3; i++)
        {
            if (_figurePreset[i].tag == "emptyFigure")
                ReFillFigures[i] = true;
        }
        if (ReFillFigures[0] == true & ReFillFigures[1] == true & ReFillFigures[2] == true)
            generateAll();
    }
    private void GenerateFigure(Transform figurePreset, RectTransform groupParent)
    {
        _figurePreset[0].tag = ("Untagged");
        _figurePreset[1].tag = ("Untagged");
        _figurePreset[2].tag = ("Untagged");
        int[][] newFigure = FigureBuilder();
        int l = 0;
        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {

                if (newFigure[i][j] == 1)
                {
                    GameObject part = Instantiate(_blockGameObject, figurePreset.GetChild(l).transform.position, Quaternion.Euler(0, 0, 0));
                    part.transform.localScale = figurePreset.localScale;
                    part.transform.SetParent(groupParent);
                }
                l++;
            }
        }

        switch (Random.Range(1, 5))
        {
            case 1:
                groupParent.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                groupParent.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 3:
                groupParent.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case 4:
                groupParent.rotation = Quaternion.Euler(0, 0, -90);
                break;
            default:
                groupParent.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    public void NewFigure(Transform GroupParent)
    {
        for (int i = 0; i < GroupParent.childCount; i++)
        {
            Destroy(GroupParent.GetChild(i).gameObject);
        }
        AddFigure();
    }
}
