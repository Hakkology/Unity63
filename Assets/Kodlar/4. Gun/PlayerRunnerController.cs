using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunnerController : MonoBehaviour
{
    public float ileriHiz = 5;
    public int kulvarMesafesi = 4;

    private int mevcutKulvar = 0;
    private int puan = 0;

    public TextMeshProUGUI puanText;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * ileriHiz * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && mevcutKulvar > -2) 
        {
            mevcutKulvar--;
            KulvarDegistir();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && mevcutKulvar < 2)
        {
            mevcutKulvar++;
            KulvarDegistir();
        }
    }

    private void KulvarDegistir()
    {
        Vector3 yeniPozisyon = new Vector3 (mevcutKulvar * kulvarMesafesi, transform.position.y, transform.position.z);
        transform.position = yeniPozisyon;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Odul")
        {
            puan += 5;
            UpdatePuanText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Engel")
        {
            Destroy(gameObject);
            //Time.timeScale = 0; // oyunu durdurma
            SceneManager.LoadScene("RunnerGame");
        }
    }

    public void PuanArtir(int artirilacakDeger)
    {
        puan += artirilacakDeger;
        UpdatePuanText();
    }

    private void UpdatePuanText()
    {
        puanText.text = "Puan: " + puan;
    }
}
