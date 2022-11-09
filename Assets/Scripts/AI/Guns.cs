using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] private Ranged bullet;
    [SerializeField] private float countdown = 5;
    // Start is called before the first frame update
    void Start()
    {
        countdown += UnityEngine.Random.Range(-3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown += bullet.cooldown + UnityEngine.Random.Range(-3f, 3f);
            bullet.Attack(transform);
        }
    }
}
