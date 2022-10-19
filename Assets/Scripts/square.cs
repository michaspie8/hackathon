using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    
    public Controls controls;


    public Vector2 move;
    private void Awake()
    {
        controls = new();
        controls.Movement.move.performed += ctx => move = ctx.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.x += move.x;
        transform.position.z += move.z;
    }
}
