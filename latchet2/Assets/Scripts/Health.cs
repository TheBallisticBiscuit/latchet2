using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP = 100;
    private int hp;
    private bool dead = false;
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && !dead)
        {
            Debug.Log(this.gameObject.name + " Is Dead");            
            dead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
