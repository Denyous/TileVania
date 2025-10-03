using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject WarningText;
    
    
    void Start()
    {
        
    }

    public void PlayOnClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitOnClicked()
    {
        Application.Quit();
    }

    public void ReadOnClicked()
    {
        WarningText.SetActive(true);
    }


    public void BackButtonOnClicked()
    {
        WarningText.SetActive(false);
    }

}
