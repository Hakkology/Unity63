using UnityEngine;

public class PlayerStaminaController : MonoBehaviour {
    [SerializeField]
    private float stamina;
    public float maxStamina = 100;

    private void Start() 
    {
        stamina = maxStamina;
    }

    public void UpdateStamina(bool rising)
    {
        if (rising && stamina < maxStamina)
        {
            stamina += 4 * Time.deltaTime;
        }
        else if (stamina > 0)
        {
            stamina -= 7 * Time.deltaTime;
        }

        HUDController.Instance.UpdateStaminaSlider(stamina/maxStamina);
    }


}