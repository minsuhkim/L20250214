using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableManager : MonoBehaviour
{
    // AssetReference는 특정 타입을 지정하지 않고 어드레서블의 리소스를 참조
    // AssetReferenceGameObject는 어드레서블 리소스 중에서 게임 오브젝트에 해당하는 값을 참조
    public AssetReferenceGameObject capsule;

    // AssetReferenceT는 제너릭을 이용해 특정 형태의 어드레서블 리소스를 참조
    public GameObject go = new GameObject();


    private void Start()
    {
        StartCoroutine("Init");
    }

    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
        Debug.Log("초기화 완료");
    }

    public void OnCreateButtonEnter()
    {
        capsule.InstantiateAsync().Completed += (obj) =>
        {
            go = obj.Result;
        };
    }

    public void OnReleaseButton()
    {
        Addressables.ReleaseInstance(go); // 해제
    }
}
