using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;       // Takip edilecek Küre
    public float distance = 5.0f;  // Küreden ne kadar uzakta duracak?
    public float height = 2.0f;    // Küreden ne kadar yüksekte duracak?
    public float rotationDamping = 3.0f; // Dönüþ ne kadar yumuþak olsun? (Gecikme efekti)

    void LateUpdate()
    {
        if (!target) return;

        // 1. HEDEFÝN AÇISINI AL:
        // Kürenin sadece Y eksenindeki (saða/sola) açýsýný alýyoruz.
        // X ve Z'yi almýyoruz ki kamera takla atmasýn.
        float wantedRotationAngle = target.eulerAngles.y;

        // 2. KAMERANIN MEVCUT AÇISINI AL:
        float currentRotationAngle = transform.eulerAngles.y;

        // 3. YUMUÞAK GEÇÝÞ (LERP):
        // Kameranýn açýsýný, hedef açýya yavaþça çevir (akýcýlýk saðlar).
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // 4. DÖNÜÞÜ OLUÞTUR:
        // Bu açýyý matematiksel bir "dönüþ" (Quaternion) verisine çevir.
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // 5. POZÝSYONU AYARLA:
        // Önce kürenin olduðu yere git.
        transform.position = target.position;

        // Sonra hesapladýðýmýz açýya göre "geriye doðru" (Vector3.forward'ýn tersi) git.
        // (Mesafeyi burada kullanýyoruz)
        transform.position -= currentRotation * Vector3.forward * distance;

        // 6. YÜKSEKLÝÐÝ AYARLA:
        // Kamerayý yerden belirlediðimiz kadar yukarý kaldýr.
        transform.position = new Vector3(transform.position.x, target.position.y + height, transform.position.z);

        // 7. HEDEFE BAK:
        // Son olarak kameranýn gözünü küreye sabitle.
        transform.LookAt(target);
    }
}
