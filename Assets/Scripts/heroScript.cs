using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour {
    
	static public heroScript            S;

	[Header("Set in Inspector")]
	public float                        speed = 30f;
	public float                        rollMult = -45f;
	public float                        pitchMult = 30f;
	public float                        gameRestartDelay = 2f;
	public GameObject                   Katamari;
	public float                        projectileSpeed = 50f;

    [Header("Set Dynmaically")]
    // Make it viasible in the inspector
	[SerializeField]          
	private float                       _shieldLevel = 1;
	public float                        camWidth, camHeight;
	public float                        radius = 1f;

	private GameObject                  lastTriggerGo = null;

    // Use this for initialization
    void Awake () {
		if(S == null){
			S = this;
		} else {
			Debug.LogError("heroScript.Awake() - Attempted to assign a second heroScript.S!");
		}

		camHeight = Camera.main.orthographicSize;
		camWidth = camHeight * Camera.main.aspect;

	}
	
	// Update is called once per frame
	void Update () {
		// Pull in info from the Input class
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");

        // Change position based on input
		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;

        // Add rotation for a little wow factor!
		transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

        // Allow the ship to fire
		if(Input.GetKeyDown(KeyCode.Space) && (GameObject.FindWithTag("KatamariThrown") != null))
        {
			Throw();
		}
	}

	private void LateUpdate(){
		Vector3 finalPos = transform.position;

		if(finalPos.x < camWidth - radius){
			finalPos.x = camWidth - radius;
		}
	}

    void Throw()
    {
        Destroy(this.gameObject);
        GameObject throwKatamari = Instantiate<GameObject>(Katamari);
        throwKatamari.transform.position = transform.position;
        Rigidbody rb = throwKatamari.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * projectileSpeed;
	}
    
	void OnTriggerEnter(Collider other){
		Transform rootT = other.gameObject.transform.root;
		GameObject go = rootT.gameObject;
		print("Triggered: " + go.name);

        // Make sure this is a different game object
		if(go == lastTriggerGo) return;
		lastTriggerGo = go;

		if(go.tag == "Enemy"){
			shieldLevel--;
			Destroy(go);
		} else {
			print("Triggered by non-enemy: " + go.name);
		}
	}

	public float shieldLevel {
		get {
			return(_shieldLevel);
		}
		set {
			_shieldLevel = Mathf.Min(value, 4);
            // if shield is going to be less than zero...
			if(value < 0){
				Destroy(this.gameObject);
				gameManager.S.DelayedRestart(gameRestartDelay);
			}
		}
	}
}
