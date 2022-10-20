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
