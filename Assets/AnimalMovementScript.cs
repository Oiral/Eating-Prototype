using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovementScript : MonoBehaviour {

    NavMeshAgent agent;

    public float distanceToCheckforMesh;

    public Vector3 travelPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(SetNewPoint());
    }

    private void Update()
    {
        if (travelPoint != new Vector3(0,1000,0))
        {
            if (Vector3.Distance(travelPoint, transform.position) < 2)
            {
                StartCoroutine(SetNewPoint());
            }
        }

    }

    IEnumerator SetNewPoint()
    {
        travelPoint = new Vector3(0,1000,0);
        while(RandomNavPoint() == false)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    bool RandomNavPoint()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * distanceToCheckforMesh;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                travelPoint = hit.position;
                agent.SetDestination(travelPoint);
                return true;
            }
        }
        return false;
    }

}
