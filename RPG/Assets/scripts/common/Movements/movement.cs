
using UnityEngine;

[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(SurfaceSlider))]
public class movement : MonoBehaviour
{
    private UnitMove _moveStrategy;
    private UnitRotation _rotationStrategy;
    private Jump _jump;
    private GroundCheck _IsGround;

    private GameObject _cam;

    private float _currentSpeed;
    private float _defaultSpeed=6.0f;
    private SurfaceSlider _surfaceSlider;
  
    public UnitMove MoveStrategy => _moveStrategy;
    public float CurrentVelocity => _currentSpeed;

    private void Awake()
    {
        _cam = transform.Find("playerCam").gameObject;
        _IsGround = GetComponent<GroundCheck>();
        _surfaceSlider = GetComponent<SurfaceSlider>();

        _jump = GetComponent<Jump>();
        _rotationStrategy = new WalkRotation();
        _moveStrategy = new WalkMove();
        _jump.OnStartJump += _rotationStrategy.DisableRotation;
        _jump.OnEndJump += _rotationStrategy.EnableRotation;

    }
   
    public void Move(Vector3 direction)
    {
        //все инпуты должны быть перенесены в KeyboardInput
        float InputMagnitude = Mathf.Max(Mathf.Abs(direction.z), Mathf.Abs(direction.x));
        direction = _cam.transform.TransformDirection(direction);     

        _currentSpeed = _defaultSpeed * (1 + Input.GetAxis("Sprint"))*InputMagnitude;
        if(_IsGround.Check)
        {
            direction.y = 0;
            if(_moveStrategy.IsMoveable)
            {
                _moveStrategy.Execute(_surfaceSlider.Project(direction.normalized).normalized * _currentSpeed, transform);
                _rotationStrategy.Rotate(direction, transform);
                if (Input.GetKey(KeyCode.Space))
                {
                    _jump.StartJump(direction, _currentSpeed);
                }
            }

        }
    }
}
