using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFizikAksanlari : MonoBehaviour
{
    public Rigidbody connectedBody;
    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint hinge = gameObject.AddComponent<HingeJoint>();
        //hinge.useMotor = false;
        //hinge.anchor = new Vector3(0, 1, 0);
        //hinge.axis = new Vector3(0, 0, 1);


        // yeni

        //HingeJoint hinge = gameObject.AddComponent<HingeJoint>();
        //hinge.connectedBody = connectedBody;

        //hinge.anchor = new Vector3(0, 1, 0);     // Pivot noktasý, salýncak ucundaysa (üstte)
        //hinge.axis = Vector3.forward;            // Z ekseninde dönecek (sahneye göre ayarlanmalý)

        //hinge.useMotor = false;

        SpringJoint spring = gameObject.AddComponent<SpringJoint>();
        spring.connectedBody = connectedBody;
        spring.spring = 50f;
        spring.damper = 5f;
        spring.minDistance = 0.5f;
        spring.maxDistance = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//public class ForceExample : MonoBehaviour
//{
//    public Rigidbody rb;
//    public float forceAmount = 10f;

//    void Start()
//    {
//        // Sürekli kuvvet
//        rb.AddForce(Vector3.forward * forceAmount, ForceMode.Force);

//        // Ani kuvvet (yumruk etkisi gibi)
//        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

//        // Kütleden baðýmsýz hýz deðiþimi
//        rb.AddForce(Vector3.right * forceAmount, ForceMode.VelocityChange);
//    }
//}

//public class CollisionLayerCheck : MonoBehaviour
//{
//    // Karþýlaþtýrýlacak katman adý (örnek: "Enemy")
//    public string targetLayerName = "Enemy";

//    private void OnTriggerEnter(Collider other)
//    {
//        if (LayerMask.LayerToName(other.gameObject.layer) == targetLayerName)
//        {
//            Debug.Log("Enemy çarpýþmasý: " + other.name);
//        }
//    }
//}

//if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy" ||
//    LayerMask.LayerToName(other.gameObject.layer) == "Obstacle")
//{
//    // ...
//}