using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(Collider))]
public class GroundCheck : MonoBehaviour
{
    private readonly List<Collider> GroundColliders = new List<Collider>();
    private Collider _myCollider;

    public bool Check
    {
        get => GroundColliders.Count > 0;
    }
    private void Start()
    {
        _myCollider = GetComponent<Collider>();
    }
    private void AddUnique(Collider newCollider)
    {
        if (!GroundColliders.Contains(newCollider))
            GroundColliders.Add(newCollider);
    }
    private void Remove(Collider removedCollider)
    {
        if (GroundColliders.Contains(removedCollider))
            GroundColliders.Remove(removedCollider);
    }
    private void OnCollisionEnter(Collision collision)
    {
        AddUnique(collision.collider);
    }
    private void OnCollisionStay(Collision collision)
    {
        AddUnique(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        Remove(collision.collider);
    }

}
