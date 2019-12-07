using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public EnemyTypes[] Types;

    bool IsInfinite;

    public Transform HighestV, LowestV;

    public float EnemyNMultiplier;

    [SerializeField]
    int CurrentWave;

    Transform EnemyParent;

    private void Awake()
    {
        EnemyParent = GameManager.manager.EnemyParent;    
    }

    public void CallSpawnWave()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        CurrentWave++;

        EnemyNMultiplier += (0.03f * CurrentWave);
        GameManager.manager.IncreaseMultiplier();

        foreach (EnemyTypes T in Types)
        {

            if(T.FirstWave <= CurrentWave)
            {
                StartCoroutine(CallSpawnEnemy(T));
                yield return new WaitForSeconds(0.6f);
            }

        }

    }

    IEnumerator CallSpawnEnemy(EnemyTypes T)
    {
        int noe = Mathf.FloorToInt(T.Lenght * EnemyNMultiplier);

        for (int i = 0; i < noe; i++)
        {
            float w = Random.Range(0.6f, 1.2f);

            yield return new WaitForSeconds(w);

            SpawnEnemy(T);
        }
    }

    void SpawnEnemy(EnemyTypes T)
    {

        float r = Random.Range(LowestV.position.y, HighestV.position.y);

        Instantiate(T.Prefab, new Vector3(HighestV.position.x, r), Quaternion.identity, EnemyParent);

    }

}
