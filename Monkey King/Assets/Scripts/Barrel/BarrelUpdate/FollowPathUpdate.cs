using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathUpdate : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }
    
    public float positionTolerance = 0.01f;
    private Transform tr;
    public float lastPosition;
    public Animator BarrelAnim;
    public MovementType Type = MovementType.Moveing;// вид движения
    public MovementPathUpdate MyPath;//использовать путь 
    public float speed = 1f;//скорость движения
    public float maxDistance = 0.1f;//на какое расстояние должен подъехать объект к точке, чтобы понять что это точка

    private IEnumerator<Transform> pointInPath;
    void Start()
    {
        tr = GetComponent<Transform>();
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

 

    void Update()
    {
        
        if (pointInPath == null || pointInPath.Current == null)
        {

            Debug.Log("Нужны точки");
            return;
        }

        if (Type == MovementType.Moveing)
        {

            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            if (Mathf.Abs(tr.position.x - lastPosition) < positionTolerance)
            {
                print("есть контакт");
                BarrelAnim.SetBool("LadderBarrel", true);
            }
            else
            {
                print("задница");
                BarrelAnim.SetBool("LadderBarrel", false);
            }
        }
        if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;

        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
        LatePos();
    }

    private void LatePos()
    {
        lastPosition = tr.position.x;
    }
}
