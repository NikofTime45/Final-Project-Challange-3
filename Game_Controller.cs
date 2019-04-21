using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public int scoreLimit;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text hardModeText;
    public Text creditText;
    public Text hardMode;
    public AudioSource music;
    public AudioClip winClip;
    public AudioClip loseClip;
    public bool gameOver;
    public bool youWin;

    private int score;
    private bool restart;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        youWin = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        creditText.text = "";
        hardModeText.text = "Press 'H' for Hard Mode";
        hardMode.text = "Hard Mode!";
        music = GetComponent<AudioSource>();
     }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("SpaceShooterScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("SpaceShooterScene Hard");
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                break;
            }
            if (youWin)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int NewScoreValue)
    {
        score += NewScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= scoreLimit)
        {
            gameOverText.text = "YOU WIN!";
            creditText.text = "Created by Nicolas Ruiz Rodriguez";
            youWin = true;
            restart = true;
            music.clip = winClip;
            music.Play();
        }
    }


    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        music.clip = loseClip;
        music.Play();
    }
}
