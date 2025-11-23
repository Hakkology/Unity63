using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class UnityRaycastDenemeler : MonoBehaviour
{
    public GameObject player;
    Ray ray;

    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1f))
        {
            Debug.Log("Karakter zemin üzerinde!");
        }
        else
        {
            Debug.Log("Karakter hava durumunda!");
        }
    }

    //void CheckPlayerVisibility()
    //{
    //    Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
    //    Ray ray = new Ray(transform.position, directionToPlayer);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100f))
    //    {
    //        if (hit.collider.gameObject == player)
    //        {
    //            Debug.Log("Oyuncu görüldü!");
    //        }
    //    }
    //}

    //void Shoot()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100f))
    //    {
    //        Debug.Log("Ateþ edildi ve " + hit.collider.gameObject.name + " vuruldu!");
    //    }
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    { // Fare týklamasý algýlandýðýnda
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 100f))
    //        {
    //            Debug.Log(hit.collider.gameObject.name + " seçildi!");
    //        }
    //    }
    //}

    //void Start()
    //{

    //    CheckForColliders();
    //}

    //void CheckForColliders()
    //{
    //    ray = new Ray(transform.position, transform.forward);
    //    if (Physics.Raycast(ray))
    //    {
    //        Debug.Log("Something was hit!\"");
    //    }
    //}

    //void Start()
    //{
    //    ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    //    CheckForColliders();
    //}

    //void Update()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100f))
    //    {
    //        Debug.Log(hit.collider.gameObject.name + " ile çarpýþtý!");
    //    }
    //}

    //void CheckForColliders()
    //{
    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        Debug.Log(hit.collider.gameObject.name + " vuruldu!");
    //    }
    //}
}

//public class CollisionLayerCheck : MonoBehaviour
//{
//    // Karþýlaþtýrýlacak katman adý (örnek: "Enemy")
//    public string targetLayerName = "Enemy";

//    private void OnTriggerEnter(Collider other)
//    {
//        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
//        {
//            Debug.Log("Enemy çarpýþmasý: " + other.name);
//        }
//    }
//}