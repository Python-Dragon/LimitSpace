using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    int[,] inventory = new int[3, 3];
    public static void ClearArray(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);
        int count = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                matrix[row, col] = 0;
            }
        }

    }
    public static int CountElementsWithID(int[,] matrix, int targetID)
    {
        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);
        int count = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                if (matrix[row, col] == targetID)
                {
                    count++;
                }
            }
        }

        Debug.Log("Count is " + count);
        return count;
    }

    public void clearSpot(int x, int y)
    {
        inventory[x, y] = 0;
    }

    public bool isOccupied(int x, int y)
    {
        return inventory[x, y] != 0;
    }

    public bool isOccupied(int x, int y, GameObject item)
    {
        return inventory[x, y] == item.GetComponent<DraggableWeapon>().id;
    }

    public bool markOccupied(int x, int y, GameObject item)
    {
        Debug.Log("Marking: x = " + x + ", " + y + ":  " + item.GetComponent<DraggableWeapon>().size + " --> " + item.GetComponent<DraggableWeapon>().id);
        Debug.Log("Current Inventory at x = " + x + ", " + y + " = " + inventory[x, y]);
        if (inventory[x, y] == 0)
        {   
            inventory[x, y] = item.GetComponent<DraggableWeapon>().id;
            if (CountElementsWithID(inventory, item.GetComponent<DraggableWeapon>().id) == item.GetComponent<DraggableWeapon>().size)
            {
                // mark weapon as not movable
                Debug.Log("No longer movable");
                item.GetComponent<DraggableWeapon>().setMovable(false);
                //item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                //item.GetComponent<Rigidbody2D>().mass = 10000f;
            }
            return true;
        }

        return false;

        
    }
    // Start is called before the first frame update
    void Start()
    {
        ClearArray(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
