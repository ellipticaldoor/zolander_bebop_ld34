using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Wave[] waves;
	public Enemy enemy;
	public GameObject[] spawn;
	public GameObject[] trigger;
	public GameObject player;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;

	public GameObject mainAudio;

	void Start() {
		//NextWave ();
		mainAudio = GameObject.FindGameObjectWithTag ("MainAudio");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate() {
		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

			Enemy spawnedEnemy = Instantiate (enemy, spawn [currentWaveNumber - 1].transform.position, Quaternion.identity) as Enemy;

			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath() {
		enemiesRemainingAlive--;

		if (enemiesRemainingAlive == 0) {
			//NextWave ();
			mainAudio.GetComponent<MainAudio> ().PlayThemeSong ();
			player.GetComponent<Player> ().setShootFalse ();
		}
	}

	public void NextWave() {
		currentWaveNumber ++;
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];
			
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive += enemiesRemainingToSpawn;
		}
	}

	
	[System.Serializable]
	public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}
