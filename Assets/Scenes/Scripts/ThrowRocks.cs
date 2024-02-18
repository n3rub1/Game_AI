using UnityEngine;

/*
    This class is used to make the player fire projectiles
 */

public class ThrowRocks : MonoBehaviour
{
    public GameObject stoneProjectilePrefab;
    public AudioClip[] soundClips;
    public float projectileSpeed = 20.0f;
    public Vector3 firingOffset = new Vector3(0, 2f, 1);

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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
            int randomAttackSound = Random.Range(0, soundClips.Length);
            AudioSource.PlayClipAtPoint(soundClips[randomAttackSound], transform.position);

            Vector3 fireDirection = transform.forward;
            rb.velocity = fireDirection * projectileSpeed;
        }
    }
}
