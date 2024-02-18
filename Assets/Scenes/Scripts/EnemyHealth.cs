using UnityEngine;

/*
    This class is used to keep track and control enemy health.
 */
public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    bool healing = false;
    public GameObject healingPrefab;
    public void ReduceHealth()
    {
        if (!healing && health >= 5)
        {
            health--;
        }
    }

    public void IncreaseHealth()
    {
        healing = true;

        Instantiate(healingPrefab, transform.position, transform.rotation);
        health++;
        if (health == 10)
        {
            healing = false;
        }
    }

}
