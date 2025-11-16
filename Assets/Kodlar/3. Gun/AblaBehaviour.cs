using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AblaBehaviour : MonoBehaviour
{
    // TRANSFORM
    public float rotationSpeed = 60f;

    public int lowSpeed = 3;
    public int highSpeed = 5;

    bool crouching = false; // egiliyorum
    bool running = false; // kosuyorum

    float speed;

    public int puan = 0;


    // FIRE
    public int maxAmmo = 7;
    public int remainingAmmo = 20;
    int currentAmmo = 0;
    public TextMeshProUGUI ammoText;

    void Start()
    {
        speed = lowSpeed;
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        HareketEttir();
        Dondur();
        Kosma();
        AtesEt();
        SilahDoldur();
        Zipla();
    }

    void HareketEttir()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position -= transform.forward * Time.deltaTime * speed;
            transform.Translate(-transform.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position -= transform.right * Time.deltaTime * speed;
            transform.Translate(-transform.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += transform.right * Time.deltaTime * speed;
            transform.Translate(transform.right * Time.deltaTime * speed);
        }

        //var yatayAks = Input.GetAxis("Horizontal");
        //var dikeyAks = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(yatayAks * Time.deltaTime * speed, 0, dikeyAks * Time.deltaTime * speed));
    }

    void Kosma()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = highSpeed;
            running = true;
        }
        else
        {
            speed = lowSpeed;
            running = false;
        }
    }

    void AtesEt()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoText();
            Debug.Log("Ateþ açýldý, kalan mermi: " + currentAmmo);
        }
    }

    void SilahDoldur()
    {
        if (Input.GetKeyDown(KeyCode.R) )
        {
            // ya 7 gelecek ya da kalan ne gelecek
            int sonCurrentAmmo = Mathf.Min(maxAmmo, remainingAmmo);
            currentAmmo += sonCurrentAmmo;
            remainingAmmo -= sonCurrentAmmo;
            UpdateAmmoText();

            Debug.Log($"Mermi yenilendi. Þarjör: {currentAmmo}, Yedek: {remainingAmmo}");
        }
    }

    void Dondur()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //transform.rotation *= Quaternion.Euler(-Vector3.up * Time.deltaTime * rotationSpeed);
            transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            //transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * rotationSpeed);
            transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }

    void Zipla()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1)
        {
            transform.position += transform.up * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            puan =+ 5;
            Debug.Log("Suanki puan: " + puan);
        }
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo:" + currentAmmo.ToString();
    }
}
