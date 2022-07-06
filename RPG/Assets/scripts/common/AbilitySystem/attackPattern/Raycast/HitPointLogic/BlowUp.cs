using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlowAtPoint : IHit,IDestroyable
{
    private float _radius;
    private GameObject _hitEffect;

    public BlowAtPoint(float radius,GameObject effects)
    {
        _radius = radius;
        _hitEffect = effects;
    }
    public void Execute(Vector3 hitPoint,UnitEntity unit)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint, _radius);
        foreach (Collider nearbyCollider in colliders)
        {
                UnitEntity enemy = nearbyCollider.gameObject.GetComponent<UnitEntity>();
            //enemy?.GetHit(unit);
            if (enemy != null)
                unit.DoneDamage(enemy);
        }
        ShowEffect(hitPoint);
    }
    private void ShowEffect(Vector3 hitPoint)
    { 
        if (_hitEffect != null)
        {
            GameObject curEffect = MonoBehaviour.Instantiate(_hitEffect, hitPoint, _hitEffect.transform.rotation);//запустили эфект который проигрывается при уничтожении обьекта(уничтожить потом его тоже надо)
            MonoBehaviour.Destroy(curEffect, 3.9f);
        }

    }
}
