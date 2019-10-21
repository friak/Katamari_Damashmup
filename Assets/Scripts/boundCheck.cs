using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundCheck : MonoBehaviour {

	public bool                         keepOnScreen = true;
	public float                        radius = 1f;
	public bool                         isOnScreen = true;
	public float                        stageWidth, stageHeight;
    
    [HideInInspector]
	public bool                         offRight, offLeft, offUp, offDown;


	private void LateUpdate(){
        Vector3 finalPos = transform.position;
		isOnScreen = true;
		offRight = offLeft = offUp = offDown = false;

        if(finalPos.x > stageWidth - radius){
            finalPos.x = stageWidth - radius;
			isOnScreen = false;
			offRight = true;
        }

		if(finalPos.x < -stageWidth + radius){
            finalPos.x = -stageWidth + radius;
            isOnScreen = false;
			offLeft = true;
        }
        
		if(finalPos.y > stageHeight - radius){
            finalPos.y = stageHeight - radius;
            isOnScreen = false;
			offUp = true;
        }

		if(finalPos.y < -stageHeight + radius){
            finalPos.y = -stageHeight + radius;
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
