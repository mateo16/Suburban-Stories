using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public List<GameObject> pedestrianPrefab;
    public int pedestrianToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());   
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < pedestrianToSpawn)
        {
            GameObject obj = Instantiate(pedestrianPrefab[Random.Range(0,pedestrianPrefab.Count-1)]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
