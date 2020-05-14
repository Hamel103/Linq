using System.Collections;
using System.Collections.Generic;
using System.Linq;                      // Need to include this
using UnityEngine;

public class Player : MonoBehaviour
{
    private Enemy nearestEnemy;
    private Enemy[] allEnemies;

    private int turnCounter;

    // Start is called before the first frame update
    void Start()
    {
        allEnemies = FindObjectsOfType<Enemy>();

        turnCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }

    void PlayerInputs()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            TurnUpdater();

            nearestEnemy.health -= 20;

            turnCounter++;
            Debug.Log("Turn Number: " + turnCounter);
        }
    }

    private void TurnUpdater()
    {
        nearestEnemy = FindNearestEnemy();
        nearestEnemy.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        GetEnemiesPoisoned();

        bool anyPoisoned = allEnemies.Any(t => t.isPoisoned);
        bool allAlive = allEnemies.All(t => t.isAlive);

        Debug.Log("All Enemies Alive: " + allAlive);
        Debug.Log("Any Enemies Poisoned: " + anyPoisoned);
    }

    private Enemy FindNearestEnemy()
    {
        return allEnemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).FirstOrDefault();
    }

    private void GetEnemiesPoisoned()
    {
        var poisonedEnemies = allEnemies.Where(t => t.status == "Poisoned");

        foreach (var e in poisonedEnemies)
        {
            e.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
            e.health -= 10;
        }
    }
}
