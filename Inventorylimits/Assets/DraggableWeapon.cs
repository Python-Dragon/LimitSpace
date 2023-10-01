using UnityEngine;

public class DraggableWeapon : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    public int size = 0;
    public bool isMovable = true;
    public int id = 0;

    public void setMovable(bool movable)
    {
        this.isMovable = movable;
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
        if (isDragging && isMovable)
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
