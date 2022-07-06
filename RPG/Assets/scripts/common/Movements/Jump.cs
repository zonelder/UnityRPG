using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _duration;
    [SerializeField] private float _height;
    private float _gravity =10.0f;

    private GroundCheck _IsGrounded;
    //[SerializeField] private Rigidbody _unitRigit;
    private Coroutine _curFallCoroutine;

    public event OnJumpStartMethods OnStartJump;
    public event OnJumpEndMethods OnEndJump;
    public  void StartJump(Vector3 direction,float velocity)
    {
        if (!_IsGrounded.Check || _curFallCoroutine != null)
            return;
        Vector3 initialSpeed= direction.normalized * velocity+ Vector3.up * 6.0f;
        _curFallCoroutine= StartCoroutine(Fall(initialSpeed));
        OnStartJump?.Invoke();
    }
    

    IEnumerator Fall(Vector3 InitialVelocity)
    {
        //_unitRigit.velocity = InitialVelocity;
        Vector3 curVelocity = InitialVelocity;
        do
        {
            //теперь решаем общую проблему- гравитация должна быть везде 
            //где должна быть :)
            transform.position += curVelocity * Time.deltaTime;
            curVelocity -= _gravity * Vector3.up * Time.deltaTime;
            yield return null;

        } while (!_IsGrounded.Check);
        OnEndJump?.Invoke();
        _curFallCoroutine = null;
    }

    private void Awake()
    {
        _IsGrounded = GetComponent<GroundCheck>();
    }
}

public delegate void OnJumpStartMethods();
public delegate void OnJumpEndMethods();
