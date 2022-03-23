using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limo : MonoBehaviour
{
    private int health = 2;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        health--;
        UIManager._instance.UpdateLimoHealthText(health);
        if (health == 0)
        {
            Destroy(gameObject);
            Debug.Log("Limo - OnTriggerEnter() : Game Over!");
        }
    }
}
