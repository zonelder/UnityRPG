using UnityEngine;

public class AnimationDummy : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        UnitEntity dummy = transform.parent.GetComponent<UnitEntity>();
        dummy.OnGetDamage.AddSubscriber(PlayHitAnimation);
        dummy.OnDead += PlayDeadAnimation;
        dummy.OnRevive += OnRevive;
    }
    private void OnDisable()
    {
        UnitEntity dummy = transform.parent.GetComponent<UnitEntity>();
        dummy.OnGetDamage.RemoveSubscriber(PlayHitAnimation);
        dummy.OnDead -= PlayDeadAnimation;
        dummy.OnRevive -= OnRevive;
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void PlayHitAnimation()
    {
        _animator.Play("pushed");
    }

    private void PlayDeadAnimation()
    {
        _animator.SetBool("IsDead", true);
        _animator.Play("died");
    }

    private void OnRevive()
    {
        _animator.SetBool("IsDead", false);
        _animator.Play("default");
    }
}
