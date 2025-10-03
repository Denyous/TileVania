using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] public int playerLives = 3;
    [SerializeField] private int coinScore = 0;
    [SerializeField] public int boomerangCount = 6;
    [SerializeField] public TextMeshProUGUI liveText;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameoverScreen;
    [SerializeField] GameObject finishScreen;
    AudioManager audioManager;
    



    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        scoreText.text = "Coin: " + coinScore.ToString();
        liveText.text = "Live: " + playerLives.ToString();

    }



    void Awake()
    {
        int numberOfSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;

        if (numberOfSessions > 1)
        {
            Destroy(gameObject); // fazlaysa yok et
        }
        else
        {
            DontDestroyOnLoad(gameObject); // tek olanı koru
        }

    }


    public void PlayerDeathState()
    {

        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            audioManager.PlaySFX(audioManager.gameOver);
            FindObjectOfType<ScenePersist>().DestroyPersist();
            Time.timeScale = 0;
            gameoverScreen.SetActive(true);

        }


    }



    private void TakeLife()
    {
        playerLives--;
        liveText.text = "Live: " + playerLives.ToString();
        int indexofCurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexofCurrentScene);
    }

    public void ResetSession()
    {

        SceneManager.LoadScene(0);
        Destroy(gameObject);
        Time.timeScale = 1;

    }

    public void ScoreUpdate(int amount)
    {
        coinScore = amount + coinScore;
        Debug.Log("Coin : " + coinScore);
        scoreText.text = "Coin: " + coinScore.ToString();
    }


    public void PlayerLiveUpdate()
    {
        playerLives++;
        liveText.text = "Live: " + playerLives.ToString();
    }

    public void FinishGameScreen()
    {
        finishScreen.SetActive(true);
        audioManager.PlaySFX(audioManager.finishGame);
        Time.timeScale = 0;
    }

    public void ReplayButton()
    {

        SceneManager.LoadScene(0);
        finishScreen.SetActive(false);
        Time.timeScale = 1;
    }


}