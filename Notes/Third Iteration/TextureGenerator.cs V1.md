#CG/code #NTCC/Iteration-3 
___
Now as our program expands we need to separate the texture generation from display class to its own script.

This allows use to use 3 separate functions to make our task more modular and understandable.

#### Dissection:
___
```cs
 public static Texture2D GenerateColorMap(float[,] noiseMap, TerrainType[] regions)
 {
     int width = noiseMap.GetLength(0);
     int height = noiseMap.GetLength(1);
     Color[] colorsMap = new Color[width * height];
     for (int y = 0; y < height; y++)
     {
         for (int x = 0; x < width; x++)
         {
             float currentHeight = noiseMap[x, y];
             for (int i = 0; i < regions.Length; i++)
             {
                 if (currentHeight <= regions[i].height)
                 {
                     colorsMap[y * width + x] = regions[i].color;
                     break; // here as soon as it find the pixels with height                                     equal to or less than region's height it breaks the                                function so that it do not progress further
                 }
             }
         }
     }
     return GenerateTexture(colorsMap, width, height);
 }
```

- This new function is similar to the old function that returned gray scaled noise map texture but the key difference is that, we can now define regions with separate colors.

```cs
 public static Texture2D GenerateGrayScaleMap(float[,] noiseMap)
 {
     int width = noiseMap.GetLength(0);
     int height = noiseMap.GetLength(1);
     Color[] colorsMap = new Color[width * height];
     for (int y = 0; y < height; y++)
     {
         for (int x = 0; x < width; x++)
         {
             colorsMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
         }
     }
     return GenerateTexture(colorsMap, width, height);
 }
```

- This the same method we used in [[MapDisplay.cs V1]].

```cs
 public static Texture2D GenerateTexture(Color[] colorMap, int width, int height)
 {
     Texture2D texture = new Texture2D(width, height);
     texture.filterMode = FilterMode.Point;
     texture.wrapMode = TextureWrapMode.Clamp;
     texture.SetPixels(colorMap);
     texture.Apply();
     return texture;
 }
```

- Here we can see few properties of Texture2D type object :
  - Filter Mode : Its there if we need smooth or precise edges( here we are using point that means we are using precise edges ).
  - Wrap Mode :  Its here to tell how the texture behaves when it is extended than its original size.