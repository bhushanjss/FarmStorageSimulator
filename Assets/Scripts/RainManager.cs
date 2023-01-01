using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rainPrefab;
    [SerializeField]
    private GameObject rainFolder;

    [SerializeField]
    private float rangeXZ = 10f;
    [SerializeField]
    private float rangeMinY = 10f;
    [SerializeField]
    private float rangeMaxY = 50f;
    [SerializeField]
    private float rainSpeed = 1f;
    [SerializeField]
    private int _rainCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for(int i=0;i < _rainCount; i++)
            {
                float randomPosX = Random.Range(-rangeXZ, rangeXZ);
                float randomPosZ = Random.Range(-rangeXZ, rangeXZ);
                float randomPosY = Random.Range(rangeMinY, rangeMaxY);
                Vector3 pos = new Vector3(randomPosX, randomPosY, randomPosZ);
                GameObject rainDrop = Instantiate(rainPrefab);
                rainDrop.transform.SetParent(rainFolder.transform);
                rainDrop.transform.Translate(pos);
            }            
            float rSpeed = rainSpeed * 0.01f;
            yield return new WaitForSeconds(rSpeed);
        }
    }
}
