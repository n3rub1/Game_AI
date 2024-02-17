using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{

    float timeBeforeDestroy = 3.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDestroy -= Time.deltaTime;

        if(timeBeforeDestroy <= 0)
        {
            Destroy(gameObject);        }
    }
}
