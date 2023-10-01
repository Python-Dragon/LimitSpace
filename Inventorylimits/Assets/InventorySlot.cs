using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySlot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public int x = 0;
    public int y = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (GetComponentInParent<InventoryManager>().markOccupied(x, y, coll.gameObject))
        {
            Debug.Log("on trigger enter");
            spriteRenderer.color = Color.green;

        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (GetComponentInParent<InventoryManager>().isOccupied(x, y))
        {
            spriteRenderer.color = Color.green;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GetComponentInParent<InventoryManager>().isOccupied(x, y, other.gameObject))
        {
            spriteRenderer.color = originalColor;
            GetComponentInParent<InventoryManager>().clearSpot(x, y);
        }

    }
}
