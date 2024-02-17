using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRocks : MonoBehaviour
{
    public GameObject stoneProjectilePrefab;
    public float projectileSpeed = 20.0f;
    public Vector3 firingOffset = new Vector3(0, 0, 1);
    public AudioClip[] soundClips;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
{

    GameObject projectile = Instantiate(stoneProjectilePrefab, transform.position + firingOffset, transform.rotation);

    Rigidbody rb = projectile.GetComponent<Rigidbody>();

    if (rb != null)
    {
        int randomAttackSound = Random.Range(0, 3);
        AudioSource.PlayClipAtPoint(soundClips[randomAttackSound], transform.position);
        Vector3 fireDirection = transform.forward;
        rb.velocity = fireDirection * projectileSpeed;
    }
}
}
