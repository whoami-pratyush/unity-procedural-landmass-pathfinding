___
#CG/code #NTCC/Iteration-2 

#### Dissection:
___
```cs
public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octaves, int seed, float lacunarity, float persistance, Vector2 offset)
```

- The new function takes in new arguments, namely
  - **`octave`**: It takes in the number of layers the noise will have.
    These layers are later stacked on each other.
    As the layer increments the detail increments as well.
  
  - **`seed`**: Calculates the random offset given to each octaves.
    Same seed = same results.
    Different seed = different results.
  
  - **`lacunarity`**: Higher the lacunarity higher the details of the terrain.
  
  - **`persistence`**: Factor by which the amplitude of the terrain decreases at each octave
  
  - **`offset`**: Just to produce noise from different sample space of Perlin noise grid.

```cs
{
	float[,] noiseMap = new float[mapWidth, mapHeight];

	System.Random r = new System.Random(seed);
	Vector2[] octaveOffsets = new Vector2[octaves];
	for (int i = 0; i < octaves; i++)
	{
		float offsetX = r.Next(-100000, 100000) + offset.x;
		float offsetY = r.Next(-100000, 100000) + offset.y;
		octaveOffsets[i] = new Vector2(offsetX, offsetY);
	}
```

- Here we are assign random offset to each incrementing Octave.
- Note: ==**`r.Next`** chooses an integer from the given range.==

```cs
	if (scale <= 0)
	{
		scale = 0.0001f;
	}

	float maxNoiseHeight = float.MinValue; // These variable will check the max n 
	float minNoiseHeight = float.MaxValue; // min height

	float halfMapHeight = mapHeight / 2;   //These are so that when we scale we
	float halfMapWidth = mapWidth / 2;     //zoom in the middle while scaling.
```



```cs
	for (int x = 0; x < mapWidth; x++)
	{
		for (int y = 0; y < mapHeight; y++)
		{
			float frequency = 1;
			float noiseHeight = 0;
			float amplitude = 1;

			for (int i = 0; i < octaves; i++)
			{
				float sampleX = (x - halfMapWidth) / scale * frequency + octaveOffsets[i].x;
				float sampleY = (y - halfMapHeight) / scale * frequency + octaveOffsets[i].y;
```

- Here we setup the Sample values as per the Octave number that influences frequency and amplitude.

```cs
				float perlineValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // *2 -1 makes sure the values of perline Noise are between 1 and -1.
				noiseHeight += perlineValue * amplitude;
				amplitude *= persistance;
				frequency *= lacunarity;

			}
			if (noiseHeight > maxNoiseHeight)
			{
				maxNoiseHeight = noiseHeight;
			}
			if (noiseHeight < minNoiseHeight)
			{
				minNoiseHeight = noiseHeight;
			}

			noiseMap[x, y] = noiseHeight;
```

- Finally after applying we increase the frequencies and decrease the amps for upcoming octave.
- After calculating the `noiseHeight` code determines if it is the highest or the lowest height in whole map.
- Note: ==If we wont use `*2-1` to bring the noise values between 1 and -1 the stacking of octave will keep adding positive values and hence there wont be any depth in the terrain.==

```cs
		}
	}
	for (int x = 0; x < mapWidth; x++)
	{
		for (int y = 0; y < mapHeight; y++)
		{
			noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
		}
	}


	return noiseMap;
}
```

- we normalize all noise height values into the `[0,1]` range using `Mathf.InverseLerp`, so the lowest becomes 0 and the highest becomes 1.

#### Result:
___
![[Pasted image 20250919230910.png]]
- **Configurations**

![[Pasted image 20250919232917.png]]