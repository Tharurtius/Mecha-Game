using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackler : MonoBehaviour
{
    public Transform goal;
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameManager.living[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        CloserPlayer();
        transform.forward = goal.position - transform.position;
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void CloserPlayer()
    {
        float distance = float.PositiveInfinity;
        foreach (GameObject player in GameManager.living)
        {
            if (distance < Vector3.Distance(player.transform.position, transform.position))
            {
                goal = player.transform;
            }
        }
    }
}
