using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IWeapon
{
    void Attack();//method that is called when input is pressed
    void Spawn(Transform parent);//called when weapon is first spawned ingame
}
