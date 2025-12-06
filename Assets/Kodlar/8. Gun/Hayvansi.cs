using UnityEngine;

public class Hayvansi
{
    public string isim;
    public int yas;
    public float agirlik;

    public virtual void PrintHayvanUgrastirmaBeni()
    {
        Debug.Log("Hayvansi kiþisi: " + this.agirlik + " / " + this.yas + " / " + this.isim);
    }

    public virtual void HayvanGonus()
    {
        Debug.Log("Hayvan sesi iþte");
    }
}

public class Kedisi : Hayvansi
{
    public string tur;
    public Color renk;
    public bool korumaci;

    public override void PrintHayvanUgrastirmaBeni()
    {
        Debug.Log("Hayvansi kiþisi: " + this.agirlik + " / " + this.yas + " / " + this.isim + " / " + this.tur + " / " + this.renk + " / korumacý mý: " + this.korumaci);
    }

    public override void HayvanGonus()
    {
        Debug.Log("Miyav");
    }
}

public class Kopeksi: Hayvansi
{
    public string tur;
    public Color renk;
    public bool korumaci;
    public bool sahipli;
    public Insansi insan;

    public override void PrintHayvanUgrastirmaBeni()
    {
        Debug.Log("Hayvansi kiþisi: " + this.agirlik + " / " + this.yas + " / " + this.isim + " / " + this.tur + " / " + this.renk + " / korumacý mý: " + this.korumaci + " / sahibi var mý: " + this.sahipli);

        if (this.sahipli)
        {
            insan.PrintInsanUgrastirmaBeni();
        }
    }

    public override void HayvanGonus()
    {
        Debug.Log("Hav");
    }

}

public class Zebrasi : Hayvansi
{
    //public override void PrintHayvanUgrastirmaBeni()
    //{
    //    base.PrintHayvanUgrastirmaBeni();
    //}
}
