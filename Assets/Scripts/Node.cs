using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 _worldPos;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    // Add constructor
    public Node(Vector3 worldPos, int x, int y)
    {
        _worldPos = worldPos;
        gridX = x;
        gridY = y;
        walkable = true; // default to walkable
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}