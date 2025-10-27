#CG/code #NTCC/Iteration-1
___
#### Dissection:

```cs
public static float[,] GenerateNoiseMap(int maxWidth, int maxHeight, float scale){}
```

This method will be used to generate the noise maps, it is made to be static so that it can be used without initiating a separate object for it, as it returns the whole array and that's what we are here for.

```cs
if (scale <= 0) // scale for the detail of the noise generated.
        {
            scale = 0.0001f;
        }
```

This is written to ensure the scale never becomes zero or less than zero so that we don't end up with an inverted terrain.

Scale is responsible for the zoom-in level of the generated texture.

```cs
        for (int x = 0; x < maxWidth; x++) // Sample generation for the Perlin 
        {                                  // Noise function
            float sampleX = x / scale;
            for (int y = 0; y < maxHeight; y++)
            {
                float sampleY = y / scale;

                float perlineValue = Mathf.PerlinNoise(sampleX, sampleY); 
                noiseMap[x, y] = perlineValue;
            }
        }


        return noiseMap;
    }
```

We use nested for loop while gradually increasing the value of the counter and giving it in as a seed for the pre-implemented Perlin noise function in Mathf.lib.

As the steps are gradual the noise generated appears more organic and smooth.
 