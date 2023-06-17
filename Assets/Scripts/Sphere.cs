using System;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Action <GameObject> PlayerTouch;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerTouch?.Invoke(other.gameObject);
        }
    }
}
