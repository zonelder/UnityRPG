using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]private movement _unitMove;
    [SerializeField]private Jump _unitJump;


    private void Update()
    {
        _animator.SetFloat("velocity",_unitMove.CurrentVelocity);
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        UnitMove moveType =  transform.parent.GetComponent<movement>().MoveStrategy;
        moveType.OnMove += AnimatingMoving;
        moveType.OnStop += StopAnimatingMoving;
        _unitJump.OnStartJump += StartJump;
        _unitJump.OnEndJump += StopJump;

    }
    private void OnDisable()
    {
        UnitMove moveType = transform.parent.GetComponent<movement>().MoveStrategy;
        moveType.OnMove -= AnimatingMoving;
        moveType.OnStop -= StopAnimatingMoving;
        _unitJump.OnStartJump -= StartJump;
        _unitJump.OnEndJump -= StopJump;
    }

    private void AnimatingMoving()
    {
        _animator.SetBool("IsMove", true);
    }
    private void StopAnimatingMoving()
    {
        _animator.SetBool("IsMove", false);
    }

    private void StartJump()
    {
        _animator.SetBool("IsJump",true);
    }

    private void StopJump()
    {
        _animator.SetBool("IsJump",false);
    }
}
