using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChunkLoader : MonoBehaviour
{
    [SerializeField]
    private Map Parent;
    [SerializeField]
    private GameObject _camera;
    private int CHUNK_SIZE=SuperTerrain.CHUNK_SIZE;
    void Update()
    {
        float x = _camera.transform.position.x;
        float y = _camera.transform.position.z;
        int chunkCorX =(int)( x / CHUNK_SIZE);
        int chunkCorY = (int)(y / CHUNK_SIZE);
        Parent.RenderAround(chunkCorX, chunkCorY);
    }
}
