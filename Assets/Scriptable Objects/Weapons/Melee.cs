using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Melee", menuName = "ScriptableObjects/Melee")]
public class Melee : IWeapon
{
    //turn on melee hitbox/model for a certain amount of time, turn it off afterwards
    public override void Attack(Transform origin)
    {
        GameObject swing = Instantiate(hitbox, origin);//parent hitbox to player to make weapon swing follow player
        Destroy(swing, 0.5f);//destroy after 0.5 seconds
    }
}
