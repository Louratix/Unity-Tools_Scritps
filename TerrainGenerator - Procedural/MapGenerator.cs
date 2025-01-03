using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum drawMode {noiseMap, Mesh, FallOffMap};
    public drawMode DrawMode;
    public TerrainData terrainData;
    public NoiseData noiseData;
    public Material terrainMaterial;

    float [,] fallOffMap;
    public bool autoUpdate;

    void OnValueUpdated()
    {
        if (!Application.isPlaying)
        {
            DrawMapInEditor();
        }
    }
    void Start() 
    {
        DrawMapInEditor();
    }

    public void DrawMapInEditor() 
    {
        MapDisplay display = FindObjectOfType<MapDisplay> ();
        MapData mapData = GenerateMapData();
        if (DrawMode == drawMode.noiseMap)
        {
            display.DrawTexture(TextureGenerator.textureFromHeightMap(mapData.heightMap));
        } 
        else if (DrawMode == drawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(mapData.heightMap, terrainData.meshHeightMultiplier, terrainData.meshHeightCurve));
        }
        else if (DrawMode == drawMode.FallOffMap)
        {
            display.DrawTexture(TextureGenerator.textureFromHeightMap(FallOffGenerator.GenerateFallOffMap(noiseData.mapWidth, noiseData.mapHeight, terrainData.fallOffPourcent)));
        }
    }

    public MapData GenerateMapData()
    {
        float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(noiseData.mapWidth, noiseData.mapHeight, noiseData.seed, noiseData.noiseScale, noiseData.octaves, noiseData.persistance, noiseData.lacunarity, noiseData.offset);
        fallOffMap = FallOffGenerator.GenerateFallOffMap(noiseData.mapWidth, noiseData.mapHeight, terrainData.fallOffPourcent);
        Color[] colourMap = new Color[noiseData.mapWidth * noiseData.mapHeight];
        for(int y = 0; y < noiseData.mapHeight; y++)
        {
            for(int x = 0; x < noiseData.mapWidth; x++)
            {
                if (terrainData.useFallOffMap)
                {
                    noiseMap[x,y] = Mathf.Clamp01(noiseMap [x,y] - fallOffMap [x, y]);
                }
            }
        }
        return new MapData(noiseMap);
    }

    void OnValidate() 
    {
        if(terrainData != null){
            terrainData.OnValueUpdated -= OnValueUpdated;
            terrainData.OnValueUpdated += OnValueUpdated;
        }
        if(noiseData != null){
            noiseData.OnValueUpdated -= OnValueUpdated;
            noiseData.OnValueUpdated += OnValueUpdated;
        }
    }
}



public struct MapData
{
    public float[,] heightMap;


    public MapData (float[,] heightMap)
    {
        this.heightMap = heightMap;

    }
}