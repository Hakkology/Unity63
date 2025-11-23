using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTimeOrnekleri : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }
}

public class TimeCooldown : MonoBehaviour
{
    private float nextFireTime = 0f;
    public float fireRate = 1f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Debug.Log("Ateþ edildi!");
            nextFireTime = Time.time + fireRate;
        }
    }
}

public class SlowMotion : MonoBehaviour
{
    float maxStamina = 100;
    float currentStamina;

    private void Start()
    {
        currentStamina = maxStamina;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentStamina > 0)
        {
            Time.timeScale = 0.2f;
            currentStamina -= Time.deltaTime * 10;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            currentStamina += Time.deltaTime * 3;
        }
    }
}

public class LifeCycleExample : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable: Obje aktif oldu.");
    }

    private void Start()
    {
        Debug.Log("Start: Obje sahneye giriþte bir kez çalýþtý.");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable: Obje pasif hale getirildi.");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy: Obje tamamen yok edildi.");
    }
}


public class FinderExample : MonoBehaviour
{
    private PlayerRunnerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerRunnerController>();
        Debug.Log("Bulunan oyuncu: " + player.name);
    }
}

public class TagFinder : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Enemy").transform;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}