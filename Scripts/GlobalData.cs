using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface GlobalData
{
    protected static int[][] _blockMap = {
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
          new int[]   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    public static bool Placeble = false;
}
