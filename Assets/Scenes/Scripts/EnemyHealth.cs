using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    public void reduceHealth()
    {
        health--;
    }

    public void increaseHealth()
    {
        health = 10;
    }
}
