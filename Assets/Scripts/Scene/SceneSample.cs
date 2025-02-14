using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{    
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded�� ��ϵǾ����ϴ�.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded�� �����Ǿ����ϴ�.");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"���� �ε�� ���� �̸��� {scene.name}�Դϴ�.");
    }    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);  // BRP Sample Scene
            // ���� �� ��带 �������� ������ LoadSceneMode�� Single�� ó��
            // Single ����� ������ ���� ����Ÿ���� ����
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            // LoadSceneMode�� Additive�� ���� ���� �� ���� ���ο� ���� �ߺ��ؼ� �ε��ϴ� ����
            // �ش� �۾��� ������ ��� �⺻ ������Ʈ��(Main Camera, Direction Light)�� �� �� �ε�ǹǷ� �����ؾ� ��
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadSceneC());
            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            // �񵿱���(async) �ε�

            // �Ϲ����� ���� �ε� �۾��� ���������� ó����
            // ���� �ε��� �� �� ������ �ٸ� ��ҵ��� �۵����� ����
        }
    }

    private IEnumerator LoadSceneC()
    {
        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}
