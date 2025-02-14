using Unity.VisualScripting;
using UnityEngine;

public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // �ν��Ͻ��� ����ִٸ�,
            if(instance == null)
            {
                // �� ������ �ش� Ÿ���� ������ �ִ� ������Ʈ�� Ž��
                instance = (T)FindAnyObjectByType(typeof(T));
                // �� ���� �ش� Ÿ���� ������ �ִ� ������Ʈ�� ���ٸ�
                if (instance == null)
                {
                    // ���� ����
                    //ex) ��������ϴ� �����Ͱ� GameManager��� �̸��� GameManager�� ������
                    var manager = new GameObject(typeof(T).Name);
                    instance = manager.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
