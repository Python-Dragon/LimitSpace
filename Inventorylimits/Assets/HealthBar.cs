using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public GameObject origin;
    private playerMove health;
    private int curHealth;
    private int hurt;
    public GameObject heart;
    GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        hurt = 0;
        health = player.GetComponent<playerMove>();
        health.healthBar = this;

        hearts = new GameObject[4];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] =Instantiate(heart, new Vector2(origin.transform.position.x + i + 1, origin.transform.position.y), Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        curHealth = 4 - health.health;
    }
    public void Damage (int dam)
    {
        for(int i = 0; i < dam; i++)
        {
            Destroy(hearts[hearts.Length - 1 - i - hurt]);
        }
        hurt += dam;
    }
}
