using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Images")]
    [SerializeField]
    private Image caughtImage;
    [SerializeField]
    private Image wonImage;
    [Header("Fade")]
    [SerializeField]
    private float fadeDuration;
    [SerializeField]
    private float displayImageDuration;

    private float timer;

    public bool IsPlayerAtExit;
    public bool IsPlayerCaught;
    private bool isRestartLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip caughtClip;
    [SerializeField]
    private AudioClip wonClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IsPlayerAtExit)
        {

            Won();

        }else if (IsPlayerCaught)
        {

            Caught();

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("John"))
        {

            IsPlayerAtExit = true;

        }

    }

    private void Won()
    {

        audioSource.clip = wonClip;
        if(audioSource.isPlaying == false)
        {

            audioSource.Play();

        }

        timer = timer + Time.deltaTime;
        wonImage.color = new Color(wonImage.color.r, wonImage.color.g, wonImage.color.b, timer/fadeDuration);

        if(timer > fadeDuration + displayImageDuration)
        {

            Debug.Log("¡He ganado!");
            SceneManager.LoadScene(0);

        }

    }

    private void Caught()
    {

        audioSource.clip = caughtClip;
        if (audioSource.isPlaying == false)
        {

            audioSource.Play();

        }

        timer = timer + Time.deltaTime;
        caughtImage.color = new Color(caughtImage.color.r, caughtImage.color.g, caughtImage.color.b, timer / fadeDuration);

        if (timer > fadeDuration + displayImageDuration)
        {

            Debug.Log("¡He perdido!");
            SceneManager.LoadScene(0);

        }

    }

}
