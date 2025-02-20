using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{

    [Header("Health")]
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float damageEnemyShell;

    [Header("ProgressBar")]
    [SerializeField]
    private Image lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;

    [Header("GameOver")]
    [SerializeField]
    private GameManagerTanks gameManager;



    private void Awake()
    {

        bigExplosion.Stop();
        smallExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyShell"))
        {

            smallExplosion.Play();
            currentHealth -= damageEnemyShell;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if(currentHealth <= 0.0f)
            {

                bigExplosion.Play();
                Death();

            }

        }

    }

    private void Death()
    {

        gameManager.GameOver();
        Destroy(gameObject, 1.0f);

    }

}
