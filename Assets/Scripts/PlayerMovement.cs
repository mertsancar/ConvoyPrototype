using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 3.0f;
    private CharacterController controller;
    private Vector3 move_vector;
    private float vertical_velocity;

    [SerializeField]
    private float gravity = 12.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (UIManager._instance.gameOverPanel.activeSelf || UIManager._instance.youWinPanel.activeSelf)
        {
            return;
        }

        move_vector = Vector3.zero;
        Gravity();
        Forward();
    }

    void Gravity()
    {
        if (controller.isGrounded)
        {
            vertical_velocity = -0.5f;
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
        }
        // aþaðý yukarý (Y)
        move_vector.y = vertical_velocity;
    }
    void Forward()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, 30f, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 10f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, -30f, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 10f);

        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 10f);
        }

        move_vector.x = Input.GetAxisRaw("Horizontal") * Speed;

        //// Dokunmatik ekran butonsuz
        //if (Input.GetMouseButton(0))
        //{
        //    if (Input.mousePosition.x > Screen.width / 2)
        //    {
        //        move_vector.x = Speed;
        //    }
        //    else
        //    {
        //        move_vector.x = -Speed;
        //    }
        //}

        // Ýleri (Z)
        move_vector.z = Speed;

        controller.Move((move_vector * Speed) * Time.deltaTime);
    }

    public void SetSpeed(float difficulty_level)
    {
        Speed = Speed + 1f; //+ difficulty_level
    }


}
