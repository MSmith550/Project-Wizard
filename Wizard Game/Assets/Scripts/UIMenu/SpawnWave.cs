using System.Collections;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public Transform[] spawnpoints;

    private int waveCount = 0;
    public Transform boss;

    private float searchCountdown = 1f;
    private float timeBetweenSpawns = 1f;
    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    private void Start()
    {
        if(spawnpoints.Length == 0)
        {
            Debug.Log("No Spawnpoints Set");
        }
        
    }
    private void Update()
    {
        if(State == SpawnState.WAITING)
        {
            
            if (EnemyIsAlive() == false)
            {
                WaveCompleted();
                Debug.Log("wave finished");
            }
            else
            {
                return;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (State != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnNewWave(waves[nextWave]));
                waveCount++;
            }
            if (waveCount == 5)
            {
                SpawnBoss(boss);
                waveCount = 0;
            }
        }
        
    }

    //wave completed
    private void WaveCompleted()
    {
        State = SpawnState.COUNTING;

        //loops when reached end of wave array
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }else
        {
            nextWave++;
        }
    }

    //checks to see if all enemys killed
    private bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("No enemys");
                return false;
            }
        }
        return true;
    }
    //IEnumerator for spawning waves
    IEnumerator SpawnNewWave(Wave _wave)
    {
        State = SpawnState.SPAWNING;

        for (int i = 1; i <= _wave.count; i++)
        {
            SpawnEnemys(_wave.enemy);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        State = SpawnState.WAITING;

        yield break;
    }
    //spawns enemys in random spawn locations
    public void SpawnEnemys(Transform _enemy)
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(_enemy, spawnpoint.position, Quaternion.identity);
    }

    public void SpawnBoss(Transform _boss)
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(_boss, spawnpoint.position, Quaternion.identity);
    }
}
