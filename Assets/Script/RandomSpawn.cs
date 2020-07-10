using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
   
    public GameObject[] spawnPrefabs;
    public float spawnInterval = 3f;
    private float nextSpawn;
    private int size;
    private int spawnIndex;
    private Camera mainCamera;
    private Vector3[] positions = new Vector3[8];
    public float speed = 5f;


    void Start() {
        mainCamera = Camera.main;
        //positions = new Vector3[8];
        PositionsInitialize();
    }

    void Update()
    {

        int index = Random.Range(0, 7);
        if (Time.time > nextSpawn)
        {
           
            size = spawnPrefabs.Length;
            
                                
            Vector2 initialVelocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(positions[index]);      //get the position for the spawning planet

            spawnIndex = Random.Range(0, size);         // which planet to spawn

            GameObject spawnPlanet = Instantiate(spawnPrefabs[spawnIndex], spawnPosition, Quaternion.identity) as GameObject;
           

           
            spawnPlanet.GetComponent<Rigidbody2D>().velocity = speed * initialVelocity;
            
            
            nextSpawn = Time.time + spawnInterval;
        }
    }

    private void PositionsInitialize() {
        positions[0] = new Vector3(0.05f, 0.95f, 10);
        positions[1] = new Vector3(0.5f, 0.95f, 10);
        positions[2] = new Vector3(0.95f, 0.95f, 10);
        positions[3] = new Vector3(0.05f, 0.5f, 10);
        positions[4] = new Vector3(0.95f, 0.5f, 10);
        positions[5] = new Vector3(0.05f, 0.05f, 10);
        positions[6] = new Vector3(0.5f, 0.05f, 10);
        positions[7] = new Vector3(0.95f, 0.05f, 10);
    }
}
