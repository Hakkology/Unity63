using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasttest : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float rayDistance = 5.0f; // Ray'in menzili
    public LayerMask wallLayer; // Duvarlarý temsil eden layer

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Küpü yavaþça döndür
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Raycast yap
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * rayDistance;
        Debug.DrawRay(transform.position, forward, Color.blue);

        // Field of view kontrolü ve renk deðiþikliði
        if (Physics.Raycast(transform.position, forward, out hit, rayDistance, wallLayer))
        {
            // Duvar varsa yeþil
            renderer.material.color = Color.green;
        }
        else
        {
            // Duvar yoksa kýrmýzý
            renderer.material.color = Color.red;
        }
    }
}