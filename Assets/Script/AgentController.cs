using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    private Animator Anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    private Transform targetTemporary;
    private Vector3 agentPosition;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Anim = GetComponent<Animator>();   

        // get agent position
        agentPosition = agent.transform.position;

        // // select all tag "Balls"
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
        
        // for each ball in the array
        foreach (GameObject ball in balls)
        {
            // get the ball position
            targetPosition = ball.transform.position;
            float distance = Vector3.Distance(targetPosition, agentPosition);
            if (targetTemporary == null){
                targetTemporary = ball.transform;
            }
            // if the ball is closer than the current target
            if ( targetTemporary != null && (Vector3.Distance(agentPosition, targetTemporary.transform.position) > distance))
            {
                // set the target to the new ball
                targetTemporary = ball.transform;
            }
        }
        target = targetTemporary;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (target != null)
        {
            // get the target position
            agent.destination = target.position;
        }
        // get agent position
        agentPosition = agent.transform.position;

        // // select all tag "Balls"
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
        
        if(target == null){
            // for each ball in the array
            foreach (GameObject ball in balls)
            {
                // get the ball position
                targetPosition = ball.transform.position;
                float distance = Vector3.Distance(targetPosition, agentPosition);
                if (targetTemporary == null){
                    targetTemporary = ball.transform;
                }
                // if the ball is closer than the current target
                if ( targetTemporary != null && (Vector3.Distance(agentPosition, targetTemporary.transform.position) > distance))
                {
                    // set the target to the new ball
                    targetTemporary = ball.transform;
                }  
            }
            target = targetTemporary;
        }

        // if the agent touched the target delete the target
        if (target != null && Vector3.Distance(agentPosition, target.transform.position) < 2)
        {
            
            Destroy(target.gameObject);
            target = null;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Prof")
        {
            Anim.SetBool("Idle", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Prof")
        {
            Anim.SetBool("Idle", false);
        }
    }
}
