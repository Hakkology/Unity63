using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuGUIController : MonoBehaviour {
    
    protected Tween currentTween;

    [SerializeField] protected float transitionDuration = 0.25f;
    [SerializeField] protected Ease transitionEase = Ease.OutCubic;

    public static MenuGUIController Instance;
    public CanvasGroup menu;
    public CanvasGroup credits;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start() {
        OpenPanel(menu);
        CloseCredits();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RunnerGame");
    }

    public void OpenCredits()
    {
        OpenPanel(credits);
    }

    public void CloseCredits()
    {
        ClosePanel(credits);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenPanel(CanvasGroup panel)
    {
        currentTween?.Kill();
        // IsOpen = true;
        // SoundController.RequestSound(SoundID.ButtonClick);
        panel.gameObject.SetActive(true);
        currentTween = panel.DOFade(1f, transitionDuration)
            .SetEase(Ease.InBounce)
            .SetUpdate(true)
            .OnStart(() =>
            {
                panel.interactable = true;
                panel.blocksRaycasts = true;
            });
    }

    public void ClosePanel(CanvasGroup panel)
    {
        currentTween?.Kill();
        // IsOpen = false;
        currentTween = panel.DOFade(0f, transitionDuration)
            .SetEase(Ease.InOutBack)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                panel.interactable = false;
                panel.blocksRaycasts = false;
                panel.gameObject.SetActive(false);
            });
    }
}