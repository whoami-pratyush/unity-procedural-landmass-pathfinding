#CG/code #NTCC/Iteration-3 
___
#### Dissection:
___
```cs
using UnityEngine;

[System.Serializable] //  this tells unity that it can be placed inside the editor
public struct TerrainType
{

    public string name;
    public float height;
    public Color color;


}

```

Made A struct to define regions and color.