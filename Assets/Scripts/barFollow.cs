using UnityEngine;
using System.Collections;

public class barFollow : MonoBehaviour
{
    public float speed = 30f;
    public Transform target;


    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}
