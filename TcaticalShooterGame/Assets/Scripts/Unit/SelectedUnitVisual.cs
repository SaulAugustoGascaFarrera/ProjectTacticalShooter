using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitVisual : MonoBehaviour
{

    private Unit unit;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnit += Instance_OnSelectedUnit; ;

        UpdateVisual();
    }

    private void Instance_OnSelectedUnit(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

   

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled=false;
        }
    }
}
