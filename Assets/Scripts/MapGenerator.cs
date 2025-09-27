using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        NoiseMap,
        ColorMap,
        Mesh
    };

    [SerializeField] private DrawMode drawMode;
    [SerializeField] public Transform Flag1;

    [Header("Noise Inputs")]

    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;
    [SerializeField] private float scale;
    [SerializeField] private int seed;
    [SerializeField] private float lacunarity;
    [Range(0, 1)]
    [SerializeField] private float persistense;
    [SerializeField] private Vector2 offset;
    [SerializeField] private int octaves;
    [Header("Config")]
    [SerializeField] private MapDisplay display;
    [SerializeField] public bool autoUpdate;
    [Header("Terrain Modification")]
    [SerializeField] AnimationCurve curve;
    [SerializeField] private float heightMult;
    [SerializeField] private TerrainType[] regions;
    [SerializeField] private Grid grid;
    [SerializeField] float gridScale;
    private Node Flagpos;



    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, scale, octaves, seed, lacunarity, persistense, offset);
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.GenerateGrayScaleMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            display.DrawTexture(TextureGenerator.GenerateColorMap(noiseMap, regions));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateMeshData(noiseMap, curve, heightMult), TextureGenerator.GenerateColorMap(noiseMap, regions));
        }

        grid.CreateGrid(noiseMap, curve, heightMult, regions);

        Flagpos = grid.NodeFromWorldPoint(Flag1.position);

        Debug.Log(Flagpos._worldPos);

    }

    void OnDrawGizmos()
    {
        if (grid == null || grid._nodeGrid == null) return;

        foreach (Node n in grid._nodeGrid)
        {
            Gizmos.color = (n.walkable) ? Color.white : Color.red;
            // 0.9f so cubes don't overlap

            if (Flagpos == n)
            {
                Gizmos.color = Color.cyan;
            }
            Gizmos.DrawCube(new Vector3(n._worldPos.x, n._worldPos.y, n._worldPos.z), Vector3.one * 5f);
        }



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
