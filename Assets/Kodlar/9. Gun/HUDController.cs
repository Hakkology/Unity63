using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
    
    [SerializeField]
    private TextMeshProUGUI puanText;    

    [SerializeField]
    private TextMeshProUGUI timerText;  

    [SerializeField]
    private TextMeshProUGUI starterText;  

    [SerializeField]
    private Slider staminaSlider;  

    [SerializeField]
    private List<Image> healthImages = new(); // 3 tane resim olucak.




    public static HUDController Instance;

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

    private void Start() {
        starterText.text = "Get Ready!";
        Invoke(nameof(ResetStartText),5);
    }

    public void ResetStartText()
    {
        starterText.text = "";
    }

    public void UpdatePuanText(int puan)
    {
        puanText.text = puan.ToString();
    }

    public void UpdateTimerText(string time)
    {
        timerText.text = time;
    }

    public void UpdateStaminaSlider(float stamina)
    {
        staminaSlider.value = stamina;
    }

    public void UpdateCanImage(int can)
    {
        foreach (var image in healthImages)
        {
            image.gameObject.SetActive(false);
        }

        for (int i = 0; i < can; i++)
        {
            healthImages[i].gameObject.SetActive(true);
        }
    }
}