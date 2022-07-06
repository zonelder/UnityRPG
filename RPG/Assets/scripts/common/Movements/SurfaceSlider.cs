using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _surfaceNormal;
    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _surfaceNormal) * _surfaceNormal;
    }
    private void OnCollisionStay(Collision collision)
    {
        // OnCollisionStay use  cause we can move on huge surface with changing normals along it;
        _surfaceNormal = collision.contacts[0].normal;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _surfaceNormal * 5);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward).normalized * 5);
    }
}
