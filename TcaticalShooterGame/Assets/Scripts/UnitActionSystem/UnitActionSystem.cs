using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public class OnSelectedUnitEventArgs : EventArgs
    {
        public Unit selectedUnit;
    }

    public static UnitActionSystem Instance { get; private set; }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Unit selectedUnit;


    private bool isBusy;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);   
            return;
        }


        Instance = this;


    }

    private void Start()
    {
        gameInput.OnUnitMove += GameInput_OnUnitMove;
    }

    private void Update()
    {
        //if (TryGetUnitSelection()) return;

        if (isBusy) return;

        if (Input.GetMouseButtonDown(1))
        {
            SetBusy();

            selectedUnit.GetSpinAction().Spin(ClearBusy);

        }
    }

    private void GameInput_OnUnitMove(object sender, EventArgs e)
    {

        if (isBusy) return;

        if (TryGetUnitSelection()) return;

        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMousePosition());

        //if (!LevelGrid.Instance.IsValidGridPosition(gridPosition)) return;

        if(selectedUnit.GetMoveActions().IsValidActionAtGridPosition(gridPosition))
        {
            selectedUnit.GetMoveActions().Move(gridPosition,ClearBusy);

            SetBusy();
        }

        
        

    }

    public bool TryGetUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit,float.MaxValue,1 << 7))
        {
            if (hit.transform.gameObject.TryGetComponent(out Unit unit))
            {
                
                SetSelectedUnit(unit);
                return true;
            }

        }

        return false;
    }

    public void SetSelectedUnit(Unit newSelectedunit)
    {
        selectedUnit = newSelectedunit;

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;    
    }

    public void SetBusy()
    {
        isBusy = true;  
    }

    public void ClearBusy()
    {
        isBusy = false;
    }

}
