using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;
    public GridObject(GridPosition gridPosition , GridSystem gridSystem)
    {
        this.gridPosition = gridPosition;
        this.gridSystem = gridSystem;
        unitList = new List<Unit>();
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void RemovUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public void AddUnit(Unit unit)
    {
        this.unitList.Add(unit);
    }

    public override string ToString()
    {
        string unitsString= "";

        foreach (var item in unitList)
        {
            unitsString += "\n"+item;
        }

        return gridPosition.x+","+gridPosition.z+"\n"+ unitsString;
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }

}
