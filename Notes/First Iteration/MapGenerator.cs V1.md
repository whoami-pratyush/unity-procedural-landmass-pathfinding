#CG/code #NTCC/Iteration-1 
___

```cs
public class MapGenerator : MonoBehaviour
{
    [Header("Noise Inputs")]
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] float scale;
    [Header("Config")]
    [SerializeField] MapDisplay display;
    [SerializeField] public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(width, height, scale);
        display.DrawNoiseMap(noiseMap);
    }
}
```

This script provides a method to actually use the methods of [[Noise.cs V1]] and [[MapDisplay.cs V1]].
 