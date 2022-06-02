using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Basis
{

    public Vector3 position;
    public Vector3 forward;
    public Vector3 right;
    public Vector3 up;

    public Basis(Transform originalTransform)
    {
        position = originalTransform.position;
        forward = originalTransform.forward;
        up = originalTransform.up;
        right = originalTransform.right;
    }


    public Vector3 ConvertToWorldSpace(Vector3 vectorInBasis)
    {
        return  position + forward * vectorInBasis.z
                         + right * vectorInBasis.x 
                         + up * vectorInBasis.y ;
    }
}
