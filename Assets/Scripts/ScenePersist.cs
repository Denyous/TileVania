using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake()
    {
        int numberOfPersist = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;

        if (numberOfPersist > 1)
        {
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject); 
        }
    }

    
    void Start()
    {
        
    }

    public void DestroyPersist()
    {
        Destroy(gameObject);
    }

}
