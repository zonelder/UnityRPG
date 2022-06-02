using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundCheck))]
public class Jump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _duration;
    [SerializeField] private float _height;

    private GroundCheck _IsGrounded;
    private Rigidbody _playerRigid;


    public event OnJumpStartMethods OnStartJump;
    public event OnJumpEndMethods OnEndJump;
    public  void StartJump(Vector3 direction,float velocity)
    {
        if (!_IsGrounded.Check)
            return;
        Vector3 target = transform.position + direction.normalized * velocity;
        StartCoroutine(JumpByTime(target));
        OnStartJump?.Invoke();
    }
    

    IEnumerator JumpByTime(Vector3 target)
    {
        
        float expiredSeconds = 0;
        float progress = 0;
        Vector3 StartPosition = transform.position;
        Quaternion StartlookTo = transform.rotation;
        while (progress <= 1)
        {
            if (progress >= 0.05 && _IsGrounded.Check)
            {
                break;
            }

            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _duration;
           _playerRigid.MovePosition( Vector3.Lerp(StartPosition, target, progress)+ new Vector3(0, _yAnimation.Evaluate(progress) * _height, 0));

           yield return null;

        }
        OnEndJump?.Invoke();
    }

    private void Awake()
    {
        _IsGrounded = GetComponent<GroundCheck>();
        _playerRigid = GetComponent<Rigidbody>();
    }
}

public delegate void OnJumpStartMethods();
public delegate void OnJumpEndMethods();
