using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    private Vector3 targetPosition;


    private void Awake()
    {
        targetPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnUnitMove += GameInput_OnUnitMove;
    }

    private void GameInput_OnUnitMove(object sender, System.EventArgs e)
    {
        Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        targetPosition = MouseManager.Instance.GetMousePosition();
    }
}
