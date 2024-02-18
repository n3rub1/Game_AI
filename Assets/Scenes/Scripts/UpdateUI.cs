using UnityEngine;
using TMPro;

/*
    This class is used to display enemy's and player's health on the UI.
 */

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI playerHealthText;
    public EnemyHealth enemyHealth;
    public PlayerHealth playerHealth;

    void Update()
    {

        enemyHealthText.text = "Enemy health: " + enemyHealth.health.ToString();
        playerHealthText.text = "Player health: " + playerHealth.health.ToString();

    }
}
