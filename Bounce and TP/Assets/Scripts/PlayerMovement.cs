using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //Bounce bullet Function related
    public Rigidbody BounbulletPrefab;

    //TP bullet Function related
    public Rigidbody TPbulletPrefab;
    public Transform barrelPos;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight *-2f*gravity);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootBounce();
        }else if (Input.GetMouseButtonDown(1))
        {
            ShootTP();
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void ShootBounce()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(BounbulletPrefab, barrelPos.position, barrelPos.rotation) as Rigidbody;
        bulletInstance.AddForce(barrelPos.forward * 3000);
    }
    public void ShootTP()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(TPbulletPrefab, barrelPos.position, barrelPos.rotation) as Rigidbody;
        bulletInstance.AddForce(barrelPos.forward * 3000);
    }
    public void TP(Vector3 bullet)
    {
        controller.enabled = false;
        gameObject.transform.position = bullet;
        controller.enabled = true;
    }

    public Vector3 GetTPPos()
    {
        return barrelPos.position;
    }
}
