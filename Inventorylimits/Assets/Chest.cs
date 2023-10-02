using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    int itemChosen;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject spawn;
    public GameObject master;
    public ClickMaster masterAct;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        master = GameObject.FindGameObjectWithTag("Master");
        masterAct = master.GetComponent<ClickMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        Debug.Log(DistanceTo(masterAct.curTurn));
        if(DistanceTo(masterAct.curTurn) < 1.5)
        {
            itemChosen = Random.Range(0, 6);
            switch (itemChosen)
            {
                case 0:
                    Instantiate(item1, spawn.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(item2, spawn.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(item3, spawn.transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(item4, spawn.transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(item5, spawn.transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(item6, spawn.transform.position, Quaternion.identity);
                    break;
                default:
                    Debug.Log("I Should Not Be Here");
                    break;
            }
            masterAct.Act();
            Destroy(this.gameObject);
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
