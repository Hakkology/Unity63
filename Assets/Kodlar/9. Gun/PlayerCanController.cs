using UnityEngine;

public class PlayerCanController : MonoBehaviour {
    private int can = 3;

    public void UpdateCan(int amount)
    {
        can += amount;
        HUDController.Instance.UpdateCanImage(can);
    }

    public int GetCan()
    {
        return can;
    }
}