using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    public float speed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;

        // Move the GameObject using Rigidbody2D (if available)
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.velocity = movement;
        }
        else
        {
            // If you're not using Rigidbody2D, use Transform for movement
            transform.Translate(movement);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("on mouse down");
        // Calculate the offset between the click point and the object's position.
        offset = (Vector2)transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update the object's position based on the mouse movement.
            Vector2 targetPos = GetMouseWorldPos() + offset;
            transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        }
    }

    private Vector2 GetMouseWorldPos()
    {
        // Get the mouse position in screen coordinates and convert it to world coordinates.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return (Vector2)Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }


}
