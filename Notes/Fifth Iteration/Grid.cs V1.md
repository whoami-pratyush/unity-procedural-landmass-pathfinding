#CG/code #NTCC/Iteration-5 
___
#### Dissection:

```cs
using UnityEngine;
using System;

public class Grid : MonoBehaviour
{
    public Node[,] grid;
    public int gridX;
    public int gridY;

    public void CreateGrid(float[,] noiseMap, AnimationCurve curve, float _heightmult, TerrainType[] region)
```

- The Create grid function takes the information from the noiseMap itself, hence aligns one to one with the generated landmass.

```cs
    {
        gridX = noiseMap.GetLength(0);
        gridY = noiseMap.GetLength(1);

        float topLeftX = (gridX - 1) / -2f;
        float topLeftY = (gridY - 1) / 2f;

        grid = new Node[gridX, gridY];

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                grid[x, y] = new Node();
                grid[x, y].pos = new Vector3(topLeftX + x, curve.Evaluate(noiseMap[x, y]) * _heightmult, topLeftY - y);

            }
        }

```

Here we are setting height and location of the nodes created.

```cs

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < region.Length; i++)
                {
                    if (currentHeight <= region[i].height)
                    {
                        if (region[i].buildingCost < 9999)
                        {
                            grid[x, y].walkable = true;
                        }
                        else
                        {
                            grid[x, y].walkable = false;
                        }
                        break;
                    }
                }
            }
        }

    }
}

```

Here we are setting the nodes state on either walkable = true or walkable = false.