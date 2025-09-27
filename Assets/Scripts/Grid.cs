using System;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform Flag1;
    public Node[,] _nodeGrid;
    public Vector3 gridWorldSize;
    public float nodeRadius = 0.5f;
    public int gridX;
    public int gridY;
    public float nodeDiameter;
    public MeshFilter _meshFilter;
    public Mesh _mesh;
    public List<Node> path;

    // Add these variables to store the grid bounds
    private float topLeftX;
    private float topLeftZ;
    private float bottomRightX;
    private float bottomRightZ;

    public void CreateGrid(float[,] noiseMap, AnimationCurve curve, float _heightmult, TerrainType[] region)
    {
        nodeDiameter = 2 * nodeRadius;

        // Get grid dimensions from noise map, not from mesh
        gridX = noiseMap.GetLength(0);
        gridY = noiseMap.GetLength(1);

        // Calculate the actual world bounds of your grid
        topLeftX = (gridX - 1) / -2f * 10f; // Match your *10 scaling
        topLeftZ = (gridY - 1) / 2f * 10f;
        bottomRightX = -topLeftX;
        bottomRightZ = -topLeftZ;

        gridWorldSize.x = Mathf.Abs(bottomRightX - topLeftX);
        gridWorldSize.z = Mathf.Abs(bottomRightZ - topLeftZ);

        _nodeGrid = new Node[gridX, gridY];

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 worldPos = new Vector3((topLeftX / 10f + x) * 10f,
                                              curve.Evaluate(noiseMap[x, y]) * _heightmult,
                                              (topLeftZ / 10f - y) * 10f);

                _nodeGrid[x, y] = new Node(worldPos, x, y);
            }
        }

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < region.Length; i++)
                {
                    if (currentHeight <= region[i].height)
                    {
                        _nodeGrid[x,y].setMovePenalty( region[i].buildingCost);
                        _nodeGrid[x, y].walkable = (region[i].buildingCost < 9999);
                        break;
                    }
                }
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridX && checkY >= 0 && checkY < gridY)
                {
                    neighbours.Add(_nodeGrid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        if (_nodeGrid == null) return null;

        // Convert world position to grid coordinates
        float percentX = (worldPosition.x - topLeftX) / gridWorldSize.x;
        float percentZ = (topLeftZ - worldPosition.z) / gridWorldSize.z;

        percentX = Mathf.Clamp01(percentX);
        percentZ = Mathf.Clamp01(percentZ);

        int x = Mathf.RoundToInt(percentX * (gridX - 1));
        int z = Mathf.RoundToInt(percentZ * (gridY - 1));

        // Ensure we don't go out of bounds
        x = Mathf.Clamp(x, 0, gridX - 1);
        z = Mathf.Clamp(z, 0, gridY - 1);

        return _nodeGrid[x, z];
    }
}