using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugObject : MonoBehaviour
{
   
    [SerializeField] private TextMeshPro textMeshpro;
    private GridObject gridObject;

    public void SetGridObject(GridObject newGridObject)
    {
        this.gridObject = newGridObject;
    }

    private void Update()
    {
        textMeshpro.text = gridObject.ToString();
    }
}
