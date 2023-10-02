using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMaster : MonoBehaviour
{
    public int turn = 0;
    public GameObject curTurn;
    public int actions = 2;
    public GameObject[] turnOrder;
    public Collider2D lastClicked;
    public GameObject active;
    public List<GameObject> tiles;
    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        lastClicked = null;
        actions = 2;
        turnOrder = GameObject.FindGameObjectsWithTag("Player");
        curTurn = turnOrder[turn % turnOrder.Length];
        active = null;

    }

    // Update is called once per frame
    void Update()
    {
        upTurn();
        
    }
    void upTurn()
    {
        curTurn = turnOrder[turn % turnOrder.Length];
        if(actions <= 0)
        {
            turn++;
            actions = 2;
            if (Random.Range(0, 5) < 1)
            {
                //Debug.Log("Hey Listen");
                Instantiate(chest, tiles[Random.Range(0, 150)].transform.position, Quaternion.identity);

            }
        }
        if(curTurn.GetComponent<playerMove>().dead)
        {
            turn++;
        }
        
    }
     public void Act()
    {
        actions--;
    }


}
