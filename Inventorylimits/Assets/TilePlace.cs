using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlace : MonoBehaviour
{
    public GameObject tile;
    public GameObject master;
    public float height;
    public float width;
    public float xoffset;
    public float yoffset;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        int hold = 0;
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                GameObject clones;
                clones = Instantiate(tile, new Vector2((j - xoffset),(i - yoffset)), Quaternion.identity);
                clones.GetComponent<tileknowscript>().tileName = hold;
                hold++;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
