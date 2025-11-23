using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityNobetciKodu : MonoBehaviour
{
    public List<Transform> nobetNoktalari;

    private Transform gidilenNokta;

    void Start()
    {
        GidilenNoktayiDegistir();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, gidilenNokta.position) > 1 && gidilenNokta != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, gidilenNokta.position, 5 * Time.deltaTime);
        }
        else
        {
            GidilenNoktayiDegistir();
        }
    }

    void GidilenNoktayiDegistir()
    {
        int secilecekIndex = Random.Range(0, nobetNoktalari.Count);

        gidilenNokta = nobetNoktalari[secilecekIndex];
    }
}
