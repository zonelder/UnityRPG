using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift
{
    public float initialSpeed;//x=0
    public float finalSpeed;//x=shift.magnitude
    public float intermediateSpeed;//x=intermediateCord
    public float intermediateCord;//between 0 and shift.magnitude
    private float duration;//расчитывается как время за которое будет пройден вектор shift и не может быть изменен извне
    private Vector3 shift;//вектор который надо пройти

    public Vector3 VectorOfMove(GameObject unit)
    {
        return unit.transform.forward*shift.z +unit.transform.right * shift.x + unit.transform.up * shift.y;
    }

    private float CalculateDuration()
    {
        if (initialSpeed == 0 && intermediateSpeed == 0 && finalSpeed==0)//не двигаемся совсем
        {
            shift = Vector3.zero;//если мы все это время не двигаемся то и нет смысла хранить движение
            return 0;
        }
        if (initialSpeed ==0  && intermediateSpeed==0)//двигаемся только во второй части пути
        {
            intermediateCord = 0;//придудительно равняем чтобы избежать ошибок(если юнит в первой половине движения-не двигался то в конце от должен иметь начальную координату)
                return 2 * (intermediateCord / (finalSpeed));
        }
        if( intermediateSpeed==0 && finalSpeed==0)//двигаемся только в первой части пути
        {
            intermediateCord = shift.magnitude;//если во второй половине движения не двигался то в конце первой половины уже прошел весь путь
            return 2 *shift.magnitude / initialSpeed;
        }
        return 2 * ((shift.magnitude - intermediateCord) / (intermediateSpeed + initialSpeed) + intermediateCord / (intermediateSpeed + finalSpeed));//время за которое будет пройдет этот путь с таким данными
    }

}
