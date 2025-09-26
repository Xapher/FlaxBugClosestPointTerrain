using System;
using System.Collections.Generic;
using FlaxEngine;

namespace VoronoiComputeTerrain;

/// <summary>
/// ClosestPointOnSpline Script.
/// </summary>
public class ClosestPointOnSpline : Script
{

    [Serialize, ShowInEditor]
    Terrain t;

    [Serialize, ShowInEditor]
    Spline s;

    [Serialize, ShowInEditor]
    int steps = 256;


    Vector3 tempPoint;
    /// <inheritdoc/>
    public override void OnStart()
    {
        // Here you can add code that needs to be called when script is created, just before the first game update
        for (int i = 0; i < steps; i++) 
        {
            PrefabManager.SpawnPrefab(Content.Load<Prefab>("Content/Prefab/Cube.prefab"), s.GetSplinePoint((float)i / steps)).Name = "SplinePointBox: " + i;
        }



        for (int i = 0; i < steps; i++)
        {
            t.ClosestPoint(s.GetSplinePoint((float)i / steps), out tempPoint);
            PrefabManager.SpawnPrefab(Content.Load<Prefab>("Content/Prefab/Cube.prefab"), tempPoint).Name = "ClosestPointBox: " + i;
        }
    }

}
