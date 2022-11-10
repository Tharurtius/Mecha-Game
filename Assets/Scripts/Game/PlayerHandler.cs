using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private IWeapon _weapon;
    [SerializeField] private float cooldown = 0;
    [SerializeField] private Controls playerControls;

    public IWeapon Weapon
    {
        set { _weapon = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _weapon.Spawn(transform);
        
        if(_weapon is Melee)//boost speed of melee player
        {
            speed *= 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Convert.ToSingle(Input.GetKey(playerControls.down)) - Convert.ToSingle(Input.GetKey(playerControls.up));
        float horizontal = Convert.ToSingle(Input.GetKey(playerControls.right)) - Convert.ToSingle(Input.GetKey(playerControls.left));
        Vector3 vector = new Vector3(vertical, 0, horizontal);
        Move(vector);
        if (Input.GetKey(playerControls.fire) && cooldown <= 0)
        {
            _weapon.Attack(transform);
            cooldown = _weapon.cooldown;
        }
        cooldown -= Time.deltaTime;
    }

    private void Move(Vector3 vector)
    {
        transform.Translate(vector * speed * Time.deltaTime);
        
        Vector3 edge = transform.position;
        edge.z = Mathf.Clamp(edge.z, -GameManager.edgeZ, GameManager.edgeZ);
        edge.x = Mathf.Clamp(edge.x, GameManager.edgeX, -GameManager.edgeX);
        transform.position = edge;
    }

    private void OnDestroy()
    {
        GameManager.living.Remove(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "EnemyAttack" || collision.transform.tag == "Poison")
        {
            Instantiate(GameManager.explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
