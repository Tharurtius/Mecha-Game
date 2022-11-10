using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlsV2", menuName = "ScriptableObjects/ControlsV2")]
public class ControlsV2 : ScriptableObject
{
    //joystick
    public string horizontal;
    public string vertical;

    //fire
    public string fire;
}
