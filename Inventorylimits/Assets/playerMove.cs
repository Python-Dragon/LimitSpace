using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public bool isMoving = false;
    public int health;
    public GameObject master;
    public ClickMaster masterAct;
    public BasicItem selected;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        masterAct = master.GetComponent<ClickMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        selected = masterAct.active.GetComponent<BasicItem>();
        if(health <= 0)
        {
            Debug.Log("dies");
            Destroy(this.gameObject);
            
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (distanceTo(masterAct.lastClicked.gameObject, masterAct.curTurn) < selected.distance)
            {
                Debug.Log(masterAct.lastClicked);
                masterAct.lastClicked.gameObject.GetComponent<playerMove>().health -= selected.damage;
                masterAct.actions--;
            }
            
        }
    }
    void OnMouseDown()
    {
        
        isMoving = true;
        masterAct.lastClicked = this.gameObject.GetComponent<Collider2D>();
        

    }
    float distanceTo(GameObject gameObject)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = this.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
    float distanceTo(GameObject gameObject, GameObject gM)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = gM.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
}
