using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitEntity))]
public class BleedSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bloodSpray;

    public void CreateBloodEffects(UnitEntity _bleedUnit)
    {
        Vector3 attackerPosition = _bleedUnit.transform.position;
        Vector3 sprayBloodToAttacker = attackerPosition - transform.position;
        GameObject bloodEffect = Instantiate(_bloodSpray, transform.position, Quaternion.LookRotation(Vector3.Cross(sprayBloodToAttacker, Random.rotationUniform * sprayBloodToAttacker)));
        Destroy(bloodEffect, 1);
    }

    private void Start()
    {
        GetComponent<UnitEntity>().OnGetDamage.AddSubscriber(CreateBloodEffects);
    }
    private void OnDisable()
    {
        GetComponent<UnitEntity>().OnGetDamage.RemoveSubscriber(CreateBloodEffects);
    }
}
