using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isTargetFlame;
    public float health = 10f;
    public float defaultHealth;
    private void Start()
    {
        defaultHealth = health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isTargetFlame == true)
        {
            health = defaultHealth;
            gameObject.transform.position = new Vector3(Random.Range(-418, 418), 300, 400);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("boom wala");
    }
}
