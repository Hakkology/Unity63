using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityKoleksiyonlar : MonoBehaviour
{
    int[] sayilar;
    List<int> sayilarList;

    public List<GameObject> gameObjects;
    public HashSet<GameObject> koleksiyons;
    public Dictionary<string, GameObject> koleksiyonSozlugu;

    public GameObject[] dusmanlar;

    void Start()
    {
        sayilar = new int[5];
        sayilarList = new List<int>();

        sayilar[0] = 10;
        sayilar[1] = 485620;
        sayilar[2] = 485620;
        sayilar[3] = 35;
        sayilar[4] = 0;
        //sayilar[5] = 0;

        sayilar[1] = 45;
        int dizininUzunlugu = sayilar.Length;

        sayilarList.Add(10);
        sayilarList.Add(20);
        sayilarList.Add(30);

        int ilkSayi = sayilarList[0];

        int listeninUzunlugu = sayilarList.Count;
    }

    void Update()
    {
        
    }
}
