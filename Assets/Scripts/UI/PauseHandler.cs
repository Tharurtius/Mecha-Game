using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : ISceneSwap
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Any B1") && Time.timeScale == 1f) //if pause pressed and game not paused
        {
            gameManager.PauseUnPause();
        }
    }
}
