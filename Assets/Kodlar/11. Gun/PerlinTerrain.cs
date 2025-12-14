using UnityEngine;

public class PerlinTerrain : MonoBehaviour
{
    public int width = 30;          // Terrain'in x (genişlik) boyutu
    public int depth = 30;          // Terrain'in z (derinlik) boyutu
    public float noiseScale = 0.2f; // Perlin Noise ölçeği (daha düşük => daha yumuşak geçiş)
    public int maxHeight = 8;       // Küplerin çıkabileceği maksimum yükseklik (y)
    public int scale = 2;           // Her küpün boyutu

    void Start()
    {
        // Z ekseni boyunca satır satır gez
        for (int z = 0; z < depth; z++)
            // X ekseni boyunca sütun sütun gez
            for (int x = 0; x < width; x++)
            {
                // Her (x,z) için Perlin gürültüsüyle 0-1 arası yükseklik belirle
                float noise = Mathf.PerlinNoise(x * noiseScale, z * noiseScale);
                // Belirlenen gürültüyü max yükseklikle çarp ve tam sayıya yuvarla
                int height = Mathf.RoundToInt(noise * maxHeight);

                // Bu yükseklikte kaç kat küp olacağını belirle ve oluştur
                for (int y = 0; y < height; y++)
                {
                    // Her küpün sahnedeki pozisyonu
                    Vector3 pos = new Vector3(x * scale, y * scale, z * scale);
                    // Yeni bir küp (duvar) objesi oluştur
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pos;
                    cube.transform.localScale = new Vector3(scale, scale, scale);
                    // İstenirse burada renklendirme/etiket/özellik eklenebilir
                }
            }
    }
}
