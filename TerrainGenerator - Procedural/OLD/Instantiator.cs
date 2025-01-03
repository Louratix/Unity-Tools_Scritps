using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Instantiator : MonoBehaviour
{

    public GameObject Parent;
    GameObject terrainObj;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        terrainObj = new GameObject("Terrain");
        meshFilter = terrainObj.AddComponent<MeshFilter>();
        meshRenderer = terrainObj.AddComponent<MeshRenderer>();
        meshCollider = terrainObj.AddComponent<MeshCollider>();
        terrainObj.transform.parent = Parent.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
