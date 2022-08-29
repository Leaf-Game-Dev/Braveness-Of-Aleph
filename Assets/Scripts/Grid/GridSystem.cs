using System;
using UnityEngine;

public class GridSystem {

    private int width;
    private int Height;
    private float cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width, int Height, float cellSize)
    {
        this.width = width;
        this.Height = Height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, Height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < Height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(gridPosition, this);
            }
        }


    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
                        Mathf.RoundToInt(worldPosition.x/ cellSize),
                        Mathf.RoundToInt(worldPosition.z / cellSize)
            );
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < Height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);

                var gridDebugObject = GameObject.Instantiate(debugPrefab,GetWorldPosition(gridPosition),Quaternion.identity);
                gridDebugObject.GetComponent<GridDebugObject>().SetGridObject(GetGridObject(gridPosition));
            }
        }
    }


    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 &&
                gridPosition.z >= 0 &&
                gridPosition.x < width &&
                gridPosition.z < Height;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return Height;
    }

}


public struct GridPosition : IEquatable<GridPosition>
{
    public int x;
    public int z;
    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        return "x: "+x+" z:"+z;
    }

    public static bool operator ==(GridPosition a,GridPosition b)
    {
        return (a.x == b.x) && (a.z == b.z);
    }

    public static bool operator !=(GridPosition a,GridPosition b)
    {
        return !(a == b);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x + b.x, a.z + b.z);
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x - b.x, a.z - b.z);
    }


}
