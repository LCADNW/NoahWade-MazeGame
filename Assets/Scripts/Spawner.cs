using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;



    private void Start()
    {
        TakeInSpawnPointChildrens();
        Spawn();
    }

    void TakeInSpawnPointChildrens()
    {
        spawnPoints = new GameObject[transform.childCount];
        for(int i = 0; i < gameObject.transform.childCount; i++)
            spawnPoints[i] = transform.GetChild(i).gameObject;

    }

    void Spawn()
    {
        foreach(var spawnPoint in spawnPoints)
        {
            GameObject spawned = Instantiate(enemyPrefab, spawnPoint.transform, false);
            int canMoveInt = Random.Range(0, 8);
            if(canMoveInt >= 5)
                spawned.GetComponent<Watcher>().canAttack = true;

            if(canMoveInt == 0)
            {
                spawned.SetActive(false);
            }


        }
    }

}
