#CG/code #NTCC/Iteration-3 
___
```cs
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawTexture(Texture2D texture)
    {
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
```

Now the DrawNoise function is now modified into DrawTexture as it now only draws the texture to the plane because now we have separate functions for drawing the textures.