using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    private Animator Anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    private Vector3 agentPosition;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();   
        // call DetectAndChangeTarget function 
        target = DetectAndChangeTarget();

    }

    // Update is called once per frame
    void Update()
    {
        if(Anim.GetBool("Death") == false)
        {
            // if target is not null change the agent's destination to the target's position
            if (target != null){
                agent.destination = target.position;
            }
            
            // if target is null or 
            if(target == null){
                target = DetectAndChangeTarget();
            }
        }

        // if press K change Death bool to true
        if (Input.GetKeyDown(KeyCode.K))
        {
            Anim.SetBool("Death", true);
            agent.enabled = false;
        }

    }


     void OnCollisionEnter(Collision other)
    {

            switch (other.gameObject.tag)
            {
                case "Balls":
                    Destroy(other.gameObject);
                    target = null;
                    break;
                default:
                    Debug.Log("rien");
                    break;
            }
    }

    private Transform DetectAndChangeTarget()
    {
        // select all tag "Balls"
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
        // select agent
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        Vector3 targetPosition;
        Transform targetTemporary = null;
        
        // for each ball in the array
        foreach (GameObject ball in balls)
        {
            // get the ball position
            targetPosition = ball.transform.position;
            float distance = Vector3.Distance(targetPosition, agent.transform.position);
            if (targetTemporary == null){
                targetTemporary = ball.transform;
            }
            // if the ball is closer than the current target
            if ( targetTemporary != null && (Vector3.Distance(agent.transform.position, targetTemporary.transform.position) > distance))
            {
                // set the target to the new ball
                targetTemporary = ball.transform;
            }
        }
        return targetTemporary;
    }

}
