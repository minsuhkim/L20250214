using UnityEngine;

public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = Singleton.Instance.point;

        Singleton.Instance.PointPlus();         // 프로퍼티로 접근
        Singleton.GetInstance().ViewPoint();    // 메소드로 접근
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
        Debug.Log($"현재 포인트: {point}");
    }

    // 메소드를 통해서 전달
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }

        return _instance;
    }

    // 프로퍼티로 설계
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