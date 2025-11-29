using UnityEngine;

public class BotController : MonoBehaviour
{
    string durma = "Durma";
    string yurume = "Yurume";
    string kosma = "Kosma";

    public float speed = 5.0f;
    public int walkSpeed = 4;
    public int runSpeed = 7;

    public float gravity = -10f;
    public float jumpHeight = 2.0f;

    private const int Idle = 0;
    private const int WalkForward = 1;
    private const int RunForward = 2;
    private const int WalkBackward = -1;
    private const int RunBackward = -2;

    // referans 
    private Vector3 velocity;
    private bool isGrounded; // yerdemiyim
    private int puan = 0;

    private CharacterController controller;
    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        speed = walkSpeed;
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
            animator.speed = 1;
            AnimasyonAyarla(0);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (zMovement > 0)
            {
                AnimasyonAyarla(2);
                speed = runSpeed;
            }
            else
            {
                AnimasyonAyarla(-2);
                speed = runSpeed;
            }

        }
        else
        {
            if (zMovement > 0)
            {
                speed = walkSpeed;
                AnimasyonAyarla(1);
            }
            else
            {
                speed = walkSpeed;
                AnimasyonAyarla(-1);
            }

        }


        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        Vector3 totalMove = (move * speed) + velocity;
        controller.Move(totalMove * Time.deltaTime);
    }

    void AnimasyonAyarla(int trueOlacakAnimasyon)
    {
        switch (trueOlacakAnimasyon
)
        {
            case -2:
                animator.SetInteger("ZHareket", -2);
                break;
            case -1:
                animator.SetInteger("ZHareket", -1);
                break;
            case 0:
                animator.SetInteger("ZHareket", 0);
                break;
            case 1:
                animator.SetInteger("ZHareket", 1);
                break;
            case 2:
                animator.SetInteger("ZHareket", 2);
                break;
            default:
                break;
        }

    }
}