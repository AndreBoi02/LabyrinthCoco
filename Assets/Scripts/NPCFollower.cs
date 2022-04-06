using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCFollower : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform transform2Follow;
    [SerializeField] Vector3 sizeOfView; 
    [SerializeField] Vector3 offSet; 
    [SerializeField] LayerMask whatIsCharacter; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        FindCharacter2Follow();

        if (transform2Follow == null)
        {
            return;
        }
        agent.SetDestination(transform2Follow.position);
    }

    void FindCharacter2Follow()
    {
        if (transform2Follow != null) { return; }

        var charaters = Physics.OverlapBox(transform.position + offSet, sizeOfView, Quaternion.identity, whatIsCharacter);
        if (charaters.Length > 0)
        {
            transform2Follow = charaters[0].transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + offSet, sizeOfView);
    }
}
