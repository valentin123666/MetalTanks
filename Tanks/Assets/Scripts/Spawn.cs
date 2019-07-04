using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject player, bour, machine, centerMaps;
    [SerializeField]
    private List<GameObject> _spawnPoints;
    [SerializeField]
    private float _timeout = 3;
    private int countMachine = 0, countBour = 0;
    private float _lastTime;

    private void Awake()
    {
        Instantiate(player, centerMaps.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        Tick();
    }

    private void Tick()
    {
        if (Time.time - _lastTime < _timeout)
        {
            return;
        }
        _lastTime = Time.time;

        GameObject prefabAgent = null;

        if (countMachine < 7 && countBour < 3)
        {
            if (Random.Range(0, 4) == 0)
            {
                prefabAgent = bour;
                countBour++;
            }
            else
            {
                prefabAgent = machine;
                countMachine++;
            }
        }
        else if (countBour < 3)
        {
            prefabAgent = bour;
            countBour++;
        }
        else if (countMachine < 7)
        {
            prefabAgent = machine;
            countMachine++;
        }

        if (prefabAgent != null)
        {
            Instantiate(prefabAgent, GetRandomSpawnPoint().transform.position, Quaternion.identity);
        }
    }

    private GameObject GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
