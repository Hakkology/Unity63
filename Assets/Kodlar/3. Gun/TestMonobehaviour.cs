using UnityEngine;

public class TestMonobehaviour : MonoBehaviour
{
    int toplam;

    //public int sonXKonumu;
    //public int sonYKonumu;
    //public int sonZKonumu;

    //public Vector3 sonKonum = new Vector3(0,0,5);
    //public Vector3 sonDonum = new Vector3(0, 2, 0);

    public int hareketHizi = 2;
    public int donmeAcisi = 45;
    void Start()
    {
        //gameObject.SetActive(false);
        //gameObject.SetActive(true);

        //transform.position.x = sonXKonumu;
        //transform.position = sonKonum;

        //sonKonum = new Vector3(0, 0, 5);
        //transform.position = sonKonum;
        

        //transform.Translate()
        //transform.rotation = Quaternion.Euler(0,45,0);
        //transform.rotation = Quaternion.Euler(sonKonum);

        // method overloading
        Toplama(3, 5);
        Toplama(new Vector2Int(3, 5));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * hareketHizi;
        transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * donmeAcisi);
        //transform.rotation
        //transform.position += transform.position +sonKonum;

        // update e yazýnca noluyor?
        // sürekli ekleniyor.

        // hem starta yazarsak hemde editore yazarsak nolur?
    }

    void Toplama(int x, int y)
    {
        toplam = x + y;
    }

    void Toplama(Vector2Int z) 
    {
        toplam = z.x + z.y;
    }
}

public class Insan
{

}