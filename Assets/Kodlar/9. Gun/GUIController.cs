using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    [SerializeField]
    private CanvasGroup menuGroup;
    [SerializeField]
    private CanvasGroup endGroup;
    public static GUIController Instance;

    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(this);   
        }
    }

    private void Start() 
    {
        ClosePanel(menuGroup);
        ClosePanel(endGroup);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuGroup.alpha == 1)
            {
                Time.timeScale = 1;
                ClosePanel(menuGroup);
            }
            else
            {
                Time.timeScale = 0;
                OpenPanel(menuGroup);
            }

        }
    }

    public void GameMenuButton()
    {
        OpenPanel(menuGroup);
    }

    public void MenuContinueButton()
    {
        Time.timeScale = 1;
        ClosePanel(menuGroup);
    }

    public void MenuExitButton()
    {
        SceneManager.LoadScene("RunnerMenu");
    }

    public void EndRestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RunnerGame");
    }

    public void EndExitButton()
    {
        SceneManager.LoadScene("RunnerMenu");
    }

    public void OpenEndGamePanel()
    {
        OpenPanel(endGroup);
        Time.timeScale = 0;
    }

    public void OpenPanel(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }

    public void ClosePanel(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.interactable = false;
        panel.blocksRaycasts =false;
    }
}