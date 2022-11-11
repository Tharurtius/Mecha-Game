using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Material skin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);//move forward at speed
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.tag == "EnemyAttack" && collision.transform.tag == "Sword")
        {
            transform.tag = "PlayerAttack";//turn into player attack
            transform.forward = collision.transform.parent.position - transform.position;//flies as an angle away from the sword
            GetComponent<Renderer>().material = skin;
        }
    }
}
