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
