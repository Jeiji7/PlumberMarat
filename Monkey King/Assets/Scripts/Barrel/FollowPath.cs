using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }
    public MovementType Type = MovementType.Moveing;// вид движения
    public MovementPath MyPath;//использовать путь 
    public float speed = 1f;//скорость движения
    public float maxDistance = 0.1f;//на какое расстояние должен подъехать объект к точке, чтобы понять что это точка

    private IEnumerator<Transform> pointInPath;
    void Start()
    {
        if (MyPath == null) //если путь
        {
            Debug.Log("прекрепи путь");
            return;
        }
        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }

        transform.position = pointInPath.Current.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }

        if(Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSquare = (transform.position- pointInPath.Current.position).sqrMagnitude;
            
        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}
