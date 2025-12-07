using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunnerController : MonoBehaviour
{
    private float hiz;
    public float ileriHiz = 5;
    public float ileriKosmaHiz = 8;
    public int kulvarMesafesi = 4;

    private int mevcutKulvar = 0;
    
    private PlayerScoreController scoreController;
    private PlayerCanController canController;
    private PlayerTimerController timerController;
    private PlayerStaminaController staminaController;


    private void Awake() 
    {
        scoreController = GetComponent<PlayerScoreController>();
        canController = GetComponent<PlayerCanController>();
        timerController = GetComponent<PlayerTimerController>();
        staminaController =GetComponent<PlayerStaminaController>();
        hiz = ileriHiz;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * hiz * Time.deltaTime);

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            hiz = ileriKosmaHiz;
            staminaController.UpdateStamina(false);
        }
        else
        {
            hiz = ileriHiz;
            staminaController.UpdateStamina(true);
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
            scoreController.PuanArtir(10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Engel")
        {
            // Destroy(gameObject);
            timerController.IncreaseTimer();
            CheckGame();
            Destroy(other.gameObject);
        }
    }

    private void CheckGame()
    {
        int currentCan = canController.GetCan();
        if (currentCan > 1)
        {
            canController.UpdateCan(-1);
        }
        else
        {
            GUIController.Instance.OpenEndGamePanel();
        }
    }
}
