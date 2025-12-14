using UnityEngine;

public class SimpleCivMap : MonoBehaviour
{
    public int width = 30;           // Haritanın x (genişlik) boyutu
    public int depth = 30;           // Haritanın z (derinlik) boyutu
    public float noiseScale = 0.12f; // Perlin Noise ölçeği (arazi pürüzlülüğü)
    public int scale = 2;            // Her küpün boyutu
    public int maxHeight = 8;        // Dağların çıkabileceği maksimum yükseklik

    void Start()
    {
        // Harita boyunca tüm x ve z koordinatları gez
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                // Perlin gürültüsü ile [0,1] arası yükseklik değeri al
                float nx = x * noiseScale;
                float nz = z * noiseScale;
                float noise = Mathf.PerlinNoise(nx, nz);

                // Yüksekliği belirle (biyomlara göre gerekirse değişecek)
                int height = Mathf.RoundToInt(noise * maxHeight);

                // Biyom rengi seçimi (yüksekliğe göre)
                Color color;

                if (noise < 0.3f)
                {
                    // Su (en düşük kısımlar)
                    color = Color.blue;
                    height = 1; // Su bölgeleri hep alçak
                }
                else if (noise < 0.4f)
                {
                    // Kıyı veya ova (açık yeşil)
                    color = new Color(0.8f, 1f, 0.6f);
                }
                else if (noise < 0.7f)
                {
                    // Orman (koyu yeşil)
                    color = new Color(0.1f, 0.5f, 0.1f);
                }
                else
                {
                    // Dağ (kahverengi, yüksek ve daha kalın)
                    color = new Color(0.4f, 0.3f, 0.15f);
                    height += 2; // Dağlar daha yüksek görünsün
                }

                // Yüksekliğe göre üst üste küpler oluştur
                for (int y = 0; y < height; y++)
                {
                    // Her küpün sahnedeki pozisyonu
                    Vector3 pos = new Vector3(x * scale, y * scale, z * scale);
                    // Yeni bir küp oluştur
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pos;
                    cube.transform.localScale = new Vector3(scale, scale, scale);
                    // Küpün rengini biyoma göre ata
                    cube.GetComponent<Renderer>().material.color = color;
                }
            }
    }
}