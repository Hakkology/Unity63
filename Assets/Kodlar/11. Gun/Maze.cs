
using UnityEngine;

public class Maze : MonoBehaviour
{

    // public int width = 30;
    // public int depth = 30;

    public int width, depth = 30;
    public int scale = 1;

    public int[,] map;

    public Material groundMat;
    public Material wallMat;

    private void Start()
    {
        HaritayiBaslat();
        HaritayiOlustur();
        HaritayiCiz();
    }

    private void HaritayiBaslat()
    {
        map = new int[width, depth];
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                map[x, z] = 1;
            }
        }
    }

    protected virtual void HaritayiOlustur()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    map[x, z] = 0;
                }
            }
        }
    }

    private void HaritayiCiz()
    {
        bool giris = false;
        int count = 0;
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 altpos = new Vector3(x * scale, 0, z * scale);
                GameObject altwall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                altwall.transform.localScale = new Vector3(scale, scale, scale);
                altwall.transform.position = altpos;
                var altrenderer = altwall.GetComponent<Renderer>();
                altrenderer.sharedMaterial = groundMat;
                count++;

                if (map[x, z] == 1 || x == 0 || z == 0 || x == width - 1 || z == depth - 1)
                {
                    Vector3 pos = new Vector3(x * scale, scale, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    var renderer = wall.GetComponent<Renderer>();
                    renderer.sharedMaterial = wallMat;
                    count++;

                    if (!giris && z > 1 && map[1, z] == 0 && map[2, z] == 0 && map[3, z] == 0 && x == 0)
                    {
                        Destroy(wall);
                        giris = true;
                    }
                }
            }
        }
        Debug.Log($"{count} kadar küp oluştu.");
    }


}