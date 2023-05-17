using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AutoTileTexture : MonoBehaviour
{
    public Vector2 tilingFactor = new Vector2(1, 1);

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTextureScale = new Vector2(transform.localScale.x * tilingFactor.x, transform.localScale.y * tilingFactor.y);
    }
}
