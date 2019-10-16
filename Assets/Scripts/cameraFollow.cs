using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{

    public GameObject target;
    public float smoothSpeed = .125f;
    public Vector3 offset;
    Vector3 targetPos;
 

    void Start()
    {
        targetPos = transform.position;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posZ = transform.position;
            posZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position + offset - posZ);
            transform.position = Vector3. Lerp(transform.position, targetPos + offset - posZ, .005f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetDirection, smoothSpeed);
            transform.position = smoothedPosition;

        }
    }
}
