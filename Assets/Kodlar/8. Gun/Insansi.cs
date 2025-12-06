using UnityEngine;

public class Insansi 
{
    public string isim;
    public string soyisim;
    private int yas;
    public float boy;
    public Color sacRengi;

    // constructor
    public Insansi(string isim, string soyisim)
    {
        this.isim = isim;
        this.soyisim = soyisim;
    }

    public void PrintInsanUgrastirmaBeni()
    {
        Debug.Log("Ýnsansi kiþisi: " + this.boy + " / " + this.yas + " / " + this.isim + " / " + this.soyisim + " / " + this.sacRengi);
    }

    public void YasGirisi(int yas)
    {
        this.yas = yas;
    }

}
