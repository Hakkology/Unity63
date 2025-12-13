using System.Collections;
using UnityEngine;

public class KorutinGiris : MonoBehaviour
{
    WaitForSeconds beklemeSuresi;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BenimKorutin());
    }

    IEnumerator BenimKorutin()
    {
        Debug.Log("Coroutine başladı.");

        // Belirli bir süre bekleyerek işlemi duraklatır
        beklemeSuresi = new WaitForSeconds(2);
        yield return beklemeSuresi;
        
        Debug.Log("2 saniye bekledikten sonra devam etti.");
    }

    int Toplam(int a, int b)
    {
        return a + b;
    }
}
