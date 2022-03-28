using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public GameObject startPoint;
    public GameObject bullets;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist <= 80)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        Debug.Log("Enemy() -> Fire");
        //GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        //bullet.GetComponent<Rigidbody>().AddForce(player.transform.position, ForceMode.Force);

        Transform bulletTransform = Instantiate(projectile.transform, transform.position, Quaternion.identity);
        bulletTransform.SetParent(bullets.transform);
        //Vector3 shootDir = (player.transform.position - transform.position).normalized;
        Vector3 shootDir = -Vector3.forward;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir);
        yield return new WaitForSeconds(1f);
    }

}
