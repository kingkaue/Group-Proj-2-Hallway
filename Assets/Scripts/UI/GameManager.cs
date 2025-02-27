using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public Transform playerSpawnpoint;
    private GameObject playerInstance;

    [Header("Dragon")]
    public GameObject dragon;
    public BoxCollider[] dragonSpawnAreas;
    private GameObject isDragonSpawned;

    [Header("Timer")]
    public float timeRemaining = 90;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    
    [Header("Gem")]
    public GameObject gem;
    public BoxCollider gemSpawnArea;

    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1f;
        timerIsRunning = true;
        SpawnPlayer();
        SpawnDragon();
        SpawnGem();

    }

    // Update is called once per frame
    void Update()
    {
        // Checks if there is a dragon spawned
        isDragonSpawned = GameObject.FindGameObjectWithTag("Dragon");

        if (isDragonSpawned == null)
        {
            SpawnDragon();
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                GameOver();
                SceneManager.LoadScene("Lose");
            }
        }
    }

    void SpawnPlayer()
    {
        // Spawns player at PlayerSpawnpoint
        playerInstance = Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);
    }

    public void SpawnDragon()
    {
        bool canSpawn = false;
        int spawnArea = Random.Range(0, dragonSpawnAreas.Length);

        while (canSpawn == false)
        {
            if (dragonSpawnAreas[spawnArea].GetComponent<PlayerCheck>().isPlayerInside == false)
            {
                canSpawn = true;
            }
            else
            {
                spawnArea = Random.Range(0, dragonSpawnAreas.Length);
            }
        }

        Vector3 randomPoint = GetRandomPointDragon(spawnArea);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            Instantiate(dragon, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn point on the NavMesh.");
        }
    }

    Vector3 GetRandomPointDragon(int area)
    {
        Vector3 center = dragonSpawnAreas[area].bounds.center;
        Vector3 size = dragonSpawnAreas[area].bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomZ = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(randomX, center.y, randomZ);
    }

    Vector3 GetRandomPointGem()
    {
        Vector3 center = gemSpawnArea.bounds.center;
        Vector3 size = gemSpawnArea.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomZ = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(randomX, center.y, randomZ);
    }

    void SpawnGem()
    {
        Vector3 randomPoint = GetRandomPointGem();

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            Instantiate(gem, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn point on the NavMesh.");
        }
    }

    public void GameOver()
    {

        Time.timeScale = 0f;

        //Unlocks cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        timeRemaining = 0;
        timerIsRunning = false;
        timeText.text = "";

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
