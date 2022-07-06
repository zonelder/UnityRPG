using UnityEngine;

public class StatVisualizer : MonoBehaviour
{
    public bool ShowStats;
    [SerializeField] private UnitEntity _playerStats;
    [SerializeField] private StatPoints _playerPoints;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowStats = !ShowStats;
        }
    }
    void OnGUI()
    {
        if(ShowStats)
        {
            // Негибко- перетащим в UI Builder 
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + _playerStats.Exp.level());
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + _playerStats.Improved.HP.Max());
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + _playerStats.Improved.MP.Max());
            GUI.Label(new Rect(10, 140, 300, 300), "expToUp: " + _playerStats.Exp.RequiredExp());
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + _playerStats.Improved.Attributes.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + _playerStats.Improved.Attributes.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "intellect: " + _playerStats.Improved.Attributes.intellect);
            GUI.Label(new Rect(10, 200, 300, 300), "damage: " + _playerStats.Improved.Damage.Min + " ~ " + _playerStats.Improved.Damage.Max);
            if (_playerPoints.CanSpend)
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + _playerPoints.Count.ToString());
                PlusStrButton();
                PlusVitalityButton();
                PlusManIntellectButton();
            }
        }
    }

    private void PlusStrButton()
    {
        if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //Для силы
        {
            if (_playerPoints.CanSpend)
            {
                _playerPoints.SpendPoint();
                _playerStats.Base.ChangeSTR(1);
                _playerStats.Improved.ChangeSTR(1);
            }
        }
    }
    private void PlusVitalityButton()
    {
        if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //Для живучести
        {
            if (_playerPoints.CanSpend)
            {
                _playerPoints.SpendPoint();
                _playerStats.Base.ChangeVitality(1);
                _playerStats.Improved.ChangeVitality(1);
            }
        }
    }

    private void PlusManIntellectButton()
    {
        if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //Для маны
        {
            if (_playerPoints.CanSpend)
            {
                _playerPoints.SpendPoint();
                _playerStats.Base.ChangeIntellect(1);
                _playerStats.Improved.ChangeIntellect(1);
            }
        }
    }
}
