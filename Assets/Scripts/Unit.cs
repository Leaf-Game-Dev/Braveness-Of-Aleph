using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;


    private Vector3 targetPosition;
    private GridPosition gridPosition;


    // actions
    private MoveAction moveAction;

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition,this);
        moveAction = GetComponent<MoveAction>();
        moveAction.SetAnimator(unitAnimator);
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    void Update()
    {



        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }

    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }


}
