using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text nextLevelText;

    private int score;
    private bool gameOver;
    private bool restart;
    private bool nextLevel;

    void Start()
    {
        gameOver = false;
        restart = false;
        nextLevel = false;
        restartText.text = "";
        gameOverText.text = "";
        nextLevelText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.H))
            {
                SceneManager.LoadScene("Hard");
            }
        }

        if(nextLevel)
        {
            if(Input.GetKeyDown (KeyCode.N))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves ()
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

            

            if(gameOver)
            {
                restartText.text = "Press 'H' to restart Hard Mode";
                restart = true;

                nextLevelText.text = "Press 'N' for Normal Mode";
                nextLevel = true;

                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if(score >= 200)
        {
            winText.text = "You Win!";
            FindObjectOfType<SoundEffects>().WinMusic();
            gameOver = true;
            restart = true;
            gameOverText.text = "Game created by Jemon Golfin!";
        }
    }

    public void GameOver()
    {
           gameOverText.text = "Game Over!";
        FindObjectOfType<SoundEffects>().LoseMusic();

        gameOver = true;
    }
}
