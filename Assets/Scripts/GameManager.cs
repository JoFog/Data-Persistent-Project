using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text bestScoreText;
    public TextMeshProUGUI levelText;
    public GameObject GameOverText;
    private AudioSource leveUpSound;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    private int scorePositon;

    private MainManager mainManager;

    public int brickCount;
    public int level;

    public bool isPaddle; //Verify the last touch of the ball


    // Start is called before the first frame update
    void Start()
    {
        leveUpSound = GetComponent<AudioSource>();
        mainManager = MainManager.Instance;
        scorePositon = 10;
        level = 1;
        isPaddle = false;
        
        LevelSetup(level);
        CompareScore();
        UpdateBestScore();
    }

    void LevelSetup(int level)
    {
        CreatBricks();
        UpdateBrickCount();
        levelText.text = "Lv " + level;
    }

    private void UpdateBrickCount()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
        
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveBall();
                
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        UpdateBrickCount();
        if (brickCount == 0 && isPaddle)
        {
            isPaddle = false;
            level++;
            LevelSetup(level);
            leveUpSound.Play();

        }

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Scr {m_Points}";
        

        CompareScore();
        UpdateBestScore();
        
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

       UpdateScoreTable();
        

    }

    private void CreatBricks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i]; //Defines the point value of the brick
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void MoveBall()
    {
        m_Started = true;
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }

    private void CompareScore()
    {
        // Check if the current score is greater than the best score
        for(int i = scorePositon -1; i >= 0; i--)
        {
            if (m_Points > mainManager.scoredPlayerScore[i] || mainManager.scoredPlayerScore[i] == 0)
            {
                scorePositon = i;
                
            }
           
            
        }
    }

    private void UpdateBestScore() 
    { 
        if(scorePositon == 0)
        {
            bestScoreText.text = "You are THE BEST!";
        }
        else
        {
            bestScoreText.text = $"{scorePositon}- {mainManager.scoredPlayerName[scorePositon - 1]}:\t{mainManager.scoredPlayerScore[scorePositon - 1]}";
        }
            

    }

    private void UpdateScoreTable()
    {
        if (scorePositon < 10)
        {
            if(scorePositon < 9)
            {
                for (int i = 8; i >= scorePositon; i--)
                {
                    mainManager.scoredPlayerName[i + 1] = mainManager.scoredPlayerName[i];
                    mainManager.scoredPlayerScore[i + 1] = mainManager.scoredPlayerScore[i];
                    
                }
            }
            
            mainManager.scoredPlayerName[scorePositon] = mainManager.currentPlayerName;
            mainManager.scoredPlayerScore[scorePositon] = m_Points;
            mainManager.SaveData();
        }
    }

}
