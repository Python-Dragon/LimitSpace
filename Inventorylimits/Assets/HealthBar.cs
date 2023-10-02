using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public GameObject player;
    private playerMove health;
    private int curHealth;
    private int hurt;
    public GameObject heart;
    GameObject[] hearts;
    public GameObject master;
    public ClickMaster masterAct;

    // Start is called before the first frame update
    void Start()
    {
        hurt = 0;
        health = player.GetComponent<playerMove>();
        health.healthBar = this;
        master = GameObject.FindGameObjectWithTag("Master");
        masterAct = master.GetComponent<ClickMaster>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        hearts = new GameObject[4];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] =Instantiate(heart, new Vector2(this.transform.position.x + i + 1, this.transform.position.y), Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        curHealth = 4 - health.health;
        if(masterAct.curTurn.name == player.name)
        {
            Debug.Log("myturn");
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
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
