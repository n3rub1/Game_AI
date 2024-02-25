using UnityEngine;

/*
    This class is used to keep track and control enemy health.
 */
public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    bool healing = false;
    public GameObject healingPrefab;
    Vector3 additionalPosition = new Vector3(0f, 2f, 0f);
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

        Instantiate(healingPrefab, transform.position + additionalPosition, transform.rotation);
        health++;
        if (health == 10)
        {
            healing = false;
        }
    }

}
