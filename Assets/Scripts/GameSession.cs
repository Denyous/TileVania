using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] public int playerLives = 3;


    void Awake()
    {
        int numberofSession = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;

        if (numberofSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
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
            ResetSession();

        }


    }

    

    private void TakeLife()
    {
        playerLives--;
        int indexofCurrentScene = SceneManager.GetActiveScene().buildIndex;
       
        SceneManager.LoadScene(indexofCurrentScene);
    }

    private void ResetSession()
    {
        
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

  



}