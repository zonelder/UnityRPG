using UnityEngine;

[RequireComponent(typeof(UnitEntity))]
public class StatPoints : MonoBehaviour
{
    private int _pointsCount;
    
    public bool CanSpend => _pointsCount != 0;
    public int Count => _pointsCount;
    private void OnLvlUp() => _pointsCount += 5;

    public void SpendPoint()
    {
        if (!CanSpend)
            throw new System.InvalidOperationException();
        _pointsCount -= 1;
    }

    private void Start()
    {
        GetComponent<UnitEntity>().Exp.OnLevelUp += OnLvlUp;
    }

    private void OnDisable()
    {
        GetComponent<UnitEntity>().Exp.OnLevelUp -= OnLvlUp;
    }
}
