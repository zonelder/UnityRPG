using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundCheck))]
public class Gravity : MonoBehaviour
{
    private Vector3 _gravity =-10*Vector3.up;
    private Vector3 _velocity;
    [SerializeField] GroundCheck _isGrounded;

    public IEnumerator ApllyGravity()
    {
        while (!_isGrounded.Check)
        {
            transform.position += _velocity * Time.deltaTime;
            _velocity += Time.deltaTime * _gravity;
            yield return null;
        }
    }
}
