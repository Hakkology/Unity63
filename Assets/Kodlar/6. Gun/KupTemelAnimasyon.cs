using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupTemelAnimasyon : MonoBehaviour
{
    public int speed = 5;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool mevcutBoolDegeri = animator.GetBool("KupHareket");
            animator.SetBool("KupHareket", !mevcutBoolDegeri);
        }
    }
}
