using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float pickupDelay = 0.5f;

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Bump!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Package":
                if (!hasPackage) {
                    hasPackage = true;
                    Debug.Log("Package picked up");
                    Destroy(other.gameObject, pickupDelay);
                }
                break;
            case "Customer":
                if(hasPackage) {
                    hasPackage = false;
                    Debug.Log("Package delivered");
                }
                break;
            default:
                break;
        }
    }
}
