using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    public int width;
    public int height;
    public float cellSize;

    public GridSystem(int width,int height,float cellSize)
    {
        this.width = width;
        this.height = height;   
        this.cellSize = cellSize;

        for(int x=0;x<width;x++)
        {
            for(int z=0;z<height;z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                Debug.DrawLine(GetWorldPosition(gridPosition), GetWorldPosition(gridPosition) + Vector3.right * 0.5f, Color.green, 9999.0f);
            }
        }

    }


    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x,0.0f,gridPosition.z) * cellSize;
    }
}
