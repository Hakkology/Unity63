using UnityEngine;

[CreateAssetMenu(fileName = "InsanStats", menuName = "Insansi/InsanStats", order = 1)]
public class InsanStats : ScriptableObject
{
    [Header("Base Attributes")]
    [Tooltip("Strength affects physical damage and total health points.")]
    public int strength;

    [Tooltip("Agility affects movement speed.")]
    public int agility;

    [Tooltip("Intelligence affects magical damage.")]
    public int intelligence;

    public float CalculatePhysicalDamage()
    {
        return strength * 1.5f;  // Basit bir hasar hesaplama formülü
    }

    public float CalculateMagicalDamage()
    {
        return intelligence * 1.5f;  // Basit bir hasar hesaplama formülü
    }

    public float CalculateSpeed()
    {
        return 5 + agility * 0.3f;  // Yürüme hýzýný agility'e baðlý olarak hesapla
    }

    public int CalculateHP()
    {
        return strength * 20;  // HP, intelligence ile doðru orantýlý
    }
}
