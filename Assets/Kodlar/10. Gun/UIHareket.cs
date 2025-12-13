using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHareket : MonoBehaviour
{
    public RectTransform uiPanel; // Hareket ettirilecek UI paneli
    public float moveSpeed = 100f; // Hareket hızı (piksel/saniye)

    void Start()
    {
        StartCoroutine(ClosePanel());
    }

    IEnumerator ClosePanel()
    {
        float targetPositionX = Screen.width; // Ekran genişliği kadar sağa doğru hareket edecek
        float currentPositionX = uiPanel.anchoredPosition.x;

        while (currentPositionX < targetPositionX)
        {
            // UI panelini sağa doğru hareket ettir
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);

            currentPositionX = newX;

            yield return null; // Bir sonraki kareyi bekle
        }

        // Hareket tamamlandığında paneli devre dışı bırak
        uiPanel.gameObject.SetActive(false);
    }
    
    IEnumerator OpenPanel()
    {
        // Başlangıç pozisyonunu ekranın dış sağ tarafına ayarla
        float startPositionX = Screen.width + uiPanel.rect.width / 2; // Ekranın dışından başla
        float targetPositionX = Screen.width / 2; // Ekranın ortasına taşı
        uiPanel.anchoredPosition = new Vector2(startPositionX, uiPanel.anchoredPosition.y); // İlk pozisyonu ayarla

        // Aktif etmeden önce paneli doğru başlangıç noktasına koy
        uiPanel.gameObject.SetActive(true);

        // Paneli ekranın ortasına kaydır
        while (uiPanel.anchoredPosition.x > targetPositionX)
        {
            float newX = Mathf.MoveTowards(uiPanel.anchoredPosition.x, targetPositionX, moveSpeed * Time.deltaTime);
            uiPanel.anchoredPosition = new Vector2(newX, uiPanel.anchoredPosition.y);
            yield return null;
        }
    }

}

public class DialogueElement
{
    DialogueElement previousNode;
    string name;
    string description;
    List<DialogueElement> nextNode;
}