using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickEvents : MonoBehaviour
{

    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject countdownText;
    [SerializeField] GameObject finishScreen;

    void Start()
    {
        
    }


    void Update()
    {

    }


    public void PauseButtonOnClick()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }


    public void ResumeButtonOnClick()
    {

        StopAllCoroutines();
        StartCoroutine(ResumeCountdown());
    }

    public void QuitButtonOnClick()
    {
       Application.Quit();
    }

    public void MainMenuOnClicked()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ResumeCountdown()
    {
        
        countdownText.SetActive(true);

        TextMeshProUGUI countdown = countdownText.GetComponent<TextMeshProUGUI>();

        int count = 2;
        while (count > 0)
        {
            countdown.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f); // Time.timeScale = 0 iken bile çalışır
            count--;
        }

        countdown.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);

        countdownText.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f; // oyun devam etsin
    }


    
}
