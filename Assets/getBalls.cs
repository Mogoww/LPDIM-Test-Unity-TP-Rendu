using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBalls : MonoBehaviour
{
    // const int balls = 3;
    public int _ALL_BALLS_ = 3;
    public int _COLLECT_BALLS_ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get all balls 
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");

        // get with Me tag
        GameObject me = GameObject.FindGameObjectWithTag("Me");
        

        // if Distance me and ball <= 2 delete ball
        foreach (GameObject ball in balls)
        {
            if (Vector3.Distance(me.transform.position, ball.transform.position) <= 2)
            {
                // add 1 to _COLLECT_BALLS_
                _COLLECT_BALLS_++;

                // destroy ball
                Destroy(ball);
            }
        }
    

        // if press a scale up with capsule collider
        if (Input.GetKeyDown(KeyCode.G ))
        {
            // get capsule collider 
            CapsuleCollider capsuleCollider = me.GetComponent<CapsuleCollider>();
            // up Ground Check Distance
            

            // up height of capsule collider
            capsuleCollider.height += 10f;
            // ground check distance of capsule collider = 0.5f
            // capsuleCollider.center = new Vector3(0, 10f, 0);

            // get 

            // // scale up
            me.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            // // scale heigth capsule collider
            // me.GetComponent<Body Mesh>().height += 10f;
            // me.GetComponent<CapsuleCollider>().radius += 0.4f;
            // me.height += 10f;
        }
       
        

        if(balls.Length == 0)
        {
            // if _COLLECT_BALLS_ < _ALL_BALLS_/2 print lose
            if (_COLLECT_BALLS_ < Mathf.Ceil(_ALL_BALLS_/2f))
            {
                Debug.Log("Lose");
            }
            // Debug.Log(_COLLECT_BALLS_);
        }


    }
}
