using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class chunksStapler 
{
    public static void DiamonSquareStiching(SuperTerrain SuperTerrain)//по факту это генератор для супертерраина так что его надо перетащить в отдельный класс
    {
        int SuperrTerrainSize = (SuperTerrain.GetWidth()) * (SuperTerrain.GetChunkSize());
        float[,] STerrain = new float[SuperrTerrainSize, SuperrTerrainSize];
        Generator generator = new DiamondSquare(STerrain, SuperrTerrainSize);//создали супертерраин
        generator.Generate();

        //теперь надо его перенсти на данные плоскостей
        for (int x = 0; x < SuperTerrain.GetWidth(); ++x)
        {
            for (int y = 0; y < SuperTerrain.GetWidth(); ++y)
            {
                float[,] chunkHeights = new float[SuperTerrain.GetChunkResolution(), SuperTerrain.GetChunkResolution()];
                for(int xInchunk=0;xInchunk<= SuperTerrain.GetChunkSize(); xInchunk++)
                    for (int yInchunk = 0; yInchunk <= SuperTerrain.GetChunkSize(); yInchunk++)
                    {
                        if(x * SuperTerrain.GetChunkSize() + xInchunk< SuperrTerrainSize && y * SuperTerrain.GetChunkSize() + yInchunk <SuperrTerrainSize)
                        chunkHeights[yInchunk, xInchunk] = STerrain[x * SuperTerrain.GetChunkSize() + xInchunk, y * SuperTerrain.GetChunkSize() + yInchunk];//присвоили высоты чанку из глобальной карты(я не знаю почему порядок обратный, эмпирически меттод)
                    }
                SuperTerrain.chunk[x, y].terrainData.SetHeights(0,0, chunkHeights);
            }
        }

     }
}
