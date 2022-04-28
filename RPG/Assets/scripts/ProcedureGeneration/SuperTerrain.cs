using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTerrain
{
    public static int width = 128;
    public static int CHUNK_SIZE = 64;
    public static int CHUNK_RESOLUTION = 65;//2^K+1
    public static int WORLD_HEIGHT = 400;
    public Terrain[,] chunk;
    public Transform Parent { get; private set; }
    public void Create()
    {
        chunk = new Terrain[width, width];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < width; j++)
            {
                chunk[i, j] = BildNewTerrain();
                chunk[i, j].gameObject.SetActive(false);
                chunk[i, j].transform.Translate(i * CHUNK_SIZE, 0.0f, j * CHUNK_SIZE);
                chunk[i, j].name = "Chunk(" + i + " " + j + ")";
            }
        SetNeighbors();
    }
    public void SetParent(Transform parent)
    {
        Parent = parent;
    }
    public int GetWidth()
    {
        return width;
    }
    public int GetChunkSize()
    {
        return CHUNK_SIZE;
    }
    public int GetChunkResolution()
    {
        return CHUNK_RESOLUTION;
    }
    private Terrain SafeGetTerrain(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= width)
            return null;
        return chunk[y, x];
    }
    private Terrain BildNewTerrain()
    {
        var terrainData = new TerrainData
        {
            heightmapResolution = CHUNK_RESOLUTION,
            size = new Vector3(CHUNK_SIZE, WORLD_HEIGHT, CHUNK_SIZE)

        };
        var newTerrain = Terrain.CreateTerrainGameObject(terrainData).GetComponent<Terrain>();

        newTerrain.transform.parent = Parent;
        return newTerrain;
    }
    private void SetNeighbors()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                chunk[x, y].SetNeighbors(SafeGetTerrain(x - 1, y),
                                         SafeGetTerrain(x, y + 1),
                                         SafeGetTerrain(x + 1, y),
                                        SafeGetTerrain(x, y - 1));
            }
        }
    }
}
