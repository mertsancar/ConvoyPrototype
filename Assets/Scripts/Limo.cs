using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limo : MonoBehaviour
{
    public int health = 2;

    void Start()
    {
    }

    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            UIManager._instance.UpdateLimoHealthText(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        health--;
        UIManager._instance.UpdateLimoHealthText(health);
        if (health == 0)
        {
            Destroy(other.gameObject);
        }
    }
}
