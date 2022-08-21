using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 15.0f;
    Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            playerRigidBody.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            playerRigidBody.AddTorque(-torqueAmount);
        }
    }
}
