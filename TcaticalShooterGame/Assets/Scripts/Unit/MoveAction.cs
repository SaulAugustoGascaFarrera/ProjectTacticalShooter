using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    [Header("Movement Props")]
    [SerializeField] private float movementSpeed = 6.5f;
    [SerializeField] private float rotationSpeed = 7.0f;

    [Header("Move Props")]
    [SerializeField] private int maxMoveDistance = 1;

    [SerializeField] private GameInput gameInput;

    private Vector3 targetPosition;
    

    protected override void Awake()
    {
        base.Awake();

        targetPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnUnitMove += GameInput_OnUnitMove;
    }

    private void GameInput_OnUnitMove(object sender, System.EventArgs e)
    {
        //Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        float stoppingDistance = 0.1f;

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position,targetPosition) > stoppingDistance)
        {
           

            transform.position += moveDirection * movementSpeed * Time.deltaTime;


        }
        else
        {
            isActive = false;
            onActionComplete();
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    GridSystemVisual.Instance.HideAllGridPosition();
        //    GridSystemVisual.Instance.ShowGridPositionList(GetValidActionAtGridPositionList());
        //}

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public void Move(GridPosition gridPosition,Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        isActive = true;
    }


    public bool IsValidActionAtGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionAtGridPositionList();

        return validGridPositionList.Contains(gridPosition);
    }


    public List<GridPosition> GetValidActionAtGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();


        for(int x=-maxMoveDistance;x <= maxMoveDistance;x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);

                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;


                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                {
                    continue;
                }


                if (testGridPosition == unitGridPosition)
                {
                    //same grid position where the unit is already at
                    continue;
                }


                //Debug.Log(testGridPosition);

                validGridPositionList.Add(testGridPosition);
            }
        }


        return validGridPositionList;
    }
}
