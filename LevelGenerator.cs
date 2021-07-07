using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //-----------------
    //Camera 
    public Camera cam;
    //speed
    public float cameraSpeed;
    //-----------------
    //list of level chunks
    private List<ChunkClass> levelList = new List<ChunkClass>();
    //list of avalable level chunks
    public List<ChunkClass> Chunks = new List<ChunkClass>();
    //Vector3 Enter
    //Vecor3 Exit
    //Min Distance
    //Max Distance

    // Start is called before the first frame update
    void Start()
    {
        //find Starting Chunk
        GameObject sc = GameObject.FindGameObjectWithTag("StartingChunk");
        levelList.Add(sc.GetComponent<ChunkClass>());
        Debug.Log(levelList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnChunk();
        }
    }
    // Dynamic Spawn Function 
    //if the player is in a chunk,
    //check if there are 2 chuncks in front of that one in the list
    //if not

    //Function Spawn Chunks
    private void SpawnChunk()
    {
        Debug.Log(levelList.Count + "Start");

        int rnd = Random.Range(0, Chunks.Count);
        Debug.Log(rnd + " is the rnd." + levelList.Count + " is the chunk count");
        ChunkClass rndChunk = Chunks[rnd];
        
        ChunkClass pc = levelList[levelList.Count-1];
        Debug.Log(levelList.Count + " End");
        ChunkClass nc = Chunks[rnd];
        Debug.Log(nc);
        ChunkClass progress = Instantiate(nc, (pc.ExitWaypoint.transform.position), Quaternion.identity);
        //progress.transform.position = progress.transform.LocalPosition + progress.EnterWaypoint.transform.localPosition;
        levelList.Add(progress);
    }
    //grab a randome chunk form a list of avalible chunks
    //spawn in chunk based on the exit of the last and
    //entrance of the next considering min and max dist
    //add chunk to the list

    //Function Move Camera
    //get chunk the player is in
    //move the camera to that chunks waypoint at a speed

    //Function get player chunk
    //get colliders the player is contacting
    //look through the list
    //if the collider is the same as one on the list
    //return that chunk
}
