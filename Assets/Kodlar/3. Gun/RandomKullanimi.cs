using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKullanimi : MonoBehaviour
{
    public GameObject engelPrefab;       // Engelin prefab referansý
    public Transform oyuncu;             // Oyuncunun transformu
    public float kulvarMesafesi = 2f;    // Kulvarlar arasý x mesafesi
    public float maxZMesafesi = 200f;    // Engellerin yerleþtirileceði son Z noktasý
    public float minAralik = 6f;         // Engeller arasý minimum mesafe
    public float maxAralik = 12f;        // Engeller arasý maksimum mesafe

    void Start()
    {
        // Ýlk engel oyuncudan 10 birim önde baþlasýn
        float mevcutZ = oyuncu.position.z + 10f;

        // Engeller max Z mesafesine ulaþana kadar üret
        while (mevcutZ < maxZMesafesi)
        {
            // Rastgele kulvar seç (-1 = sol, 0 = orta, 1 = sað)
            int kulvar = Random.Range(-1, 2);

            // X pozisyonunu kulvara göre hesapla
            float xPozisyonu = kulvar * kulvarMesafesi;

            // Spawn noktasý (X, Y, Z)
            Vector3 spawnNoktasi = new Vector3(xPozisyonu, 0.5f, mevcutZ);

            // Yeni engel oluþtur
            Instantiate(engelPrefab, spawnNoktasi, Quaternion.identity);

            // Sonraki engel için Z mesafesini rastgele artýr
            mevcutZ += Random.Range(minAralik, maxAralik);
        }
    }
}
