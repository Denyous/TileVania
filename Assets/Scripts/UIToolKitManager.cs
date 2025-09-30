using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIToolKitManager : MonoBehaviour
{
    private Button playButton;
    private Button optionsButton;
    private Button quitButton;

    void Awake()
    {
        // UIDocument içindeki root element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // UI Builder'da verdiğin "Name" değerleriyle butonları bul
        playButton = root.Q<Button>("PlayButton");
        optionsButton = root.Q<Button>("OptionsButton");
        quitButton = root.Q<Button>("QuitButton");

        // Eventler bağla
        if (playButton != null)
            playButton.clicked += OnPlayClicked;

        if (optionsButton != null)
            optionsButton.clicked += OnOptionsClicked;

        if (quitButton != null)
            quitButton.clicked += OnQuitClicked;
    }

    private void OnPlayClicked()
    {
        Debug.Log("Play button pressed!");
        // İlk leveli yükle (Scene adını kendi projenle değiştir)
        SceneManager.LoadScene(1);
    }

    private void OnOptionsClicked()
    {
        Debug.Log("Options button pressed!");
        // Burada options ekranını açabilirsin
        // Örn: başka bir UIDocument aktif et veya yeni scene yükle
    }

    private void OnQuitClicked()
    {
        Debug.Log("Quit button pressed!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
