using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on trigger enter");
        spriteRenderer.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Restore the original color when the collider exits the trigger zone
        spriteRenderer.color = originalColor;

    }
}
