using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class chunksStapler 
{
    public static void DiamonSquareStiching(SuperTerrain SuperTerrain)
    {
        int SuperrTerrainSize = (SuperTerrain.GetWidth()) * (SuperTerrain.GetChunkSize());
        float[,] STerrain = new float[SuperrTerrainSize, SuperrTerrainSize];


        Generator DSgenerator = new DiamondSquare(STerrain, SuperrTerrainSize);
        DSgenerator.Generate();

        //теперь надо его перенсти на данные чанков
        for (int x = 0; x < SuperTerrain.GetWidth(); ++x)
        {
            for (int y = 0; y < SuperTerrain.GetWidth(); ++y)
            {
                float[,] chunkHeights = new float[SuperTerrain.GetChunkResolution(), SuperTerrain.GetChunkResolution()];


                for(int xInchunk=0;xInchunk<= SuperTerrain.GetChunkSize(); xInchunk++)
                    for (int yInchunk = 0; yInchunk <= SuperTerrain.GetChunkSize(); yInchunk++)
                    {
                        if(x * SuperTerrain.GetChunkSize() + xInchunk< SuperrTerrainSize && y * SuperTerrain.GetChunkSize() + yInchunk <SuperrTerrainSize)
                            chunkHeights[yInchunk, xInchunk] = STerrain[x * SuperTerrain.GetChunkSize() + xInchunk, y * SuperTerrain.GetChunkSize() + yInchunk];
                    }


                SuperTerrain.chunk[x, y].terrainData.SetHeights(0,0, chunkHeights);
            }
        }

     }
}
