using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsansiMonoBehaviour : MonoBehaviour
{
    Insansi insan1;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position.x = 5;

        //insan1 = new Insansi
        //{
        //    boy = 1.72f,
        //    yas = 37,
        //    isim = "Hakan",
        //    soyisim = "Yildiz",
        //    sacRengi = Color.cyan,
        //};

        insan1 = new Insansi("Hakan", "Yýldýz");
        insan1.boy = 1.72f;
        insan1.sacRengi = Color.cyan;
        //insan1.yas = 37;
        insan1.boy = 1.82f;

        insan1.YasGirisi(37);
        insan1.PrintInsanUgrastirmaBeni();

        Insansi insan2 = new Insansi("Arjin", "Baltaþ")
        {
            boy = 1.80f,
            //yas = 19,
            sacRengi = Color.magenta,
        };

        insan2.YasGirisi(19);
        insan2.PrintInsanUgrastirmaBeni();

        Insansi insan3 = new Insansi("Dila", "Kýzýlgöz")
        {
            boy = 1.61f,
            //yas = 14,
            sacRengi = Color.green,
        };

        insan3.YasGirisi(14);
        insan3.PrintInsanUgrastirmaBeni();

        //transform.Translate();

        Kedisi kedi1 = new Kedisi()
        {
            isim = "Kömür",
            yas = 3,
            korumaci = false,
            agirlik = 5,
            tur = "Scottish",
            renk = Color.black,
        };

        kedi1.PrintHayvanUgrastirmaBeni();

        Kopeksi kopek1 = new Kopeksi()
        {
            isim = "Ateþ",
            yas = 2,
            korumaci = true,
            sahipli = true,
            agirlik = 5,
            tur = "Labrador",
            renk = Color.black,
            insan =insan3,
        };

        kopek1.PrintHayvanUgrastirmaBeni();

        Kopeksi kopek2 = new Kopeksi()
        {
            isim = "Çýtýr",
            yas = 9,
            korumaci = true,
            sahipli = false,
            agirlik = 7,
            tur = "Rus Finosu",
            renk = Color.white,
        };

        kopek2.PrintHayvanUgrastirmaBeni();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
