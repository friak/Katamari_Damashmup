using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk : MonoBehaviour
{

    public float speed;
    public float distance;
    public float damage;
    public float lifespan;
    public LayerMask Hero;

    public GameObject prince_hitSound;
    public GameObject prince_hp;


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
                prince_hp.GetComponent<hero_Health>().ApplyDamage(damage);
                Instantiate(prince_hitSound, transform.position, Quaternion.identity);
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
