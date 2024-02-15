using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    public void ReduceHealth()
    {
        health--;
    }

    public void IncreaseHealth()
    {
        health++;
    }

    public void MaxHealth()
    {
        health = 10;
    }
}
