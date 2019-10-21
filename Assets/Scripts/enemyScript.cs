using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    public float speed;
    public float stop;
    private Transform target;
    public Transform shotPoint;

    private boundCheck bndCheck;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    public string frameState = "idle";
    public float timeOut1 = 0f;
    public float timeOut2 = 0f;

    public float vunPeriod = 0f;

    public GameObject atk1Sound;
    public GameObject atk2Sound;
    public GameObject deflectSound;
    public GameObject boss_deadSound;


    public GameObject atk1;
    public GameObject[] atk2;
    public GameObject prince_hp;
    public GameObject kat_dp;

    public GameObject text;
    public bool textseen;

    public Sprite king_shield;
    public Sprite king;
    public Sprite king_deflect;

    private SpriteRenderer spriteRenderer;



    void Awake()
    {
        bndCheck = GetComponent<boundCheck>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        text.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetActive(false);

        if (Vector2.Distance(transform.position, target.position) > stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

       if (timeOut1 >= 0)
        {
            timeOut1 -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
        }
       else
        {
            timeOut1 = 12f;
            frameState = "attack1";
            }

        if (timeOut2 >= 0)
        {
            timeOut2 -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
        }
        else
        {
            timeOut2 = 5f;
            frameState = "attack2";
        }

        if (frameState == "idle")
        {
            spriteRenderer.sprite = king_shield;
            Debug.Log("safe");
        }


        if (frameState == "attack1")
        {
            frameState = "vunerable";
            Instantiate(atk1Sound, transform.position, Quaternion.identity);
        }
        if (frameState == "attack2")
        {
            Instantiate(atk2Sound, transform.position, Quaternion.identity);
            GameObject atk11 = Instantiate(atk2[Random.Range(0, atk2.Length)], shotPoint.position, shotPoint.rotation);
            atk11.GetComponent<katatk>().kat_dp = kat_dp;
            frameState = "idle";
        }


        if (frameState == "vunerable")
        {

            if (vunPeriod >= 0)
            {
                spriteRenderer.sprite = king;
                GameObject atk = Instantiate(atk1, shotPoint.position, shotPoint.rotation);
                text.SetActive(true);
                atk.GetComponent<atk>().prince_hp = prince_hp;
                vunPeriod -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
                frameState = "idle";
                text.GetComponent<textactive>().seen = false;
                vunPeriod = 5f;
                Debug.Log("vunerable");
            }
 
        }

    }

    public void deflect()
    {
        spriteRenderer.sprite = king_deflect;
    }

    public bool TakeHit()
    {
        if (frameState == "vunerable")
        {
            return true;
        }
        return false;
    }
}

