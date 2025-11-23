using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInvokeSistemi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LogEkleme) , 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LogEkleme()
    {
        Debug.Log("2 SANÝYE SONRA ÇALIÞTI");
    }
}
