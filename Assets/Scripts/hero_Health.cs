using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero_Health : MonoBehaviour
{

    private float hp = 1f;
    public GameObject prince;
    public GameObject deadSound;

    public void ApplyDamage(float amount)
    {
        hp -= amount;
        transform.localScale = new Vector3(hp, 1f);

        if (hp <= 0f)
        {
            Instantiate(deadSound, transform.position, Quaternion.identity);
            SceneManager.LoadScene("Game_Over");
        }
    }
}
