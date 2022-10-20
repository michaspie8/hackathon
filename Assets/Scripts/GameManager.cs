using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Controls controls;
    public GameObject player;
    public Vector2 move;
    public Vector2 aim;
    public bool shootButton;
    public bool jumpButton;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        controls = new Controls();
        controls.Player.Enable();
        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => move = Vector2.zero;
        controls.Player.Jump.started += ctx => jumpButton = true;
        controls.Player.Jump.canceled += ctx => jumpButton = false;
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        controls.Player.Aim.canceled += ctx => move = Vector2.zero;
        controls.Player.Shoot.started += ctx => shootButton = true;
        controls.Player.Shoot.canceled += ctx => shootButton = false;
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
