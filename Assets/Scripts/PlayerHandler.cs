using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private IWeapon _weapon;
    [SerializeField] private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        _weapon.Spawn(transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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
    }
}
