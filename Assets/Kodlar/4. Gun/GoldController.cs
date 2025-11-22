using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    public int golddanGelenPuan = 10;

    private void Update()
    {
        transform.RotateAround(Vector3.up, 5 * Time.deltaTime);
    }
}
