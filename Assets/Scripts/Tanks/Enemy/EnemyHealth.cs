using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float damagePlayerShell;

    [Header("HealthBar")]
    [SerializeField]
    private Image lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;


    private void Awake()
    {

        bigExplosion.Stop();
        smallExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerShell"))
        {

            smallExplosion.Play();
            currentHealth -= damagePlayerShell;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0.0f)
            {

                bigExplosion.Play();
                Death();

            }

        }

    }

    private void Death()
    {

        Destroy(gameObject, 1.0f);

    }

}
