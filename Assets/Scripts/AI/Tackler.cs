using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackler : MonoBehaviour
{
    public Vector3 goal;
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameManager.living[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CloserPlayer();
        transform.forward = goal - transform.position;
        transform.position += transform.forward * Time.deltaTime * speed;
        speed += Time.deltaTime;
    }

    void CloserPlayer()
    {
        float distance = float.PositiveInfinity;
        foreach (GameObject player in GameManager.living)
        {
            if (distance > Vector3.Distance(player.transform.position, transform.position))
            {
                goal = player.transform.position;
                distance = Vector3.Distance(player.transform.position, transform.position);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Sword")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "PlayerAttack")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(GameManager.explode, transform.position, Quaternion.identity);
    }
}
