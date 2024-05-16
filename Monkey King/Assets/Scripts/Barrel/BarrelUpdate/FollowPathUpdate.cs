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
    public MovementType Type = MovementType.Moveing;// ��� ��������
    public MovementPathUpdate MyPath;//������������ ���� 
    public float speed = 1f;//�������� ��������
    public float maxDistance = 0.1f;//�� ����� ���������� ������ ��������� ������ � �����, ����� ������ ��� ��� �����

    private IEnumerator<Transform> pointInPath;
    void Start()
    {
        tr = GetComponent<Transform>();
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
            if (Mathf.Abs(tr.position.x - lastPosition) < positionTolerance)
            {
                print("���� �������");
                BarrelAnim.SetBool("LadderBarrel", true);
            }
            else
            {
                print("�������");
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
