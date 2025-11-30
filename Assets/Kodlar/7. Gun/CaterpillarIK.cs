using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarIK : MonoBehaviour
{
    [Header("Ayarlar")]
    public Transform hedef;             // Elin bakacaðý nokta (sahnedeki küre)
    public Transform omuz;              // Sabit kalacak omuz küpü
    public List<Transform> parcaciklar; // Üst kol, dirsek, alt kol, el (4 adet)

    [Header("Hareket Hýzý")]
    public float hiz = 5f;              // Ne kadar yumuþak dönecek

    void LateUpdate()
    {
        // 1) Omuzdan hedefe vektör
        Vector3 v = hedef.position - omuz.position;

        // 2) Yatay açý (yaw): xz düzlemindeki izdüþümün açýsý
        Vector3 yatay = new Vector3(v.x, 0f, v.z).normalized;
        float toplamYaw = Mathf.Atan2(yatay.x, yatay.z) * Mathf.Rad2Deg;

        // 3) Dikey açý (pitch): yükseklik farkýnýn yatay mesafeye oraný
        float mesafeYatay = new Vector3(v.x, 0f, v.z).magnitude;
        float toplamPitch = -Mathf.Atan2(v.y, mesafeYatay) * Mathf.Rad2Deg;

        int n = parcaciklar.Count; // 4 parça

        // 4) Omuz hiçbir yere bakmasýn
        omuz.localRotation = Quaternion.identity;

        // 5) Parçalar toplam açýyý eþit paylaþsýn
        for (int i = 0; i < n; i++)
        {
            float oran = (i + 1f) / n;
            float yaw = toplamYaw * oran;
            float pitch = toplamPitch * oran;

            // Sadece Yaw ve Pitch, Roll = 0
            Quaternion hedefRot = Quaternion.Euler(pitch, yaw, 0f);

            // Yumuþakça uygula
            parcaciklar[i].localRotation = Quaternion.Slerp(parcaciklar[i].localRotation, hedefRot, Time.deltaTime * hiz
            );
        }
    }
}
