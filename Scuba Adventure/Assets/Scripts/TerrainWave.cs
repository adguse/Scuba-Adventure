using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainWave : MonoBehaviour
{
    private new Terrain terrain;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
    }

    private void Update()
    {
    }
}
