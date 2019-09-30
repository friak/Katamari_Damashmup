using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundCheck : MonoBehaviour {

	[Header("Set in Unity Insepctor")]
	public bool                         keepOnScreen = true;
	public float                        radius = 1f;

	[Header("Set Dynamically")]
	public bool                         isOnScreen = true;
	public float                        camWidth, camHeight;
    
    [HideInInspector]
	public bool                         offRight, offLeft, offUp, offDown;

	// Use this for initialization
	void Awake () {
		camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
	}

	private void LateUpdate(){
        Vector3 finalPos = transform.position;
		isOnScreen = true;
		offRight = offLeft = offUp = offDown = false;

        if(finalPos.x > camWidth - radius){
            finalPos.x = camWidth - radius;
			isOnScreen = false;
			offRight = true;
        }

		if(finalPos.x < -camWidth + radius){
            finalPos.x = -camWidth + radius;
            isOnScreen = false;
			offLeft = true;
        }
        
		if(finalPos.y > camHeight - radius){
            finalPos.y = camHeight - radius;
            isOnScreen = false;
			offUp = true;
        }

		if(finalPos.y < -camHeight + radius){
            finalPos.y = -camHeight + radius;
            isOnScreen = false;
			offDown = true;
        }

		isOnScreen = !(offRight || offLeft || offUp || offDown);
		if(keepOnScreen && !isOnScreen){
			transform.position = finalPos;
			isOnScreen = true;
			offRight = offLeft = offUp = offDown = false;
        }
    }
}
