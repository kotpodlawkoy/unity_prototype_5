using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum DifficultyLevel { Easy, Medium, Hard };
    [SerializeField] private List < GameObject > targets;
    private float minSpawnRate;
    private float maxSpawnRate;
    private float spawnRate = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    private int score;
    public int lives;
    public bool isGameOver = true;
    public bool isGamePaused = false;

    private AudioSource backgroundMusic;
    public Slider volumeSlider;

    void Start ()
    {
        backgroundMusic = GetComponent < AudioSource > ();
        volumeSlider.onValueChanged.AddListener ( delegate { UpdateMusicVolume (); } );
    }

    void Update ()
    {
        if ( !isGameOver && Input.GetKeyDown ( KeyCode.Space ) )
        {
            Time.timeScale = System.Convert.ToInt32 ( isGamePaused );
            isGamePaused = !isGamePaused;
            pauseScreen.SetActive ( isGamePaused );
        }
    }
    
    public void StartTheGame ( DifficultyLevel currentLevel )
    {
        isGameOver = false;
        switch ( currentLevel )
        {
            case DifficultyLevel.Easy:
                minSpawnRate = 1f;
                maxSpawnRate = 2f;
                break;
            case DifficultyLevel.Medium:
                minSpawnRate = 1f;
                maxSpawnRate = 1f;
                break;
            case DifficultyLevel.Hard:
                minSpawnRate = 0f;
                maxSpawnRate = 1f;
                break;
            default: break;
        }
        titleScreen.SetActive ( false );
        score = 0;
        UpdateScore ( 0 );
        DealDamage ( 0 );
        scoreText.gameObject.SetActive ( true );
        livesText.gameObject.SetActive ( true );
        StartCoroutine ( SpawnTarget () );
    }

    public void UpdateScore ( int scoreAdd )
    {
        score += scoreAdd;
        scoreText.text = $"Score:{score}";
    }

    public void DealDamage ( int damage )
    {
        lives -= damage;
        livesText.text = $"Lives:{lives}";
        if ( lives == 0)
        {
            GameOver ();
        }
    }

    public void UpdateMusicVolume ()
    {
        backgroundMusic.volume = volumeSlider.value * 0.1f;
    }

    public void GameOver ()
    {
        gameOverScreen.SetActive ( true );
        isGameOver = true;
    }

    public void Restart ()
    {
        SceneManager.LoadScene ( SceneManager.GetActiveScene ().name );
    }

    IEnumerator SpawnTarget ()
    {
        while ( !isGameOver )
        {
            yield return new WaitForSeconds ( spawnRate );
            Instantiate ( targets [ Random.Range ( 0, targets.Count ) ] );
            spawnRate = Random.Range ( minSpawnRate, maxSpawnRate );
        }
    }
}
