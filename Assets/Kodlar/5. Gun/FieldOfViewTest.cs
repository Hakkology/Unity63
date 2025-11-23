using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewTest : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Dönme hýzý
    public float fov = 90f; // Görüþ açýsý
    public float viewDistance = 15f; // Görüþ mesafesi
    public int rayCount = 50; // Çizilecek ray sayýsý
    public LayerMask obstacleMask; // Engel maskesi

    private float startingAngle;

    void Update()
    {
        // Küpü yavaþça döndür
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        DrawFOVCircle();
    }

    void DrawFOVCircle()
    {
        float angleStep = fov / rayCount;
        Vector3 previousEndPoint = Vector3.zero;

        for (int i = 0; i <= rayCount; i++)
        {
            float angle = transform.eulerAngles.y - fov / 2 + angleStep * i;
            Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            RaycastHit hit;

            Vector3 endPoint;
            if (Physics.Raycast(transform.position, dir, out hit, viewDistance, obstacleMask))
            {
                endPoint = transform.position + dir * hit.distance;
                Debug.DrawRay(transform.position, dir * hit.distance, Color.green);
            }
            else
            {
                endPoint = transform.position + dir * viewDistance;
                Debug.DrawRay(transform.position, dir * viewDistance, Color.red);
            }

            if (i > 0)
            {
                // Önceki rayýn son noktasý ile þimdiki rayýn son noktasýný birleþtir
                Debug.DrawLine(previousEndPoint, endPoint, Color.blue);
            }

            previousEndPoint = endPoint;

            // Son rayý ilk ray ile birleþtirerek çemberi tamamla
            // bu kýsým gerekli deðil
            if (i == rayCount)
            {
                float firstAngle = transform.eulerAngles.y - fov / 2;
                Vector3 firstDir = Quaternion.Euler(0, firstAngle, 0) * Vector3.forward;
                Vector3 firstEndPoint = transform.position + firstDir * viewDistance;
                Debug.DrawLine(endPoint, firstEndPoint, Color.blue);
            }
        }
    }
}
