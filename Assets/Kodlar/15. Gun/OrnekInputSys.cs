using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnekInputSys : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget; 
    [SerializeField] private float slowSpeed = 10f; 
    [SerializeField] private float fastSpeed = 20f;

    // Adım 1: Generate edilen C# sınıfından bir nesne referansı oluştur
    private PlayerInput _inputActions;

    void Awake() 
    {
        // Adım 2: Nesneyi belleğe al
        _inputActions = new PlayerInput();
    }

    void OnEnable() 
    {
        // Adım 3: Action Map'i aktif et (Unutulursa girdi alınamaz!)
        _inputActions.Player.Enable();
    }

    void OnDisable() 
    {
        // Adım 4: Kapatıldığında devre dışı bırak (Performans/Hata önleme)
        _inputActions.Player.Disable();
    }

    void Update() 
    {
        // Adım 5: Değerleri Asset'te tanımlanan isimlerle (Move, Sprint) oku
        Vector2 input = _inputActions.Player.Move.ReadValue<Vector2>();
        bool isSprinting = _inputActions.Player.Sprint.IsPressed();

        if (input != Vector2.zero) 
        {
            float speed = isSprinting ? fastSpeed : slowSpeed;
            Vector3 direction = new Vector3(input.x, 0, input.y);
            
            cameraTarget.position += direction * speed * Time.deltaTime;
        }
    }
}
