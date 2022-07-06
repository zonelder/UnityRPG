using UnityEngine;
using UnityEngine.UI;

public class TextLifeTime : MonoBehaviour
{
   public Camera _camera;
   public GameObject targetUnit;
   [SerializeField] private Text _floatingText;
   private Vector3 _offSet ;


    public void SetTextCarrier(GameObject target,GameObject camera)
    {
        targetUnit = target;
        _camera = camera.GetComponent<Camera>();
        
        _offSet = -1.5f * _camera.transform.right + 0.7f * _camera.transform.up;
    }
    public void SetTextCarrier(GameObject target, Camera camera)
    {
        targetUnit = target;
        _camera = camera;

        _offSet = -1.5f * _camera.transform.right + 0.7f * _camera.transform.up;
    }

    public void SetDamageValue(float value)
    {
        _floatingText.text = ((int)value).ToString();
    }
    private void Update()
    {
        gameObject.transform.rotation = _camera.transform.rotation;
        gameObject.transform.localPosition = _camera.transform.rotation * _offSet;
        gameObject.transform.localScale = 0.003f * Vector3.Distance(_camera.transform.position, gameObject.transform.position) * Vector3.one;
    }
}
