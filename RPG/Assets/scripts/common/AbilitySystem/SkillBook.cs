using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void UpdateMethods(float delta);
[System.Serializable]
public class SkillBook : MonoBehaviour
{
    [SerializeField] private List<ActiveAbility> _ability = new List<ActiveAbility>();

    public event UpdateMethods CountingDown;
    public void Update()
    {
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
    private void StartCounting(UpdateMethods methods)=>CountingDown += methods;
    private void StopCounting(UpdateMethods methods)=>CountingDown -= methods;
}
