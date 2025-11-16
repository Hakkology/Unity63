using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test : MonoBehaviour
{
    int maxForDegeri = 10;
    string isim = "Atakaan"; // global deðiþkenler 

    int yas = 15; // 2^32
    uint pozitifyas = 15;

    float foo = 3.22149182891f;
    double bar = 25.56;
    decimal baz;

    bool saldirabiliyormuyum = true;
    bool silahDolduruyor = false;
    public bool DusmanýGorebiliyormuyum;
    void Start()
    {
        int benimYasim = 5;
        string isim2 = "Arda"; // local deðiþken
        // Debug.Log("hello world");
        Debug.Log($"hello {isim}");
        Debug.Log(yas);

        //YasHesapla(benimYasim);

        Debug.Log(isim2);
        Debug.Log(yas);

        foo = foo + 2;
        //yas = yas + foo;

        KarakteriHareketEttir();
        KarakterSeviyeAtla();

        saldirabiliyormuyum = false;
        Debug.Log(saldirabiliyormuyum);

        if (benimYasim > 18)
        {
            //iptal
        }
        else if (benimYasim == 18)
        {
            //iptal
        }
        else if (saldirabiliyormuyum)
        {
            //iptal
        }
        else
        {

        }

        if (silahDolduruyor)
        {
            // baþka bi mantýk
        }

        if (saldirabiliyormuyum)
        {
            Debug.Log("Saldýr dostum.");
        }
        else if (silahDolduruyor)
        {
            Debug.Log("Silah doluyor");
        }
        else
        {
            Debug.Log("Köþeye git ve otur.");
        }

        if (saldirabiliyormuyum && silahDolduruyor)
        {

        }

        if (saldirabiliyormuyum || silahDolduruyor)
        {
            
        }

        int sayac = 0;
        while (sayac < 10)
        {
            sayac++;
            Debug.Log("Atakaan naber.");
        }

        for (int i = 0; i < maxForDegeri; i = i +2)
        {
            Debug.Log("Arda naber.");
        }

       

        //int a = 5 / 0;
    }

    void Update()
    {
        //Debug.Log($"hello {isim}");
        //Debug.Log("hello world");
    }

    void YasHesapla(int yas2)
    {
        yas2 = 14 + 2;
        yas2 = yas2 + 2;
    }

    void SayilariTopla(int sayi1, int sayi2)
    {
        int toplam = sayi1 + sayi2;
        Debug.Log(toplam);
    }

    void KarakteriHareketEttir()
    {

    }

    void KarakterSeviyeAtla()
    {

    }

    void KarakterAtesEt()
    {

    }
}
