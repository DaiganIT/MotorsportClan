using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private Vector2Int gridSize;
    private IList<GridItem> grid;

    public Vector3 UnitVector { get; }
    public int Count => grid.Count;

    public Level(int x, int y)
    {
        gridSize = new Vector2Int(x, y);
        grid = new List<GridItem>();

        // grid will have a static unit size for now
        UnitVector = Vector3.one / 2;

        for (var i = 0; i < x * y; i++)
        {
            grid.Add(new GridItem());
        }
    }

    public GridItem GetItem(float x, float y)
    {
        var index = GetClosestIndex(x, y);
        return grid[index];
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(i % gridSize.x * UnitVector.x, 0, Mathf.Floor(i / gridSize.x) * UnitVector.z);
    }

    public Vector3 GetCenter(int i)
    {
        return GetPosition(i) + (UnitVector / 2);
    }

    int GetClosestIndex(float x, float y)
    {
        var roundedX = Mathf.RoundToInt(x / gridSize.x) * gridSize.x;
        var roundedY = Mathf.RoundToInt(y / gridSize.y) * gridSize.y;

        return roundedX * gridSize.x + roundedY * gridSize.y;
    }
}