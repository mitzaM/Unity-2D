using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steeringSpeed = 300.0f;
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float slowSpeed = 10.0f;
    [SerializeField] float boostSpeed = 27.0f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost") {
            moveSpeed = boostSpeed;
        }
    }

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * -steeringSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }
}
