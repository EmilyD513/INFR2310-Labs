using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    //public GameObject Target;
    private NavMeshAgent agent;
    public RayCaster raycaster;
    public Animator animator;
    bool isPlayerWalking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {

        //agent.destination = Target.transform.position;
        agent.destination = raycaster.raycast;

        if (agent.transform.position != agent.destination)
        {
            isPlayerWalking = true;
            animator.SetBool("isPlayerWalking", isPlayerWalking);
        }    
        else
        {
            isPlayerWalking = false;
            animator.SetBool("isPlayerWalking", isPlayerWalking);
        }    

    }

    private void OnTriggerEnter(Collider other)      //if it hits the target
    {
        if (other.tag.Equals("Hammer"))
        {
            Debug.Log("Player has picked up the hammer");
            Destroy(GameObject.FindGameObjectWithTag("Hammer"));
        }

        if (other.tag.Equals("Spoon"))
        {
            Debug.Log("Player has picked up the spoon");
            Destroy(GameObject.FindGameObjectWithTag("Spoon"));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Target")
        {           
            //edit here
        }
    }

}
