using UnityEngine;

public class OrnekTransformKodu : MonoBehaviour
{
    //public Transform gidilecekNokta;
    public float turnSpeed = 50;
    public float walkSpeed = 5;

    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xMovement, 0, zMovement);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

        transform.Translate(direction * Time.deltaTime * walkSpeed, Space.World);
    }
}
