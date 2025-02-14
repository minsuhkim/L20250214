using Unity.VisualScripting;
using UnityEngine;

public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // 인스턴스가 비어있다면,
            if(instance == null)
            {
                // 씬 내에서 해당 타입을 가지고 있는 오브젝트를 탐색
                instance = (T)FindAnyObjectByType(typeof(T));
                // 씬 내에 해당 타입을 가지고 있는 오브젝트가 없다면
                if (instance == null)
                {
                    // 새로 생성
                    //ex) 만들려고하는 데이터가 GameManager라면 이름도 GameManager로 지어짐
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
