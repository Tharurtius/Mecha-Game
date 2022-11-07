using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged", menuName = "ScriptableObjects/Ranged")]
public class Ranged : IWeapon
{
    [SerializeField] private float lifeTime = 5;
    //from origin, bullet spawns and activates its own movement script
    public override void Attack(Transform origin)
    {
        Transform barrel = origin.transform;
        GameObject shoot = Instantiate(hitbox, barrel.position + hitbox.transform.position, barrel.rotation);
        Destroy(shoot, lifeTime);//destroy after lifetime is over
    }
}
