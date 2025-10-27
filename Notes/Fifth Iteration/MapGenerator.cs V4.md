#CG/code #NTCC/Iteration-5 
___

```cs 
    void OnDrawGizmos()
    {
        if (grid == null || grid.grid == null) return;

        foreach (Node n in grid.grid)
        {
            Gizmos.color = (n.walkable) ? Color.white : Color.red;
            Gizmos.DrawCube(new Vector3(n.pos.x * gridScale, n.pos.y, n.pos.z * gridScale), Vector3.one * gridScale); // 0.9f so cubes don't overlap
            Gizmos.DrawCube(new Vector3(n.pos.x, n.pos.y, n.pos.z), Vector3.one * gridScale); // 0.9f so cubes don't overlap
        }
    }
```

Added visual representation of node grid.