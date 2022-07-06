using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SkillBook : MonoBehaviour
{
    [SerializeField] private List<ActiveAbility> _ability = new List<ActiveAbility>();

    public event Action<float> CountingDown;
    public void Update()
    {
        //слишком замудрено. менять
        CountingDown?.Invoke(Time.deltaTime);
    }
    public ActiveAbility GetAbilityAt(int i) => _ability[i];
    public void AddAbility(ActiveAbility newAbility)
    {
        _ability.Add(newAbility);
        newAbility.Cooldown.OnStartCountDown += StartCounting;
        newAbility.Cooldown.OnEndCountDown += StopCounting;
    }
    public void RemoveAbility(ActiveAbility newAbility)
    {
        newAbility.Cooldown.OnStartCountDown -= StartCounting;
        newAbility.Cooldown.OnEndCountDown -= StopCounting;
        _ability.Remove(newAbility);
    }
    public void CreateVoidAbility()
    {
        _ability.Add(new ActiveAbility(1));
    }
    private void StartCounting(Action<float> methods)=>CountingDown += methods;
    private void StopCounting(Action<float> methods)=>CountingDown -= methods;
}
