using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

    public float speed;
    public float distance;
    public float damage;
    public float lifespan;
    public LayerMask Enemy;

    public GameObject boss_hitSound;
    public GameObject deflectSound;
    public GameObject king_hp;
    public GameObject king;


    private void Start()
    {
        GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        RaycastHit2D hitInfo;
            hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, Enemy);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.GetComponent<enemyScript>().TakeHit())
            {
                king_hp.GetComponent<enemy_Health>().ApplyDamage(damage);
                Instantiate(boss_hitSound, transform.position, Quaternion.identity);
            }
            else
            {
                king = GameObject.FindWithTag("Enemy");
                king.GetComponent<enemyScript>().deflect();
                Instantiate(deflectSound, transform.position, Quaternion.identity);
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
