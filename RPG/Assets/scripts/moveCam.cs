using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour//написать отдельный клаас под чувствутельность мыши и колесика
{
    public   bool CameraFreeze;
    [SerializeField]
    private Transform target; //юнит за которым следеут камера
    [Range(0.5f,10.0f)]
    private  float distance = 5.0f; //расстояние между камерой и юнитом
    [SerializeField]
    private float xSpeed = 125.0f; //чувствителльность поворота мыши по х
    [SerializeField]
    private float ySpeed = 50.0f; //чувствительность мыши по y
    private float targetHeight = 2.0f; //высота юнита
                                     
    private float yMinLimit = -40;
    private float yMaxLimit = 80;
    //в пределаю этих значений можно поворачивать ось по y
    private const  float maxDistance = 10.0f;
    private const  float minDistance = 0.5f;
    private float zoomRote = 90.0f;//чувствительность калесика мыши

    private float x = 0.0f; //угол поворота по x
    private float y = 0.0f; //угол поворота по Y

    [AddComponentMenu("Scripts/Mouse Orbit")] //��������� � ����

    public void Start()
    {
        CameraFreeze = false;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void LateUpdate()
    {
        if (!CameraFreeze)//тут надо поменять. чтобы не было обращений за пределы юнита
        {
            if (target)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                
                distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRote * Mathf.Abs(distance);
                distance = Mathf.Clamp(distance, minDistance, maxDistance);

                y = ClampAngle(y, yMinLimit, yMaxLimit); 
                
                Quaternion rotation = Quaternion.Euler(y, x, 0);
                transform.rotation = rotation;

                
                Vector3 position = rotation * new Vector3(0.0f, targetHeight - 0.5f, -distance) + target.position;
                transform.position = position;//ствим камеру в правильное положение относительно новых данных

                //на случай если камера будет тереться об обьект
                RaycastHit hit;
                Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -targetHeight, 0);
                if (Physics.Linecast(trueTargetPosition, transform.position, out hit))
                {
                    float tempDistance = Vector3.Distance(trueTargetPosition, hit.point) - 0.28f;
                    position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -targetHeight, 0));
                    transform.position = position;
                }
            }
        }

    }
    //
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}

