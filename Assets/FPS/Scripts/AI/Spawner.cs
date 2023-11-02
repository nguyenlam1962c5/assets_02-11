using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Danh sách các enemy prefab
    public Transform spawnPoint; // Vị trí spawn cố định
    public float spawnDelay = 5f; // Thời gian delay giữa các lần spawn
    public int maxEnemies = 10; // Giới hạn số lượng enemy trên map

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        // Bắt đầu gọi hàm SpawnEnemy sau mỗi khoảng thời gian spawnDelay
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Kiểm tra nếu đã đạt đến giới hạn enemy trên map
            if (spawnedEnemies.Count < maxEnemies)
            {
                // Ngẫu nhiên chọn một enemy từ danh sách và spawn tại vị trí cố định
                GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPoint.position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Hàm để xóa enemy khỏi danh sách khi bị hủy
    public void RemoveEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }
}