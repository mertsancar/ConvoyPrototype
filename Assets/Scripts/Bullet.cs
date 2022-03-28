using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private Vector3 shootDir;

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
    }

    void Start()
    {
        //transform.position = shootDir;
        //m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        //m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveSpeed = 100f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
        //m_Rigidbody.AddForce(transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hellö");
        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }
}
