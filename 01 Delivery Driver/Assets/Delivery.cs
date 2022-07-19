using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float pickupDelay = 0.5f;
    bool hasPackage = false;

    Color32 defaultColor = new Color32(255, 255, 255, 255);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bump!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag) {
            case "Package":
                if (!hasPackage) {
                    hasPackage = true;
                    Debug.Log("Package picked up");
                    Color32 otherColor = other.GetComponent<SpriteRenderer>().color;
                    Destroy(other.gameObject, pickupDelay);
                    spriteRenderer.color = otherColor;
                }
                break;
            case "Customer":
                if(hasPackage) {
                    hasPackage = false;
                    Debug.Log("Package delivered");
                    spriteRenderer.color = defaultColor;
                }
                break;
            default:
                break;
        }
    }
}
