using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Noise Inputs")]
    [SerializeField] int mapHeight;
    [SerializeField] int mapWidth;
    [SerializeField] float scale;
    [SerializeField] int seed;
    [SerializeField] float lacunarity;
    [Range(0, 1)]
    [SerializeField] float persistance;
    [SerializeField] Vector2 offset;
    [SerializeField] int octaves;
    [Header("Config")]
    [SerializeField] MapDisplay display;
    [SerializeField] public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, scale, octaves, seed, lacunarity, persistance, offset);
        display.DrawNoiseMap(noiseMap);
    }

    void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}
