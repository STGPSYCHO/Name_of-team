using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform Player;
    private Chunk[] ChunkPrefubs;
    public Chunk FirstChunk;

    private Chunk[,] spawnedChunks;
    //public List<Chunk> spawnedChunks = new List<Chunk>();
    void Start()
    {
        //spawnedChunks.Add(FirstChunk);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Player.position.x > spawnedChunks) ;
    }
}
