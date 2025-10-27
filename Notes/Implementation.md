___
<sup>Implementation of Noise Texture Map generator</sup>

#### Components of Implementation :

We need to three scripts for the proper implementation of the Perlin noise Texture Generator.

- [[Noise.cs V1]] : This file is custom C# class for making a method to generate 2D array containing the Perlin Values, also called the Noise Map.
- [[MapGenerator.cs V1]] : This script generates the texture map for the plane by leveraging the previously built method in "Noise.cs".
- [[MapDisplay.cs V1]] : This script simply applies the texture on the Plane in the scene.

##### 🏷️ Tags :
#CG/theory 