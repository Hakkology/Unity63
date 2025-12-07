using UnityEngine;

public class PlayerScoreController : MonoBehaviour {

    [SerializeField]
    private int puan = 0;

    public void PuanArtir(int artirilacakDeger)
    {
        puan += artirilacakDeger;
        HUDController.Instance.UpdatePuanText(puan);
    }

    public int GetPuan()
    {
        return puan;
    }
}