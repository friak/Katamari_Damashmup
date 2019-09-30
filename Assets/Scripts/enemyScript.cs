using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	public float            speed = 10f;
	public float            fireRate = 0.3f;
	public float            health = 10f;
	public int              score = 100;

	private boundCheck      bndCheck;        

	void Awake(){
		bndCheck = GetComponent<boundCheck>();
	}


	public Vector3 pos {
		get {
			return(this.transform.position );
		}
		set {
			this.transform.position = value;
		}
	}

	// Update is called once per frame
	void Update () {
		Move();

		Debug.Log(bndCheck.camHeight);

		if(bndCheck != null && bndCheck.offDown){
			if(pos.y < bndCheck.camHeight - bndCheck.radius){
				// We're at gthe bottom
				Destroy(gameObject);
			}
		}

	}

	public virtual void Move(){
		Vector3 tempPos = pos;
		tempPos.y -= speed * Time.deltaTime;
		pos = tempPos;
	}

	void OnCollisionEnter(Collision coll){
		GameObject otherGO = coll.gameObject;
		Debug.Log(otherGO.tag);
		if(otherGO.tag == "ProjectileHero"){
			Destroy(otherGO);
			Destroy(gameObject);
		} else {
			print("Enemy hit by non-ProjectileHero: " + otherGO.name);
		}
	}
}