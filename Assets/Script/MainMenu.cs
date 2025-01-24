using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;
    
    [Header("Boutons")]
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    
    [Header("Options")]
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Activation du menu principal
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        
        // Configuration des listeners
        playButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        quitButton.onClick.AddListener(QuitGame);
        
        // Configuration des options
        volumeSlider.onValueChanged.AddListener(SetVolume);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        
        // Charger les préférences sauvegardées
        LoadPreferences();
    }
    
    void StartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainMenuUI.SetActive(false);
        GetComponent<GameStarter>().EnableGameScripts();
    }
    
    void OpenOptions()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }
    
    public void CloseOptions()
    {
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        SavePreferences();
    }
    
    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    
    void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    void SavePreferences()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    void LoadPreferences()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }
}