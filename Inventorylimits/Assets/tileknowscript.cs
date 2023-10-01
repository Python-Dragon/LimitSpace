using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileknowscript : MonoBehaviour
{
    public GameObject objectOn;
    public GameObject master;
    bool holder;
    public int tileName;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on mouse click
    void OnMouseDown()
    {
        Debug.Log("Hello");
        objectOn = master.GetComponent<ClickMaster>().curTurn;
        //holder = objectOn.GetComponent<playerMove>().isMoving;
        if (DistanceTo(objectOn) < 6)
        {
            objectOn.GetComponent<Transform>().position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
            master.GetComponent<ClickMaster>().Act();
        }
        



    }
    float DistanceTo(GameObject gameObject)
    {
        Vector2 pos1 = gameObject.transform.position;
        Vector2 pos2 = this.transform.position;
        float distance = Mathf.Sqrt((pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y));
        return distance;
    }
}
