using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float spawnRange = 9.0f;
    private int score;
    public bool isGameActive = true;

    public GameObject Player;
    public GameObject body;
    public GameObject powerupPrefab;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject tittleScreen;

    public void StartGame()
    {
        isGameActive = false;
        tittleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == false)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //If player collides with a wall
        if (other.gameObject.CompareTag("Wall"))
        {
            //Destroy(gameObject);
            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
        //If player collides with a body part
        if (other.gameObject.CompareTag("BodyPart"))
        {
            //Destroy(gameObject);
            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
    }
    //If player collides with a powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            score++;          
        }
    }
    //Generate powerup spawn location
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    //Restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
        isGameActive = true;
    }
}
