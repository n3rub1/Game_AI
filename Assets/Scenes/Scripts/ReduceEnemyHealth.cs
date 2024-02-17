using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceEnemyHealth : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public AudioClip[] soundClips;
    public GameObject effectHitPrefab;
    public bool goHealing = false;
    public Vector3 additionalPosition = new Vector3(0f, 1f, 0f);

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            int randomAttackSound = Random.Range(0, 2);
            AudioSource.PlayClipAtPoint(soundClips[randomAttackSound], transform.position);

            GameObject effect = Instantiate(effectHitPrefab, transform.position + additionalPosition, transform.rotation);

            Vector3 scaleFactor = new Vector3(Random.Range(2, 4), Random.Range(2, 4), Random.Range(2, 4));
            effect.transform.localScale = scaleFactor;

            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }

            enemyHealth.ReduceHealth();
        }


    }
}