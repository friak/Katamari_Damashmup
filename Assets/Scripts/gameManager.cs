using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
	static public gameManager S;

	private boundCheck              bndCheck;

	void Awake(){
		S = this;
		bndCheck = GetComponent<boundCheck>();
	}


	public void DelayedRestart(float delay){
		// Invoke the restart in delay seconds
		Invoke("Restart", delay);
	}

	public void Restart(){
		// Reload the scene
		SceneManager.LoadScene("battle_phase");
	}

}
