using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRocks : MonoBehaviour
{
    public GameObject stoneProjectilePrefab;
    Vector3 firin
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*GameObject projectile = Instantiate(stoneProjectilePrefab, transform.position);*/
        }
    }

}


/*using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // Assign this in the inspector with your projectile prefab
    public GameObject projectilePrefab;
    // Speed at which the projectile will be fired
    public float projectileSpeed = 10f;
    // Offset from the character's position to instantiate the projectile
    public Vector3 firingOffset = new Vector3(0, 0, 1);

    void Update()
    {
        // Check for Fire button (default is left ctrl or mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Instantiate the projectile at the character's position plus an offset
        // Quaternion.identity means no rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.TransformDirection(firingOffset), Quaternion.identity);
        // Assuming the projectile has a Rigidbody component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set the velocity of the projectile to make it move forward
            rb.velocity = transform.forward * projectileSpeed;
        }
    }
}*/