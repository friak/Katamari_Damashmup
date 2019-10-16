using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_Health : MonoBehaviour
{
    private float hp = 1f;
    public GameObject king;
    public GameObject boss_deadSound;

    public void ApplyDamage(float amount)
    {
        hp -= amount;
        transform.localScale = new Vector3(hp, 1f);

        if (hp <= 0f)
        {
            Instantiate(boss_deadSound, transform.position, Quaternion.identity);
            SceneManager.LoadScene("You_Win");
        }
    }
}
