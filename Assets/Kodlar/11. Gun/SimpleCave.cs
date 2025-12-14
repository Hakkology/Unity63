using UnityEngine;

public class SimpleCave : MonoBehaviour
{
    public int width = 40;          // Haritanın genişliği (x)
    public int depth = 40;          // Haritanın derinliği (z)
    public int scale = 2;           // Her küpün boyutu
    public int fillPercent = 45;    // Başlangıçta % kaç hücre duvar olacak?
    public int smoothSteps = 5;     // Kaç kere pürüzsüzleştirilecek (iteration)?

    byte[,] map;                    // Mağara haritası (0 = zemin, 1 = duvar)

    void Start()
    {
        map = new byte[width, depth];

        // 1) Haritayı rastgele doldur (duvar ve zemin)
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
                // fillPercent'e göre rastgele 1 (duvar) veya 0 (zemin) ata
                map[x, z] = (byte)(Random.Range(0, 100) < fillPercent ? 1 : 0);

        // 2) Cellular Automata ile mağarayı pürüzsüzleştir
        for (int step = 0; step < smoothSteps; step++)
        {
            byte[,] newMap = new byte[width, depth];

            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    int wallCount = 0; // Komşu hücrelerde kaç duvar var?

                    // 3x3 komşuluk kontrolü (kendisi dahil)
                    for (int dz = -1; dz <= 1; dz++)
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int nx = x + dx, nz = z + dz;
                            // Sınır dışı ise, duvar gibi say (kapanma sağlanır)
                            if (nx < 0 || nz < 0 || nx >= width || nz >= depth)
                                wallCount++;
                            else if (map[nx, nz] == 1)
                                wallCount++;
                        }
                    // 5 ve üzeri komşuda duvar varsa, burası duvar olsun
                    newMap[x, z] = (wallCount > 4) ? (byte)1 : (byte)0;
                }
            }
            map = newMap; // Haritayı güncelle
        }

        // 3) Oluşan haritada duvar olan hücrelerde küp oluştur
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.position = pos;
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                }
    }
}