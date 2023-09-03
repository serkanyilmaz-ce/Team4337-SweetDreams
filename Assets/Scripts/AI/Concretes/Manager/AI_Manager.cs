using System;
using Singleton;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace AI.Concretes.Manager
{
    public class AI_Manager : Singleton<AI_Manager>
    {
        public Transform target; // Player
        public IObjectPool<Enemy> Enemies;
        
        public GameObject[] enemyPrefabs;
        [SerializeField] private float minSpawnRate;
        [SerializeField] private float maxSpawnRate;
        [SerializeField] private float randomSpawnRate;
        
        private float _currentSpawnRate;
        private void Awake()
        {
            Enemies = new ObjectPool<Enemy>(() =>
            {
                var enemy = Instantiate(GetRandomPrefab());
                enemy.gameObject.SetActive(false);
                return enemy.GetComponent<Enemy>();
            },defaultCapacity:5,maxSize:100);
        }
        private void Update()
        {
            _currentSpawnRate += Time.deltaTime;

            if (_currentSpawnRate > randomSpawnRate)
            {
                _currentSpawnRate = 0f;
                SetRandomTime();
                Spawn();
            }
        }

        public void Despawn(Enemy enemy)
        {
            enemy.isDead = false;
            enemy.gameObject.SetActive(false);
            Enemies.Release(enemy);
        }

        public void Spawn()
        {
            var poolObject = Enemies.Get();
            poolObject.transform.position = GetRandomSpawnPosition();
            poolObject.gameObject.SetActive(true);
            
        }
        public float GetDistance2D(Vector3 workerPosition, Vector3 target)
        {
            Vector2 customer2Dposition = new Vector2(workerPosition.x, workerPosition.z);
            Vector2 target2Dposition = new Vector2(target.x, target.z);

            float dist = Vector2.Distance(customer2Dposition, target2Dposition);
            return dist;
        }

        private void SetRandomTime() => randomSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);

        private GameObject GetRandomPrefab() => enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        
        public Vector2 GetRandomSpawnPosition()
        {
            Vector2 resultRandomPos = Random.insideUnitCircle * 25;
            
            Vector3 spawnPos = new Vector3(resultRandomPos.x, 0f, resultRandomPos.y);
            Debug.Log(spawnPos);
            return spawnPos;
        }
    }
}