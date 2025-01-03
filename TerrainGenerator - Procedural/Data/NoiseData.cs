using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class NoiseData : UpdatableData
{
    // Start is called before the first frame update
     public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    //const int mapChunkSize = 241;
    //[Range(0,6)]
    //public int levelOfDetail;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    protected override void OnValidate() 
    {
        if (mapWidth < 1)
        mapWidth = 1;

        if (mapHeight < 1)
        mapHeight = 1;

        if (lacunarity < 1)
        lacunarity = 1;

        if (octaves < 1)
        octaves = 1;

        base.OnValidate();
    }
}
