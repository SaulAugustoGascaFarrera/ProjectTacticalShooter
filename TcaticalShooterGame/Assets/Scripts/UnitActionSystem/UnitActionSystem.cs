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

    private void GameInput_OnUnitMove(object sender, EventArgs e)
    {
        if (TryGetUnitSelection()) return;

        Debug.Log("ya podrias kmovberse wey");
    }

    // Update is called once per frame
    void Update()
    {

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

}
