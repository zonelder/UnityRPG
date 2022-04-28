using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{//��� ����� ����������� ��� ������������ � ��������� ���������� � ������(��������� ����������� ���������� ����� ��������� ����� � ����� �����).
 // � ��� ����� �� ������� ����. �������� ���� ����� �� ��� ������������ 1_ ��� ��� ������� � ������ ����� � ��� ������� � ����� � �� �������

    public SuperTerrain terrain =new SuperTerrain();
    //public temp[,]
    //public wet[,]
    void Start()
    {
        terrain.SetParent(gameObject.transform);
        terrain.Create();
        chunksStapler.DiamonSquareStiching(terrain);
    }

    public void RenderAround(int x,int y)//8 chunck around
    {
        for (int dx = -16; dx <= 16; dx++)
        {
            if (dx + x < 0 || dx + x >= terrain.GetWidth())
                continue;
            else
                for (int dy = -16; dy <= 16; dy++)
            {
                if (dy + y < 0 || dy + y >= terrain.GetWidth())
                    continue;
                if(Mathf.Abs(dx)>8 || Mathf.Abs(dy) > 8)
                    terrain.chunk[x + dx, y + dy].gameObject.SetActive(false);
                else
                   terrain.chunk[x + dx, y + dy].gameObject.SetActive(true);

                }
        }
    }
}
