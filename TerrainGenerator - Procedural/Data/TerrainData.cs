using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TerrainData : UpdatableData
{
    public float uniformScale = 2.5f;
    public bool useFallOffMap;
    [Range(0, 1)]
    public float fallOffPourcent;

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;
}
