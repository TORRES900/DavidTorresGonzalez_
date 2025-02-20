using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{

    [Header("Game Over")]
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private EnemyManager enemyManager;

    public void GameOver()
    {

        panelGameOver.SetActive(true);
        enemyManager.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;

    }

    public void LoadSceneLevel()
    {

        SceneManager.LoadScene(1);

    }
}
