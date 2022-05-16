using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _yAnimation;
    [SerializeField]
    private float _duration;
    [SerializeField]
    private float _height;
    public  void StartJump(Vector3 direction,float velocity)
    {
        Vector3 target = transform.position + direction.normalized * velocity;
        StartCoroutine(JumpByTime(target));
    }

    IEnumerator JumpByTime(Vector3 target)
    {
        
        float expiredSeconds = 0;
        float progress = 0;
        Vector3 StartPosition = transform.position;
        Quaternion StartlookTo = transform.rotation;
        while (progress <= 1)
        {
            // надо заканчивать если по каким то причинм мы коснулись обьекта(нужен тригер на ногах)
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _duration;
            transform.position  = Vector3.Lerp(StartPosition, target, progress)+ new Vector3(0, _yAnimation.Evaluate(progress) * _height, 0);
           // Eще это осталяет неприятное подергивание в конце анимации-понять почему
            transform.rotation = StartlookTo;
            yield return null;
        }
        
    }
}
