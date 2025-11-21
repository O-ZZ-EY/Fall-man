using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private bool hudActive = false;
    private bool dialogueActive = false;
    private bool pauseActive = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LevelScenes()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); //Call the scene that is 1 more build index than the current one. The current one is 0
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadSceneAsync("Bootstrap");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (!pauseActive)
            {
                SceneManager.LoadSceneAsync("Pause", LoadSceneMode.Additive);
                pauseActive = true;
                Time.timeScale = 0f;
            }
            else
            {
                SceneManager.UnloadSceneAsync("Pause");
                pauseActive = false;
                Time.timeScale = 1f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (!dialogueActive)
            {
                SceneManager.LoadSceneAsync("DialogueUI", LoadSceneMode.Additive);
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadSceneAsync("Credit Screen");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (!hudActive)
            {
                SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadSceneAsync("Physics based");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadSceneAsync("NonPhysics based");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadSceneAsync("Level Selection");
        }
    }
}
