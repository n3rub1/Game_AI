using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 10;
    float automaticHealthGenTime = 5.0f;
    int minEffectScale = 2;
    int maxEffectScale = 4;
    public GameObject effectHitPrefab;
    public GameObject lifeRegenPrefab;
    public Vector3 additionalPosition = new Vector3(0f, 2f, 0f);

    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (health < 10)
        {
            automaticHealthGenTime -= Time.deltaTime;
        }

        if (automaticHealthGenTime <= 0)
        {
            IncreaseHealth();
            automaticHealthGenTime = 5.0f;
        }
    }

    public void ReduceHealth()
    {
        if (health > 1)
        {
            GameObject effect = Instantiate(effectHitPrefab, transform.position + additionalPosition, transform.rotation);
            Vector3 scaleFactor = new Vector3(Random.Range(minEffectScale, maxEffectScale), Random.Range(minEffectScale, maxEffectScale), Random.Range(minEffectScale, maxEffectScale));
            effect.transform.localScale = scaleFactor;

            health--;
        }
    }

    void IncreaseHealth()
    {
        Instantiate(lifeRegenPrefab, transform.position + additionalPosition, transform.rotation);
        health++;
    }
}

