using UnityEngine;

public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = Singleton.Instance.point;

        Singleton.Instance.PointPlus();         // ������Ƽ�� ����
        Singleton.GetInstance().ViewPoint();    // �޼ҵ�� ����
    }
}

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;

    public int point;
    public void PointPlus()
    {
        point++;
    }

    public void ViewPoint()
    {
        Debug.Log($"���� ����Ʈ: {point}");
    }

    // �޼ҵ带 ���ؼ� ����
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }

        return _instance;
    }

    // ������Ƽ�� ����
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}