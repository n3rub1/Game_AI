using UnityEngine;

/*
    This class is used to detect triggers within the enemy's object and deduct health.
 */
public class ReduceEnemyHealth : MonoBehaviour
{
    EnemyHealth enemyHealth;
    int minEffectScale = 2;
    int maxEffectScale = 4;
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
            int randomAttackSound = Random.Range(0, soundClips.Length);
            AudioSource.PlayClipAtPoint(soundClips[randomAttackSound], transform.position);

            GameObject effect = Instantiate(effectHitPrefab, transform.position + additionalPosition, transform.rotation);

            Vector3 scaleFactor = new Vector3(Random.Range(minEffectScale, maxEffectScale), Random.Range(minEffectScale, maxEffectScale), Random.Range(minEffectScale, maxEffectScale));
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