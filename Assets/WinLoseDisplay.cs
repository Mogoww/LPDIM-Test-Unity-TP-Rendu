using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseDisplay : MonoBehaviour
{
    public GameObject DisplayBalls;
    public GameObject Personnage;

    private GameObject[] balls;
    private int CountAllBalls;
    private int BallsCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log("Lose");
            }
            // Debug.Log(_COLLECT_BALLS_);
        }
        
    }
}

        // // get all balls 
        // GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");

        // // get with Me tag
        // GameObject me = GameObject.FindGameObjectWithTag("Me");
        

        // // if Distance me and ball <= 2 delete ball
        // foreach (GameObject ball in balls)
        // {
        //     if (Vector3.Distance(me.transform.position, ball.transform.position) <= 2)
        //     {
        //         // add 1 to _COLLECT_BALLS_
        //         _COLLECT_BALLS_++;

        //         // destroy ball
        //         Destroy(ball);
        //     }
        // }

       
        

        // if(balls.Length == 0)
        // {
        //     // if _COLLECT_BALLS_ < _ALL_BALLS_/2 print lose
        //     if (_COLLECT_BALLS_ < Mathf.Ceil(_ALL_BALLS_/2f))
        //     {
        //         Debug.Log("Lose");
        //     }
        //     // Debug.Log(_COLLECT_BALLS_);
        // }