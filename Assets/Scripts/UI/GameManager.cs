using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Timer")]
    public float timeRemaining = 90;
    public bool timerIsRunning = false;

    [Header("Gem")]

    public GameObject gem;
    private GameObject gemInstance;

    public TextMeshProUGUI timeText;

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
        // Chooses a random int between 0 and 3
        int spawnPoint = Random.Range(0, 2);

        // Spawns dragon at a random Dragon Spawnpoint
        dragonInstance = Instantiate(dragon, dragonSpawnpoints[spawnPoint].position, dragonSpawnpoints[spawnPoint].rotation);
    }

    void SpawnGem()
    {
        Vector3 gemLocation = new Vector3(Random.Range(-13f, 38f), 2f, Random.Range(-89f, -56f));

        gemInstance = Instantiate(gem, gemLocation, Quaternion.identity);
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
