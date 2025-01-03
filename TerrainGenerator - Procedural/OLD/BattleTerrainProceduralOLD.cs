using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MeshFilter))]
public class BattleTerrainProceduralOLD : MonoBehaviour
{
        Mesh mesh;
        Color[] Colors;
        public Gradient gradient;
        Vector3[] vertices;
        int[] triangles;
        public int xSize;
        public int zSize;

        float minTerrainHeight;
        float maxTerrainHeight;
        
        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            
        }

        void Update() {
            CreateShape();
            UpdateMesh();
        }

        void CreateShape()
        {
            vertices = new Vector3[(xSize + 1) * (zSize + 1)];

            for (int i = 0,a = 0; a <= zSize; a++)
            {
                for (int b = 0; b <= zSize; b++)
                {
                    float y = Mathf.PerlinNoise(b * .3f, a * .3f) * 1.5f;
                    vertices[i] = new Vector3(b, y, a);

                    if (y > maxTerrainHeight)
                        maxTerrainHeight = y;

                    if(y < minTerrainHeight)
                        minTerrainHeight = y;

                    i++;
                }
            }

            triangles = new int[xSize * zSize * 6];

            int vert = 0;
            int tris = 0;

            
            for (int z = 0; z < zSize; z++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    triangles[tris + 0] = vert + 0;
                    triangles[tris + 1] = vert + xSize + 1;
                    triangles[tris + 2] = vert + 1;
                    triangles[tris + 3] = vert + 1;
                    triangles[tris + 4] = vert + xSize + 1;
                    triangles[tris + 5] = vert + xSize + 2;

                    vert++;
                    tris += 6;

                }
                vert++;
            }
            Colors = new Color[vertices.Length];

            for (int i = 0,z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= zSize; x++)
                {
                    float Height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                    Colors[i] = gradient.Evaluate(Height);
                    i++;
                }
            }


        }

        void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.colors = Colors;

            mesh.RecalculateNormals();
        }
}
