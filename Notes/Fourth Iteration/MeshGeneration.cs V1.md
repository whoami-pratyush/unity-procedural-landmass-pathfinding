#CG/code #NTCC/Iteration-4
___

Mesh is a collection of vertices and faces that defines how will the 3D object will form in a 3D space.

We will generate our mesh using this class with the data provided by the Height map we generated using the Perlin noise algorithm.
#### Dissection:
```cs
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateMeshData(float[,] heightMap, AnimationCurve curve, float heightMult) // ? 1
    {
        int mapWidth = heightMap.GetLength(0);
        int mapHeight = heightMap.GetLength(1);

        float topLeftX = (mapWidth - 1) / -2f;
        float topLeftZ = (mapHeight - 1) / 2f;

```

- Here we get out length and breath of the mesh using the dimensions of our height Map
- We need to create the topLeftX and topLeftZ so that the middle items of the mesh stays at (0,0) x and y(z because we are treating z access of unity like y) position. 

```cs  
        MeshData meshData = new MeshData(mapWidth, mapHeight);
        int vertexIndex = 0;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, curve.Evaluate(heightMap[x, y]) * heightMult, topLeftZ - y);

                meshData.uvs[vertexIndex] = new Vector2(x / (float)mapWidth, y / (float)mapHeight); // ? 2

                if (x < mapWidth - 1 && y < mapHeight - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex + mapWidth + 1, vertexIndex + mapWidth);
                    meshData.AddTriangle(vertexIndex + mapWidth + 1, vertexIndex, vertexIndex + 1);
                }

                vertexIndex++;
            }
        }

        return meshData;
    }
}
```

- Here we are assigning the 3D world coordinates to the vertices.
- After making vertex we are adding vertices for the triangle on mesh by using the Addtriangle method.

```cs
public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    int triangleIndex = 0;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles; 
        mesh.uv = uvs;
        mesh.RecalculateNormals(); // ? 3
        return mesh;
    }

}
```

- It is better to collect all the mesh data and then use it create a mesh all at once.
- Hence this class holds all the mesh data and then applies it to the mesh filter we added to our project.
___

- **(1)The use of Animation Curve and Height Multiplier:** The animation curve handles that the 3D mesh's lowest point till a certain  height stays in same level of height.

- **(2)Why the UV map is defined like that?:** The uv index tells the texture that, what percent or fraction of the texture map is covered by which point.

- **(3)Recalculation of the normals:** After the mesh generation we need normal vectors to align properly with our mesh faces so that interaction with shadow and light calculations should match the visual representation.


