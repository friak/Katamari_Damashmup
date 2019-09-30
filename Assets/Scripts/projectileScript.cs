using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	private boundCheck              bndCheck;

	void Awake(){
		bndCheck = GetComponent<boundCheck>();
	}
	
	// Update is called once per frame
	void Update () {
		if(bndCheck.offUp){
			Destroy(gameObject);
		}
	}
}
