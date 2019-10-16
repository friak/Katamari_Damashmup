using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{

    public float speed = 30f;


    public float camWidth, camHeight;
    public float radius = 1f;

    public string frameState = "idle";

    public Sprite Player_withkat;
    public Sprite Player_nokat;
    public Transform shotPoint;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    public GameObject Katamari;
    public GameObject flingSound;
    public GameObject deadSound;

    public GameObject king_hp;



    private void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }




    void Update()
    {

        if (frameState == "idle")
        {
            spriteRenderer.sprite = Player_withkat;
        }

        if (frameState == "noKat")

        {
            spriteRenderer.sprite = Player_nokat;
            if (GameObject.FindWithTag("KatamariThrown") == null)
            {
                frameState = "idle";
            }
        }

        else if (frameState == "attack")
        {
            frameState = "noKat";
            GameObject atk = Instantiate(Katamari, shotPoint.position, shotPoint.rotation);
            atk.GetComponent<projectileScript>().king_hp = king_hp;
            Instantiate(flingSound, transform.position, Quaternion.identity);
        }




        //MOVEMENT
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Change position based on input
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;


        //MOUSE AIM
        //get mouse position
        Vector3 mousePos = Input.mousePosition;
        //Get object position and put it "on the screen" (same as mouse)
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //Check where the mouse is relative to the object
        Vector3 offset = new Vector3(mousePos.x - screenPos.x, mousePos.y - screenPos.y);

        //Turn that into an angle and convert to degrees
        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
        //Set the object's rotation to be of the angle over 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);



        //ATTACK
        if (Input.GetMouseButtonDown(0) && GameObject.FindWithTag("KatamariThrown") == null)
        {
            frameState = "attack";
        }

    }



    private void LateUpdate()
    {
        Vector3 finalPos = transform.position;

        if (finalPos.x < camWidth - radius)
        {
            finalPos.x = camWidth - radius;
        }
    }



    //DAMAGE
    public bool TakeHit()
    {
        return true;
    }
}
