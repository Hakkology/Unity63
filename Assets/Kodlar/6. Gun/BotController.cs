using System;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public string xHareketAnim = "XHareket";
    public string zHareketAnim = "ZHareket";
    public TextMeshProUGUI staminaText;

    public float speed = 5.0f;
    public int walkSpeed => stats.agility;
    public int runSpeed => stats.agility * 2;

    public float gravity = -10f;
    public float jumpHeight = 2.0f;

    public float maxStamina = 100;
    private float currentStamina;

    // referans 
    private Vector3 velocity;
    private bool isGrounded; // yerdemiyim
    private int puan = 0;

    private CharacterController controller;
    private Animator animator;
    [SerializeField]
    private InsanStats stats;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        speed = walkSpeed;
        currentStamina = maxStamina;
    }

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

        //hareket ediyor muyum etmiyorwsam boþtyým

        if (move == Vector3.zero)
        {
            if (currentStamina <= maxStamina)
                currentStamina += runSpeed * Time.deltaTime;
            
            AnimasyonAyarla(0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 5)
        {
            if (currentStamina >= 0)
                currentStamina -= runSpeed * 3 * Time.deltaTime;
            speed = runSpeed;
            AnimasyonAyarla(xMovement * 2, zMovement *2);
        }
        else
        {
            if (currentStamina <= maxStamina)
                currentStamina += walkSpeed * Time.deltaTime;
            speed = walkSpeed;
            AnimasyonAyarla(xMovement, zMovement);
        }


        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            animator.SetBool("Jump", true);
            Invoke(nameof(InvokeResetJumpAnim), 1);

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        Vector3 totalMove = (move * speed) + velocity;
        controller.Move(totalMove * Time.deltaTime);

        UpdateStaminaText();
    }

    void AnimasyonAyarla(float xFloat, float zFloat)
    {
        animator.SetFloat(zHareketAnim, zFloat, 0.1f, Time.deltaTime);

        animator.SetFloat(xHareketAnim, xFloat, 0.1f, Time.deltaTime);
    }

    void UpdateStaminaText()
    {
        staminaText.text = "Stamina: " + Convert.ToInt32(currentStamina);
    }

    void InvokeResetJumpAnim()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Yer")
        {
            animator.SetBool("Fall", false);
        }
    }
}