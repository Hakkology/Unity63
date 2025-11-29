using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiBehaviour : MonoBehaviour
{
    // hareket bölümü
    public float speed = 5.0f;

    // ziplama bölümü
    public float gravity = -10f;
    public float jumpHeight = 2.0f;
    


    // referans 
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded; // yerdemiyim
    private int puan = 0;

    // starttan önce çaðrýlan tek sefer çalýþan metod
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Tek sefer çalýþan metod
    void Start()
    {
        //controller.enabled = false;
        //controller.slopeLimit = 60;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
        //controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        Vector3 totalMove = (move * speed) + velocity;
        controller.Move(totalMove * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    public void AddScore(int eklenecekPuan)
    {
        puan += eklenecekPuan;
    }
}
