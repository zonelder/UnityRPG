using UnityEngine;

public class InpactWiew : MonoBehaviour
{
    [SerializeField] private UnitEntity _targetUnit;
    [SerializeField] private Camera _targetCamera;
    [SerializeField] private GameObject _outgoingDamageText;
    [SerializeField] private GameObject _outgoingCritText;

    public  void ShowDamage(UnitEntity enemy, GeneratedDamage damage)
    {
        Vector3 TextOffset = -1.5f * _targetCamera.transform.right - 0.7f * _targetCamera.transform.up + 0.3f * Random.insideUnitSphere;
        // <create copy of needed text>
        GameObject curText;
        if (damage.type == DamageType.common)
            curText = Instantiate(_outgoingDamageText, enemy.transform.position + TextOffset, _targetCamera.transform.rotation,enemy.transform);
        else
            curText = Instantiate(_outgoingCritText, enemy.transform.position + TextOffset, _targetCamera.transform.rotation,enemy.transform);
        // </reate copy of needed text>
        curText.GetComponent<TextLifeTime>().SetTextCarrier(gameObject,_targetCamera);
        curText.GetComponent<TextLifeTime>().SetDamageValue(damage);
        curText.GetComponent<Canvas>().worldCamera = _targetCamera;
        Destroy(curText, 2);
    }

    private void Start()
    {
        _targetUnit.OnDoneDamage.AddSubscriber(ShowDamage);
    }

    private void OnDisable()
    {
        _targetUnit.OnDoneDamage.RemoveSubscriber(ShowDamage);
    }
}
