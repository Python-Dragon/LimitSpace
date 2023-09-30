using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool isMoving = false;
    public int health;
    public GameObject master;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("dies");
            Destroy(this.gameObject);
            
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(master.GetComponent<ClickMaster>().lastClicked);
            master.GetComponent<ClickMaster>().lastClicked.gameObject.GetComponent<playerMove>().health--;
        }
    }
    void OnMouseDown()
    {
        isMoving = true;
        master.GetComponent<ClickMaster>().lastClicked = this.gameObject.GetComponent<Collider2D>();

    }
    float distanceTo(GameObject gameObject)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = this.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
}
