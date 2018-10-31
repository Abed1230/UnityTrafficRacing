using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private List<Transform> spawnPositions;
    [SerializeField]
    private List<GameObject> cars;
    [SerializeField]
    private GameObject coin;
   
    public void SpawnCar(float speed)
    {
        GameObject car = Instantiate(cars[Random.Range(0, cars.Count)], spawnPositions[Random.Range(0, spawnPositions.Count)]);
        car.GetComponent<SlideDown>().SetSpeed(speed);
    }

    public void SpawnCoin(float speed, int pos)
    {
        GameObject coin = Instantiate(this.coin, spawnPositions[pos]);
        coin.GetComponent<SlideDown>().SetSpeed(speed);
    }

    public int GetSpawnPositionsCount()
    {
        return spawnPositions.Count;
    }
}
