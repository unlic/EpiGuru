using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObstacleMovement block;
    [SerializeField] private ObstacleMovement coin;

    [SerializeField] private GameLogic gameController;

    private float spawnDelay = 1f;

    private int minSpawnPosition = -6;
    private int maxSpawnPosition = 6;
    
    void Start()
    {
        StartCoroutine(SpawnObject());
        gameController.GameOver += GemeOver;
    }

    
    private Vector3 TakeSpawnPosition(int min, int max)
    {
        float x = Random.Range(min, max);

        Vector3 spawnPosition = new Vector3(x, 1, 85);

        return spawnPosition;
    }

    private void SpawnLine()
    {
        int spawnLine = Random.Range(0, 4);

        switch (spawnLine)
        {
            case 0:
                Spawn(TakeSpawnPosition(minSpawnPosition, maxSpawnPosition), block);
                break;
            case 1:
                Spawn(TakeSpawnPosition(minSpawnPosition, 0), block);
                Spawn(TakeSpawnPosition(0, maxSpawnPosition), coin);
                break;
            case 2:
                Spawn(TakeSpawnPosition(minSpawnPosition, 0), coin);
                Spawn(TakeSpawnPosition(0, maxSpawnPosition), block);
                break;
            case 3:
                Spawn(TakeSpawnPosition(minSpawnPosition, 0), block);
                Spawn(TakeSpawnPosition(0, maxSpawnPosition), block);
                break;
            default:
                break;
        }

        Debug.Log(spawnLine);
    }

    private void Spawn(Vector3 position, ObstacleMovement obstacle)
    {
        Instantiate(obstacle, position, block.transform.rotation).gameLogic = gameController;
    }

    private IEnumerator SpawnObject()
    {

        while (true) 
        {
            SpawnLine();
            yield return new WaitForSeconds(spawnDelay);
        }
       
    }

    private void GemeOver()
    {
        StopAllCoroutines();
        ObstacleMovement.StopMovingAction?.Invoke();
    }
}
