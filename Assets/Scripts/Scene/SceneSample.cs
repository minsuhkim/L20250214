using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{    
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded가 등록되었습니다.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded가 해제되었습니다.");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 로드된 씬의 이름은 {scene.name}입니다.");
    }    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);  // BRP Sample Scene
            // 따로 씬 모드를 설정하지 않으면 LoadSceneMode가 Single로 처리
            // Single 모드의 설정은 씬을 갈아타도록 설정
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            // LoadSceneMode가 Additive일 경우는 기존 씬 위에 새로운 씬을 중복해서 로드하는 설정
            // 해당 작업을 진행할 경우 기본 오브젝트들(Main Camera, Direction Light)등 도 다 로드되므로 주의해야 함
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadSceneC());
            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            // 비동기적(async) 로드

            // 일반적인 씬의 로딩 작업은 동기적으로 처리됨
            // 씬의 로딩이 다 될 때까지 다른 요소들은 작동하지 않음
        }
    }

    private IEnumerator LoadSceneC()
    {
        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}
