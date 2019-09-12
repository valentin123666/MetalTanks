using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeSpawn : MonoBehaviour
{

    public GameObject left, bottom, Player;
    public GameObject Cell, CellZ, CellZ2, CellX2;

    Vector3 Spawn1, Spawn2;

    [SerializeField]
    private float _timeout = 3;
    private int countMachine = 0, countBour = 0;
    [SerializeField]
    private int contrrolMachin, contrrolBour;
    private float _lastTime;

    public int Witsth;
    public int Height;

    public int countMonsters;

    public Vector3 CellSize = new Vector3(0, 0, 0);

    private void Awake()
    {
        Spawn();

        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    private void Start()
    {
        countMonsters = contrrolBour + contrrolMachin;
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

        if (countMachine < contrrolMachin && countBour < contrrolBour)
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
        else if (countBour < contrrolBour)
        {
            prefabAgent = "MonstersBour";
            countBour++;
        }
        else if (countMachine < contrrolMachin)
        {
            prefabAgent = "MonstersMchine";
            countMachine++;
        }

        if (prefabAgent != null)
        {
            GameObject monsers = PoolMenedger.GetObject(prefabAgent, GetRandomSpawnPoint(), Quaternion.identity);
        }
    }

    private void Spawn()
    {
        MazzeGenirator generator = new MazzeGenirator();
        MazeGineratorCell[,] maze = generator.GinerateMaze(Witsth, Height);
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                int rnd = Random.Range(0, 4);
                float Xfloat = x;
                float Yfloat = y;
                int i = maze.GetLength(0) / 2;
                int j = maze.GetLength(1) / 2;
                #region Spawn
                if ((x > maze.GetLength(0) - 4) && (y > maze.GetLength(1) - 4))
                {
                    Instantiate(Cell, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                }
                else if ((x < 3) && (y > maze.GetLength(1) - 4))
                {
                    Instantiate(Cell, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                }
                else if ((x > i - 2) && (x < i + 2) && (y > j - 2) && (y < j + 2))
                {
                    Instantiate(Cell, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                }
                else
                {
                    if (rnd == 0)
                        Instantiate(Cell, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                    if (rnd == 1)
                        Instantiate(CellZ, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                    if (rnd == 2)
                        Instantiate(CellZ2, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                    if (rnd == 3)
                        Instantiate(CellX2, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                }
                #endregion

                #region Boks
                if (x == maze.GetLength(0) - 1)
                {
                    Xfloat = Xfloat * 10;
                    Instantiate(left, new Vector3(Xfloat + 0.5f * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                }
                if (y == maze.GetLength(1) - 1)
                {
                    Yfloat = Yfloat * 10;
                    Instantiate(bottom, new Vector3(x * CellSize.x, y * CellSize.y, Yfloat + 0.5f * CellSize.z), bottom.transform.rotation);
                }
                if (x == 0)
                    Instantiate(left, new Vector3(Xfloat - 0.5f * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                if (y == 0)
                    Instantiate(bottom, new Vector3(x * CellSize.x, y * CellSize.y, Yfloat - 0.5f * CellSize.z), bottom.transform.rotation);
                #endregion

                #region Coordinates
                if ((x == i) && (y == j))
                {

                    Instantiate(Player, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                }
                if ((x == maze.GetLength(0) - 2) && (y == maze.GetLength(1) - 2))
                {
                    Spawn1 = new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z);
                }
                if ((x == 2) && (y == maze.GetLength(1) - 2))
                {
                    Xfloat = Xfloat * 10;
                    Spawn2 = new Vector3(Xfloat - 1f * CellSize.x, y * CellSize.y, y * CellSize.z);
                }
                #endregion
            }
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int rnd = Random.Range(0, 4);
        if((rnd==0)||(rnd==2))
        {
            return Spawn1;
        }
        else
        {
            return Spawn2;
        }

    }
}


