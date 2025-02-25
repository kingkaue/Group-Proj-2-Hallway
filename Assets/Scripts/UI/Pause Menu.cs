using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionAsset PlayerControls;
    private InputAction pauseAction;
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Awake()
    {
        pauseAction = PlayerControls.FindActionMap("Player").FindAction("Pause");   
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.triggered)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        //Unlocks cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
