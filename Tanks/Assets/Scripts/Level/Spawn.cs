using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public Vector3 centerMaps, Spawn1, Spawn2;    
    
    [SerializeField]
    private float _timeout = 3;
    private int countMachine = 0, countBour = 0;
    private float _lastTime;

    private void Awake()
    {
        //   Spawn1 = GameObject.FindWithTag("Spawn1");
        // Spawn2 = GameObject.FindWithTag("Spawn2");
        // centerMaps = GameObject.FindWithTag("CenterMaps");
    //    centerMaps = gameObject.GetComponent<MazeSpawn>().CenteMaps.transform.position;
        Instantiate(player, centerMaps, Quaternion.identity);
        Debug.Log("" + centerMaps);

      //  AddComponent();
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

        string prefabAgent = null;

        if (countMachine < 7 && countBour < 3)
        {
            if (Random.Range(0, 4) == 0)
            {
                prefabAgent = "MonstersBour";
                countBour++;
            }
            else
            {
                prefabAgent = "MonstersMchine";
                countMachine++;
            }
        }
        else if (countBour < 3)
        {
            prefabAgent = "MonstersBour";
            countBour++;
        }
        else if (countMachine < 7)
        {
            prefabAgent = "MonstersMchine";
            countMachine++;
        }

        if (prefabAgent != null)
        {
            GameObject monsers = PoolMenedjer.GetObject(prefabAgent, Spawn1, Quaternion.identity);
        }
    }

 //   private GameObject GetRandomSpawnPoint()
   // {
      //  return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    //}

}
