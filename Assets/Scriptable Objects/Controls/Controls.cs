using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controls", menuName = "ScriptableObjects/Controls")]
public class Controls : ScriptableObject
{
    //movement
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    //other
    public KeyCode fire;
}
