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
            gameObject.transform.position = new Vector3(Random.Range(1, -1.5f), 0.58f, 0.56f);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("boom wala");
    }
}
