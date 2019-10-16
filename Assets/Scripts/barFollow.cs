using UnityEngine;
using System.Collections;

public class barFollow : MonoBehaviour
{
    public float speed = 30f;
    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BarPoint").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}
