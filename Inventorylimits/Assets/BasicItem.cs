using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    public int damage;
    public float distance;
    public bool consumable;
    public bool acting;
    public bool used;
    public GameObject master;
    public ClickMaster masterAct;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        masterAct = master.GetComponent<ClickMaster>();
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (used)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnMouseUp()
    {
        Console.WriteLine("picking up item");
        masterAct.active = this.gameObject;
        acting = true;
    }
}
