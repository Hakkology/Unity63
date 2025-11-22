using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AbiRigidBehaviour : MonoBehaviour
{
    public int speed = 5;
    public int jump = 200;

    private Rigidbody rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(rbody.velocity.x, jump, rbody.velocity.z);
        }
        //transform.LookAt(transform.forward);
    }

    void LateUpdate()
    {
        //var yon = rbody.velocity;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rbody.AddForce(movement * speed);
    }
}
