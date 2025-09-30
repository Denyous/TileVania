using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private int currentSceneIndex;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collect"))
        {
            StartCoroutine("GetToNextScene");
        }
    }


    IEnumerator GetToNextScene()
    {
        yield return new WaitForSecondsRealtime(1);

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().DestroyPersist();
        audioManager.PlaySFX(audioManager.exit);
        SceneManager.LoadScene(nextSceneIndex);
    }
   
}
