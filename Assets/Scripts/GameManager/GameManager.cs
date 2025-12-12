using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject [] obstacles; // a list of obstacles that will be had in every level

    public List<GameObject> ObstaclesList; //another list 

    public float ObstaclesSpawnRange;

    [Header("Timers")]
    public TMP_Text Timer_Text;
    public float CurrentTimer;
    public float TimerInterval;

    [Header("Potency meter")]

    public TMP_Text potencyMeterText;
    public float potencyMeterCurrent;

    [Header("Attacking")]
    public float Impacto;
    public float CurrentWeaponMultiplier = 10;
    
    public GameObject titleScreenUI;
    public GameObject gamePlayUI;

    public AudioSource audioSource;


    private void Start()
    {
        CurrentTimer = TimerInterval;
        instance = this;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        CurrentTimer -= Time.deltaTime;  
        Timer_Text.text = "Timer: " + Mathf.CeilToInt(CurrentTimer).ToString();  

        if (CurrentTimer <= 0f)
        {

            CurrentTimer = 60f;

        }

        PotencyMeter();

        Impacto = CurrentWeaponMultiplier * potencyMeterCurrent;

    }

    public void StartGame()
    {
        titleScreenUI.SetActive(false);
        gamePlayUI.SetActive(true);

        Time.timeScale = 1f;
        audioSource.Play();
    }
    
    void SpawnObject(GameObject prefab)
    {
         Vector3 position;

        position = Random.insideUnitSphere * ObstaclesSpawnRange;
        position.z = 0f;

        ObstaclesList.Add(Instantiate(prefab, position, Quaternion.identity));
    }

    void PotencyMeter()
    {
        potencyMeterText.text = "Potency:" + Mathf.CeilToInt(potencyMeterCurrent).ToString();
    }

   public enum PlayerState
    {
        FREEFALLING = 0,
        IMPACT = 1,
        GROUNDED = 2,
        DEAD = 3,
        JUMPING = 4
    }


}
