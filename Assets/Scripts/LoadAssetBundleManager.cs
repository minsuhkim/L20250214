using System.Collections;
using System.IO;
using UnityEngine;

public class LoadAssetBundleManager : MonoBehaviour
{
    string path = "Assets/Bundles/asset1";

    private void Start()
    {
        StartCoroutine(LoadAsync(path));
    }

    private IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));

        // ������Ʈ�� ���� ������ ���
        yield return request;

        // ������Ʈ�� ���� �޾ƿ� ���� ������ ������ ����
        AssetBundle bundle = request.assetBundle;

        GameObject prefab = bundle.LoadAsset<GameObject>("asset1");
        Instantiate(prefab);
        // LoadAsset<T>("�̸�");

        //GameObject prefab2 = bundle.LoadAsset<GameObject>("BlueSphere");
        //Instantiate(prefab2);

        //GameObject prefab3 = bundle.LoadAsset<GameObject>("GreenSphere");
        //Instantiate(prefab3);
    }
}
