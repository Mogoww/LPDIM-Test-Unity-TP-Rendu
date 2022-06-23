using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseDisplay : MonoBehaviour
{
    public GameObject DisplayBalls;
    public GameObject Personnage;
    public GameObject WinMenuUI;
    public GameObject LoseMenuUI;

    private GameObject[] balls;
    private int CountAllBalls;
    private int BallsCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        // get all ball with tag "Balls"
        balls = GameObject.FindGameObjectsWithTag("Balls");
        CountAllBalls = balls.Length;
        DisplayBalls.GetComponent<UnityEngine.UI.Text>().text = 0.ToString() + "/" + CountAllBalls.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Balls");

        foreach (GameObject ball in balls)
        {
            if (Vector3.Distance(Personnage.transform.position, ball.transform.position) <= 2)
            {
                // incremente BallsCollected
                BallsCollected++;
                DisplayBalls.GetComponent<UnityEngine.UI.Text>().text = BallsCollected.ToString() + "/" + CountAllBalls.ToString();
                // destroy ball
                Destroy(ball);
            }
        }


        if(balls.Length == 0)
        {
            // if _COLLECT_BALLS_ < _ALL_BALLS_/2 print lose
            if (BallsCollected < Mathf.Ceil(CountAllBalls/2f))
            {
                Time.timeScale = 0;
                LoseMenuUI.SetActive(true);
            }else
            {
                Time.timeScale = 0;
                WinMenuUI.SetActive(true);
            }
        }
        
    }



    public void LoadMenu()
    {
        // load pause menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}