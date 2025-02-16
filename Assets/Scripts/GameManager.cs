using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Player")]
    public GameObject player;
    public Transform playerSpawnpoint;
    private GameObject playerInstance;

    [Header ("Dragon")]
    public GameObject dragon;
    private GameObject dragonInstance;
    public Transform[] dragonSpawnpoints;
    private GameObject isDragonSpawned;

    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1f;
        SpawnPlayer();
        SpawnDragon();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if there is a dragon spawned
        isDragonSpawned = GameObject.FindGameObjectWithTag("Dragon");

        // If no dragon, spawns a new one
        if(isDragonSpawned == null)
        {
            SpawnDragon();
        }
    }

    void SpawnPlayer()
    {
        // Spawns player at PlayerSpawnpoint
        playerInstance = Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);
    }

    public void SpawnDragon()
    {
        // Chooses a random int between 0 and 3
        int spawnPoint = Random.Range(0, 4);

        // Spawns dragon at a random Dragon Spawnpoint
        dragonInstance = Instantiate(dragon, dragonSpawnpoints[spawnPoint].position, dragonSpawnpoints[spawnPoint].rotation);
    }


}
