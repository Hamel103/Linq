using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public bool isAlive;
    public bool isPoisoned;
    public string status;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
        IsPoisoned();

    }

    private void IsDead()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }

    private void IsPoisoned()
    {
        if (status == "Poisoned")
        {
            isPoisoned = true;
        }
    }
}
