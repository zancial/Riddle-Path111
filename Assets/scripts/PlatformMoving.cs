using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public float speed = 0.03f;
    public float leftBound = 0f; // ����� �������
    public float rightBound = 3f; // ������ �������
    private bool movingRight = true; // ���� ��� ������������ �����������

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            if (transform.position.x >= rightBound)
                movingRight = false; // �������� ����������� �� ����
        }
        else
        {
            transform.Translate(new Vector3(-speed, 0, 0));
            if (transform.position.x <= leftBound)
                movingRight = true; // �������� ����������� �� �����
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.SetParent(gameObject.transform);
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        coll.gameObject.transform.SetParent(null);
    }
}
