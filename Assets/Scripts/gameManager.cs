using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
	static public gameManager S;

	[Header("Set in Inspector")] 
	public GameObject[] 			prefabEnemies;
	public float 					enemySpawnPerSecond = 0.5f;
	public float 					enemyDefaultPadding = 1.5f;

	private boundCheck              bndCheck;

	void Awake(){
		S = this;
		bndCheck = GetComponent<boundCheck>();
		Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
	}

	public void SpawnEnemy(){
		// Pick a random enemy to spawn
		int ndx = Random.Range(0, prefabEnemies.Length);
		GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // position the enemy above the screen at a random x
		float enemyPadding = enemyDefaultPadding;
		if(go.GetComponent<boundCheck>() != null){
			enemyPadding = Mathf.Abs(go.GetComponent<boundCheck>().radius);
		}

        // Set the initial position for the enemy
		Vector2 pos = Vector2.zero;
		float xMin = -bndCheck.camWidth + enemyPadding;
		float xMax = bndCheck.camWidth - enemyPadding;
		pos.x = Random.Range(xMin, xMax);
		pos.y = bndCheck.camHeight + enemyPadding;
		go.transform.position = pos;

        // Invoke Again
		Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
	}


	public void DelayedRestart(float delay){
		// Invoke the restart in delay seconds
		Invoke("Restart", delay);
	}

	public void Restart(){
		// Reload the scene
		SceneManager.LoadScene("scene0");
	}

}
