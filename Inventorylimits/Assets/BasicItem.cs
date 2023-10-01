using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    public int damage;
    public float distance;
    public bool consumable;
    public bool active;
    public GameObject master;
    public ClickMaster masterAct;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        masterAct = master.GetComponent<ClickMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        masterAct.active = this.gameObject;
    }
}
