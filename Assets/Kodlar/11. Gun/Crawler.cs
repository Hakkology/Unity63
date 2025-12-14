
using UnityEngine;

public class Crawler : Maze
{
    protected override void HaritayiOlustur()
    {
        for (int i = 0; i < 2; i++)
        {
            CrawlV();
        }

        for (int i = 0; i < 3; i++)
        {
            CrawlH();
        }
    }

    private void CrawlV()
    {
        bool bitti = false;
        int x = Random.Range(1, width - 1);
        int z = 1;


        while (!bitti)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) < 50)
            {
                x += Random.Range(-1, 2);
            }
            else
            {
                z += Random.Range(0, 2);
            }
            bitti = (x < 1 || x > width - 1 || z < 1 || z > depth - 1);
        }
    }

    private void CrawlH()
    {
        bool bitti = false;
        int x = 1;
        int z =  Random.Range(1, depth - 1);;


        while (!bitti)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) < 50)
            {
                x += Random.Range(0, 2); // ya 0 ya da 1
            }
            else
            {
                z += Random.Range(-1, 2); // -1,0,1
            }
            bitti = (x < 1 || x > width - 1 || z < 1 || z > depth - 1);
        }
    }


}
