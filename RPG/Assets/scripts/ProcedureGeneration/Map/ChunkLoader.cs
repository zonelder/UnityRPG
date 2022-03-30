using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject camera;
    public int CHUNK_SIZE=SuperTerrain.CHUNK_SIZE;
    void Update()
    {
        float x = camera.transform.position.x;
        float y = camera.transform.position.z;
        int chunkCorX =(int)( x / CHUNK_SIZE);
        int chunkCorY = (int)(y / CHUNK_SIZE);
        GameObject.Find("CHUNKS").GetComponent<Map>().RenderAround(chunkCorX, chunkCorY);
    }
}
