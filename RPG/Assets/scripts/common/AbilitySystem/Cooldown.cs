using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerMethods(UpdateMethods methods);
[System.Serializable]
public class Cooldown
{
    [SerializeField] private float _cooldownTime;
    private float _remainingTime;

    public event TimerMethods OnEndCountDown;
    public event TimerMethods OnStartCountDown;
    public Cooldown(float cooldownTime)
    {
        _cooldownTime = cooldownTime;
        _remainingTime = 0;
    }
    public float GetCooldown() => _cooldownTime;
    public void SetCooldown(float value) => _cooldownTime = value;
    public float CurTime() => _cooldownTime - _remainingTime;
    public bool IsReady => _remainingTime <= 0;
    public void TickTime(float delta)
    {
        _remainingTime -= delta;
        if (IsReady)
        {
            EndCountDown();
        }
    }

    public void StartÑountdown()
    {
        if (!IsReady)
        {
            Debug.Log("timer is not ready");
        }
        else
        {
            _remainingTime = _cooldownTime;
            OnStartCountDown?.Invoke(TickTime);
        }
    }
    public void RestartCountdown()
    {
        EndCountDown();
        StartÑountdown();
    }
    private void EndCountDown()
    {
        _remainingTime = 0;
        OnEndCountDown?.Invoke(TickTime);
    }
}
