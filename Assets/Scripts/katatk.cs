using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katatk : MonoBehaviour
{
    public float speed;
    public float distance;
    public float damage;
    public float lifespan;
    public LayerMask Hero;

    public GameObject kathurtSound;
    public GameObject kat_dp;

    private void Start()
    {
        GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        RaycastHit2D hitInfo;
        hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, Hero);
        transform.Translate(Vector2.up * speed * Time.deltaTime);


        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.GetComponent<playerScript>().TakeHit())
            {
                kat_dp.GetComponent<kat_Damage>().ApplyDamage(damage);
                Instantiate(kathurtSound, transform.position, Quaternion.identity);
            }
       
            Destroy(gameObject);
        }

        if (lifespan >= 0)
        {
            lifespan -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
