using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;

public class Spawner : MonoBehaviour
{
    public GameObject minion;
    public int range = 10000;
    private float currentTime, maxTime;

    private void Start()
    {
        maxTime = 0;
    }


    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            maxTime = currentTime; 
            Vector3 point;
            if (RandomPoint(minion.transform.position, range, out point)) // RandomRange crea un punto random 
            {
                minion.transform.position = point;
                Instantiate(minion, point, Quaternion.identity);
                currentTime = 0;
                maxTime = 5f;
            }
        }
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
