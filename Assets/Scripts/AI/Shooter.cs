using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float initialX;
    [SerializeField] private float distance = 10;
    [SerializeField] private float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        float z = transform.position.z;
        transform.position = new Vector3(initialX + Mathf.Sin(timePassed) * distance, 0, Mathf.Max(GameManager.edgeZ, z - 0.005f));
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
}
