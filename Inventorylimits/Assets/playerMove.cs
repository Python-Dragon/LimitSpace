using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //public bool isMoving = false;
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
        if(masterAct.active.GetComponent<BasicItem>() != null)
        {
            selected = masterAct.active.GetComponent<BasicItem>();
        }
        Debug.Log("Here");
        if (health <= 0)
        {
            Debug.Log("dies");
            Destroy(this.gameObject);
            
        }
        
    }
    void OnMouseDown()
    {
        
        masterAct.lastClicked = this.gameObject.GetComponent<Collider2D>();
        Debug.Log(DistanceTo(masterAct.lastClicked.gameObject, masterAct.curTurn));
        if (DistanceTo(masterAct.lastClicked.gameObject, masterAct.curTurn) < selected.distance /* && masterAct.lastClicked.gameObject != masterAct.curTurn*/)
        {
            Debug.Log(DistanceTo(masterAct.lastClicked.gameObject, masterAct.curTurn));
            masterAct.lastClicked.gameObject.GetComponent<playerMove>().health -= selected.damage;
            masterAct.actions--;
            if(selected.consumable)
            {
                selected.used = true;
            }
        }


    }
    float DistanceTo(GameObject gameObject)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = this.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
    float DistanceTo(GameObject gameObject, GameObject gM)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = gM.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
}
