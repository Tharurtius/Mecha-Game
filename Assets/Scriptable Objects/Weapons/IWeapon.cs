using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IWeapon : ScriptableObject
{
    public string weaponName;//name shown to player in the menu
    public Sprite sprite;//image shown to player in the menu
    public GameObject model;//actual model in game
    public GameObject hitbox;//hitbox of the weapon, melee sticks with the origin, bullets fly away
    public float cooldown;

    public abstract void Attack(Transform origin);//method that is called when attack input is pressed

    public void Spawn(Transform parent) //called when weapon is first spawned ingame
    {
        Instantiate(model, parent);
    }
}
