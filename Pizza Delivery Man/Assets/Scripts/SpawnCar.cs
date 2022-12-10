using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] MovingObjects _carPrefabs;


    private void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnDelay);

    }
    public void Spawn()
    {
        MovingObjects newCar = Instantiate(_carPrefabs, transform.position,transform.rotation) as MovingObjects;

    }
}
