using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{

    //public delegate void SpinCompleteDelegate();

    [SerializeField] private float totalSpinAmount;


    //private SpinCompleteDelegate onSpinComplete;
    //private Action onSpinComplete;

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        
        float spinAddAmount = 360.0f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        totalSpinAmount += spinAddAmount;

        if (totalSpinAmount >= 360.0f)
        {
            isActive = false;
            onActionComplete();
        }

    }

    public void Spin(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive = true;
        totalSpinAmount = 0f;
    }
}
