using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnenyController : MonoBehaviour
{
    public GameObject enemy;

    private BoxCollider2D box;
    // Start is called before the first frame update
    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        float minX = -box.bounds.size.x/2;
        float maxX = box.bounds.size.x/2;

        Vector3 temp = transform.position;

        temp.x = Random.Range(minX, maxX);
        
        
       var go = SmartPool.Instance.Spawn(enemy, temp, Quaternion.identity);
        go.transform.localScale = new Vector3(3,3,3);

        StartCoroutine(EnemySpawn());
    }
}
