using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move_vector;
    private float vertical_velocity;

    private static bool isDead = false;

    
    public float Speed = 3.0f;

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
        move_vector.x = Input.GetAxisRaw("Horizontal") * Speed;

        // Dokunmatik ekran butonsuz
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                move_vector.x = Speed;
            }
            else
            {
                move_vector.x = -Speed;
            }
        }

        // Ýleri (Z)
        move_vector.z = Speed;

        controller.Move((move_vector * Speed) * Time.deltaTime);
    }

    public void SetSpeed(float difficulty_level)
    {
        Speed = 1f + Speed; //+ difficulty_level
    }


}
