using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FallOffGenerator
{
    public static float[,] GenerateFallOffMap(int sizex, int sizey, float fallOffPourcent)
    {
        float[,] map = new float [sizex, sizey];

        for (int i = 0; i < sizex; i++)
        {
            for (int j = 0; j < sizey; j++)
            {
                float x = i / (float)sizex * 2 - 1;
                float y = j / (float)sizey * 2 - 1;

                float value = Mathf.Max (Mathf.Abs (x) * fallOffPourcent, Mathf.Abs (y) * fallOffPourcent);
                map [i, j] = Evaluate(value);
            }
        }
        return map;
    }
    static float Evaluate(float value)
    {
        float a = 3;
        float b = 2.2f;

        return Mathf.Pow(value,a)/(Mathf.Pow(value,a) + Mathf.Pow (b - b * value, a));
    }
}
