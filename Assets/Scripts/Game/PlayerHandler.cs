using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private IWeapon _weapon;
    [SerializeField] private float cooldown = 0;
    [SerializeField] private Camera mainCam = Camera.main;

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
        Vector3 vector = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        Move(vector);
        if (Input.GetButton("Fire1") && cooldown <= 0)
        {
            _weapon.Attack(transform);
            cooldown = _weapon.cooldown;
        }
        cooldown -= Time.deltaTime;
    }

    private void Move(Vector3 vector)
    {
        transform.Translate(vector * speed * Time.deltaTime);

        //move position back towards center of screen
        Debug.Log(Camera.main.WorldToViewportPoint(transform.position));
        Vector3 edge = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 initialPos = edge;
        edge.x = Mathf.Clamp(edge.x, 0.1f, 0.9f);
        edge.y = Mathf.Clamp(edge.y, 0.1f, 0.9f);
        //Debug.Log(edge);
        if (edge.x != initialPos.x || edge.y != initialPos.y)
        {
            transform.position = Camera.main.ViewportToWorldPoint(edge);
        }
    }
}
