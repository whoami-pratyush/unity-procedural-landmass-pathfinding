#CG/code #NTCC/Iteration-6
___

#### Dissection:
```cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour
{
    private Grid _grid; // Grid refrence

    public void FindPath(Node startPos,Node endPos, Grid grid) // start node and target node are passed
    {
        Node startNode = startPos;
        Node targetNode = endPos;
        _grid = grid;

        List<Node> openSet = new List<Node>(); // list for the node yet to be calculated
        HashSet<Node> closedSet = new HashSet<Node>(); // list of node that are calculated
        openSet.Add(startNode);
```

- Initiation of the A* algorithm

```cs

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }
```

- here we loop through the openset to find the node with least f cost and if the f cost is same we go for least h cost node.

```cs

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }
```

- if we find the desired node we add it to close list as we calculated its fcost gcost and hcost.

```cs

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }
```

- now we get the neighbor of the node and see if the are in already computed nodes set or if they are walkable or not.
- if yes we skip that neighbor node.

```cs

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour) + neighbour.getMovePenalty();
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }
```

- Else we calculate the neighbors cost by adding the node.gcost, the distance cost and movement weight
- Then the node is assigned as the parent to the new neighbour.
- in the end the neighbour is added to the openset.

```cs
    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        _grid.path = path;

    }
```

- When we find the target node we retrace the path to determine the shortest economical path from the target node to start node.

```cs
    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
```

- Function to determine the heuristic value or distance between any 2 nodes.