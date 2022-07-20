using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float pickupDelay = 0.3f;
    bool hasPackage = false;

    Color32 defaultColor = new Color32(255, 255, 255, 255);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag) {
            case "Package":
                if (!hasPackage) {
                    hasPackage = true;
                    Color32 otherColor = other.GetComponent<SpriteRenderer>().color;
                    Destroy(other.gameObject, pickupDelay);
                    spriteRenderer.color = otherColor;
                }
                break;
            case "Customer":
                if(hasPackage) {
                    hasPackage = false;
                    spriteRenderer.color = defaultColor;
                }
                break;
            default:
                break;
        }
    }
}
