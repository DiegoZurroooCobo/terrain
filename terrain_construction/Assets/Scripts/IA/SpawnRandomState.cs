using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "SpawnRandomState (S)", menuName = "ScriptableObject/States/SpawnRandomStates")]
public class SpawnRandomState : State
{
public float currentTime = 0;
    public float maxTime = 2.5f;

    public float range = 10000f;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        if (Mathf.Approximately(navMeshAgent.remainingDistance, navMeshAgent.stoppingDistance)) //Si la distancia hasta un punto y la distancia de frenas se aproximan,
                                                                                                //empieza a subir el tiempo
            currentTime += Time.deltaTime;

        if (currentTime >= maxTime) // su currentTime es mayor o igual al maxTime
        {
            currentTime = 0f; // el currentTime se resetea
            Vector3 point;
            if (RandomPoint(owner.transform.position, range, out point)) // RandomRange crea un punto random 
            {
                owner.transform.position = point;
            }
        }

        return nextState;
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result) // booleano que calcula un punto random 
    {
        for (int i = 0; i < 30; i++) // ns porque es 30 :/
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            // El Vector3 randompoint calculo un punto random desde el centro del objeto,
            // multiplicando el random.InsideUnitSphere con el rango (El numero de range se lo damos nosotros) 
            // Random.InsideUnitSpehere es un metodo de Unity que devuelve un punto random dentro o en un esfera de radio 1
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
            //NavMesh.SamplePosition encuentra el punto mas cercano en un rango especifico. Debe tener un origen de la posicion, un hit que gaurda la posicion,
            //la distancia maxima a la que puede ir y las masl layer por las que puede ir (en este caso, todas las NavMesh)
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
