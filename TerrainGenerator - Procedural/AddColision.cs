using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
}
