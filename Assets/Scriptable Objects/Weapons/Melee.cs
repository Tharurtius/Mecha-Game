using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Melee", menuName = "ScriptableObjects/Melee")]
public class Melee : ScriptableObject, IWeapon
{
    [SerializeField] private Image image;//image shown to player in the menu
    [SerializeField] private GameObject model;//actual model in game
    [SerializeField] private string name;//name shown to player in the menu

    private GameObject hitbox;//hitbox of the weapon swing
    public void Attack()
    {
        
    }

    public void Spawn(Transform parent)
    {
        model = Instantiate(model, parent);
    }
}
