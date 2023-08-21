using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        // enemies++;
        // EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();

    }
}
