using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public GameObject healingPrefab;

    public void ReduceHealth()
    {
        health--;
    }

    public void IncreaseHealth()
    {
        Instantiate(healingPrefab, transform.position, transform.rotation);
        health++;
    }

    public void MaxHealth()
    {
        health = 10;
    }
}
