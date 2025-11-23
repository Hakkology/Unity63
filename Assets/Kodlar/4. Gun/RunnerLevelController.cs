using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerLevelController : MonoBehaviour
{
    public GameObject engelPrefab;
    public GameObject odulPrefab;

    public Transform oyuncu;

    public float kulvarMesafesi = 3;
    public float maxZMesafesi = 200;
    public float minAralik = 2;
    public float maxAralik = 5;

    void Start()
    {
        Invoke(nameof(SeviyeyiBaslat),5);
    }

    void SeviyeyiBaslat()
    {
        float mevcutZ = oyuncu.position.z + 10;

        while (mevcutZ < maxZMesafesi)
        {
            // nereye koyacaðýz karar ver
            int kulvar = Random.Range(-2, 3);
            float xPozisyonu = kulvar * kulvarMesafesi;
            Vector3 spawnNoktasi = new Vector3(xPozisyonu, 0.5f, mevcutZ);

            // ödül mü engel mi karar ver
            bool odulmu = Random.Range(0, 100) > 60;
            GameObject spawnEdilecekObje;
            if (odulmu)
            {
                spawnEdilecekObje = odulPrefab;
            }
            else
            {
                spawnEdilecekObje = engelPrefab;
            }

            // kübü oluþtur
            Instantiate(spawnEdilecekObje, spawnNoktasi, Quaternion.identity);

            // while ý kurtarmak için 
            mevcutZ += Random.Range(minAralik, maxAralik);
        }
    }
}
