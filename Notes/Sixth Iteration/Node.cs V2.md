#CG/code #NTCC/Iteration-6 
___
#### Dissection:
```cs
using UnityEngine;

public class Node
{
    public bool walkable; // node state
    public Vector3 _worldPos; // position of node in the 3D environment
    public int gridX; //  position of Node in grid of nodes
    public int gridY;

    public int movementPenalty; // weights of movement
    public int gCost; // move cost
    public int hCost; // heuristic cost
    public Node parent; // previous node
```

```cs
    public Node(Vector3 worldPos, int x, int y)
    {
        _worldPos = worldPos;
        gridX = x;
        gridY = y;
        walkable = true; // default to walkable
    }
```

```cs
    public int getMovePenalty() //getter and setter for the movement weights
    {
        return movementPenalty;
    }
    public void setMovePenalty(int buildingCost)
    {
        movementPenalty = buildingCost;
    }

    public int fCost // function to get the f cost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
```
