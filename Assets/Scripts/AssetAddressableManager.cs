using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableManager : MonoBehaviour
{
    // AssetReference�� Ư�� Ÿ���� �������� �ʰ� ��巹������ ���ҽ��� ����
    // AssetReferenceGameObject�� ��巹���� ���ҽ� �߿��� ���� ������Ʈ�� �ش��ϴ� ���� ����
    public AssetReferenceGameObject capsule;

    // AssetReferenceT�� ���ʸ��� �̿��� Ư�� ������ ��巹���� ���ҽ��� ����
    public GameObject go = new GameObject();


    private void Start()
    {
        StartCoroutine("Init");
    }

    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
        Debug.Log("�ʱ�ȭ �Ϸ�");
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
        Addressables.ReleaseInstance(go); // ����
    }
}
