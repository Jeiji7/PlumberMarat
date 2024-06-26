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
    private Transform tr;
    public float direction = 0;
    public float directionTest = 0;
    public MovementType Type = MovementType.Moveing;// ��� ��������
    public MovementPath MyPath;//������������ ���� 
    public float speed = 1f;//�������� ��������
    public float maxDistance = 0.1f;//�� ����� ���������� ������ ��������� ������ � �����, ����� ������ ��� ��� �����

    private IEnumerator<Transform> pointInPath;
    void Start()
    {
        tr = GetComponent<Transform>();
        directionTest = tr.position.x;
        if (MyPath == null) //���� ����
        {
            Debug.Log("�������� ����");
            return;
        }
        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("����� �����");
            return;
        }

        transform.position = pointInPath.Current.position;

    }

    // Update is called once per frame
    void Update()
    {
       

        if (pointInPath == null || pointInPath.Current == null)
        {
            Debug.Log("����� �����");
            return;
        }

        if (Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        direction = tr.position.x;
        if (direction < directionTest)
            tr.localScale = new Vector3(-1, 1, 1);
        else
            tr.localScale = new Vector3(1, 1, 1);

        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;

        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
        directionTest = tr.position.x;
    }
}
