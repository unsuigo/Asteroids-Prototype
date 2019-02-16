using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonT;

public class GameManager : SingletonT<GameManager>
{
    [Header("Spawn Prefabs")]
    public GameObject shipPrefab;
    public GameObject asteroidLPrefab;
    public GameObject screenBorder;


    [Header("Max Lives")]
    public int maxLives;
    [Header("Debug Score")]
    public int life = 0;
    public int score = 0;
    public int highrScore = 0;

    [Header("Levels Setup")]
    public int qtyAsteroidsLevel0;
    public int level;
    public int timeDelaySpawnAsteroids;
    GameObject ship;


    void Start()
    {
        //ScreenBorder for loop the screen
        Instantiate(screenBorder, transform.position, transform.rotation);
        UpdateHighScore();
    }

    //from begin
    public void StartGame()
    {
        score = 0;
        gameObject.SendMessage("OnUpdateScore", score);


        life = maxLives;
        gameObject.SendMessage("OnUpdateLife", life);
        StartCoroutine(SpawnLevel_0());
    }

    //still have life
    public void OnReset()
    {
        CleanScene();

        Invoke("Restart", 2);
    }


    void Restart()
    {
        StoreData();
        score = 0;
        gameObject.SendMessage("OnUpdateScore", score);
        StartCoroutine(SpawnLevel_0());
    }



   public void OnScoreAdd(int points)
    {
        // Debug.Log("Got Points " + points);
        score += points;
        // Debug.Log("Score is " + score);
        gameObject.SendMessage("OnUpdateScore", score);
    }


    //invoke from collisions
   public void OnMinusLife()
    {
        // Debug.Log("Dead");
        life -= 1;
        //  Debug.Log("Lifes left " + life);
        gameObject.SendMessage("OnUpdateLife", life);
        if (life <= 0)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            OnReset();
        }

    }

    IEnumerator GameOver()
    {
        CleanScene();
        Debug.Log("************Game Over**************");
        gameObject.SendMessage("GameOverUI");
       
        yield return new WaitForSeconds(2);
        UpdateHighScore();
        gameObject.SendMessage("GameOverMenuUI");
    }

    void NextLevel()
    {
        Debug.Log("************next level**************");
    }

    void UpdateHighScore()
    {
        highrScore = PlayerPrefs.GetInt("HighScore", 0);
        gameObject.SendMessage("OnUpdateHighScore", highrScore);
    }




    IEnumerator SpawnLevel_0()
    {
        ship = Instantiate(shipPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(timeDelaySpawnAsteroids);

        // spawn any qty  of asteroids
        for (int i = 0; i < qtyAsteroidsLevel0; i++)
        {
            Instantiate(asteroidLPrefab, RandomSpawnPos(), transform.rotation);
        }
    }


    Vector2 RandomSpawnPos()
    {
        float screenY = Camera.main.orthographicSize;
        float screenX = screenY * Camera.main.aspect;

        Vector2 asteroidSpawPos = new Vector2(transform.position.x, transform.position.y);
        asteroidSpawPos.y = screenY + 5.0f;
        asteroidSpawPos.x = Random.Range(screenX, -screenX);

        return asteroidSpawPos;
    }


    void StoreData()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void CleanScene()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        if (asteroids != null)
        {
            foreach (GameObject asteroid in asteroids)
            {
                Destroy(asteroid);
            }
        }

        if (ship != null)
            Destroy(ship);
            
        StoreData();
    }

    void OnDestroy()
    {
        StoreData();
    }
}
