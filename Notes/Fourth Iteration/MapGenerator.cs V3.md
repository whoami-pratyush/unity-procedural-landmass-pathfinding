#CG/code #NTCC/Iteration-4 
___
#### Dissection:
```cs
 public enum DrawMode
    {
        NoiseMap,
        ColorMap
        Mesh
    };

    [SerializeField] private DrawMode drawMode;
    [SerializeField] private MapDisplay display;
    [SerializeField] public bool autoUpdate;
    [Header("Terrain Modification")]
    [SerializeField] AnimationCurve curve;
    [SerializeField] private float heightMult;
    [SerializeField] private TerrainType[] regions;

    public void GenerateMap()
        {
            display.DrawTexture(TextureGenerator.GenerateColorMap(noiseMap, regions));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateMeshData(noiseMap, curve, heightMult), TextureGenerator.GenerateColorMap(noiseMap, regions));
        }
    }
```

Addition of new enum with related conditional statement.