using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kat_Damage : MonoBehaviour
{

    private float dp = 1f;
    private float dp1;
    public GameObject katamari;
    public GameObject deadSound;

    public void ApplyDamage(float amount)
    {
        dp1 = katamari.GetComponent<projectileScript>().damage;
        dp1 -= .08f * amount;
        dp -= amount;
        transform.localScale = new Vector3(dp, 1f);

        if (dp <= 0f)
        {
            Instantiate(deadSound, transform.position, Quaternion.identity);
            SceneManager.LoadScene("Game_Over");
        }
    }
}
