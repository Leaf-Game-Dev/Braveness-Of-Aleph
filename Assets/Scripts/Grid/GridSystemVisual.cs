using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] Transform gridSystemVisualPrefab;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    public static GridSystemVisual Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one GridSystemVisual");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        gridSystemVisualSingleArray = new GridSystemVisualSingle[
            LevelGrid.Instance.GetGridWidth(), LevelGrid.Instance.GetGridHeight()
        ];
        for (int x = 0; x < LevelGrid.Instance.GetGridWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetGridHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);
                gridSystemVisualSingleArray[x,z] = Instantiate(gridSystemVisualPrefab,LevelGrid.Instance.GetWorldPosition(gridPosition),Quaternion.identity).GetComponent<GridSystemVisualSingle>();
            }
        }
    }

    public void HideAllGridPositions()
    {
        for (int x = 0; x < LevelGrid.Instance.GetGridWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetGridHeight(); z++)
            {
                gridSystemVisualSingleArray[x, z].Hide();
            }
        }
    }

    public void ShowGridPositionsList(List<GridPosition> gridPositions)
    {
        foreach (var position in gridPositions)
        {
            gridSystemVisualSingleArray[position.x, position.z].Show();
        }
    }

    private void Update()
    {
        UpdateGridVisual();
    }

    void UpdateGridVisual()
    {
        HideAllGridPositions();

        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        ShowGridPositionsList(selectedUnit.GetMoveAction().GetValidActionGridPositionList());

    }

}
