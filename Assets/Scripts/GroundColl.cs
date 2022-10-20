using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColl : MonoBehaviour
{
    PlayerControler playerControler;
    // Start is called before the first frame update
    void Start()
    {
        playerControler = GameManager.instance.player.GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
