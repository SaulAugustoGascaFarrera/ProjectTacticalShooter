using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    private GridSystem gridSystem;


    private void Awake()
    {
        gridSystem = new GridSystem(10, 10, 2.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
