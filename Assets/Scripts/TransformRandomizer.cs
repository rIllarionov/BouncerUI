using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRandomizer : MonoBehaviour
{
    [SerializeField] private Collider _boardCollider;

    public Vector3 GetCoordinate()
    {
        var bounds = _boardCollider.bounds;
        var x = Random.Range(bounds.min.x, bounds.max.x);
        var z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, bounds.max.y, z);
    }
}
