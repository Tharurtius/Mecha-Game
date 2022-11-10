using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(root, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }
}
