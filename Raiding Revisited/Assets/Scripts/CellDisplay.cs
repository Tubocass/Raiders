using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDisplay : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetImage(Sprite image)
    {
        spriteRenderer.sprite = image;
    }
}
