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



    private void Start()
    {
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
            FindObjectOfType<ScenePersist>().DestroyPersist();
            ResetSession();

        }


    }



    private void TakeLife()
    {
        playerLives--;
        liveText.text = "Live: " + playerLives.ToString();
        int indexofCurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexofCurrentScene);
    }

    private void ResetSession()
    {

        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ScoreUpdate()
    {
        coinScore++;
        Debug.Log("Coin : " + coinScore);
        scoreText.text = "Coin: " + coinScore.ToString();
    }





}