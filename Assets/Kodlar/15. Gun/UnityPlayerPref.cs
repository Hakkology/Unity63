using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityPlayerPref.LocalizationManager;

public class UnityPlayerPref : MonoBehaviour
{
    // public Dictionary<string, string> = new();
    // Start is called before the first frame update
    // void Start()
    // {
    //     // int, float ve string 
    //     PlayerPrefs.SetInt("HighScore", 100);
    //     PlayerPrefs.SetFloat("Volume", 0.5f);
    //     PlayerPrefs.SetString("PlayerName", "Hakan");
    //     PlayerPrefs.Save(); // Verileri hemen kaydetmek için kullanılır

    //     int highScore = PlayerPrefs.GetInt("HighScore", 0); // Varsayılan değer: 0
    //     float volume = PlayerPrefs.GetFloat("Volume", 1.0f); // Varsayılan değer: 1.0f
    //     string playerName = PlayerPrefs.GetString("PlayerName", "Guest"); // Varsayılan değer: "Guest"

    //     PlayerPrefs.DeleteKey("HighScore");
    //     PlayerPrefs.DeleteAll(); // Tüm verileri siler
    // }

    // [System.Serializable]
    // public class PlayerData
    // {
    //     public string playerName;
    //     public int playerScore;
    // }

    // void Start()
    // {
    //     // JSON Serileştirme
    //     PlayerData playerData = new PlayerData
    //     {
    //         playerName = "Hakan",
    //         playerScore = 100
    //     };

    //     string json = JsonUtility.ToJson(playerData);
    //     Debug.Log("Serialized JSON: " + json);

    //     // JSON Deserialize Etme
    //     string jsonString = "{\"playerName\":\"Hakan\",\"playerScore\":100}";
    //     PlayerData deserializedPlayerData = JsonUtility.FromJson<PlayerData>(jsonString);
    //     Debug.Log("Deserialized Player Name: " + deserializedPlayerData.playerName);
    //     Debug.Log("Deserialized Player Score: " + deserializedPlayerData.playerScore);
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

//     [Serializable]
//     public class SkinData
//     {
//         public List<string> unlockedSkins;
//         public string equippedSkin;
//     }

//     public class SkinSave : MonoBehaviour
//     {
//         private const string KEY = "SKIN_JSON";

//         public void Save()
//         {
//             SkinData data = new SkinData();
//             data.unlockedSkins = new List<string> { "Default", "Knight01" };
//             data.equippedSkin = "Knight01";

//             string json = JsonUtility.ToJson(data);
//             PlayerPrefs.SetString(KEY, json);
//             PlayerPrefs.Save();

//             Debug.Log("Kaydedildi: " + json);
//         }

//         public void Load()
//         {
//             if (PlayerPrefs.HasKey(KEY))
//             {
//                 string json = PlayerPrefs.GetString(KEY);
//                 SkinData data = JsonUtility.FromJson<SkinData>(json);

//                 Debug.Log("Yüklendi: " + data.equippedSkin);
//             }
//         }
//     }
// }

public class LocalizationManager : MonoBehaviour
{
    public enum Language{
        Turkish,
        English
    }
    public static LocalizationManager Instance;

    private Dictionary<string, string> localizedText;
    private string missingTextString = "Localized text not found";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        TextAsset fileData = Resources.Load<TextAsset>(fileName);

        if (fileData != null)
        {
            string dataAsJson = fileData.text;
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;
    }
}

[System.Serializable]
public class LocalizationData
{
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}

public class ExampleUI : MonoBehaviour
{
    public Text welcomeText;
    public Button playButton;
    public Button exitButton;
    public Language currentLanguage;

    void Start()
    {
        SetLanguage(currentLanguage); // Başlangıç dilini enum değerine göre ayarla
    }

    void OnValidate()
    {
        // Editörde enum değeri değiştiğinde güncelle
        SetLanguage(currentLanguage);
    }

    public void SetLanguage(Language language)
    {
        string languageCode = language == Language.English ? "en" : "tr";
        LocalizationManager.Instance.LoadLocalizedText(languageCode);
        UpdateLocalizedText();
    }

    void UpdateLocalizedText()
    {
        welcomeText.text = LocalizationManager.Instance.GetLocalizedValue("welcome_message");
        playButton.GetComponentInChildren<Text>().text = LocalizationManager.Instance.GetLocalizedValue("play_button");
        exitButton.GetComponentInChildren<Text>().text = LocalizationManager.Instance.GetLocalizedValue("exit_button");
    }
}
}