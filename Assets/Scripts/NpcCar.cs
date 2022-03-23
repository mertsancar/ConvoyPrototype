using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move_vector;
    private float speed;

    void Start()
    {
        speed = Random.Range(1, 3);
        controller = gameObject.GetComponent<CharacterController>();
        move_vector = Vector3.zero;
    }

    void Update()
    {
 
    }

    void Forward()
    {
        //float absoluteY = Mathf.Abs(gameObject.transform.position.y);
        //switch (absoluteY)
        //{
        //    case 180:
        //        speed = speed * -;
        //        break;
        //    case 90:
        //        speed = speed * -;
        //    default:
        //        break;
        //}
        move_vector.z = speed;
        controller.Move((-move_vector * speed) * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "FinishLine")
        {
            Destroy(gameObject);
        }

    }
}
