using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{
    private string dogURL = "https://drive.usercontent.google.com/u/0/uc?id=1WLfdTGWwkCjOUEDCBt15j2JYI5dqK2JV&export=download";
    private string catURL = "https://drive.usercontent.google.com/u/0/uc?id=1RpTSeeqjzdMrQMC672Php36hN-PBYWrb&export=download";
    public Image image;

    public void OnDogImageButtonClick()
    {
        StartCoroutine(DownLoadImage(dogURL));
    }
    public void OnCatImageButtonClick()
    {
        StartCoroutine(DownLoadImage(catURL));
    }

    private IEnumerator DownLoadImage(string url)
    {
        // �ش� �ּ�(URL)�� ���� �ؽ�ó�� ������Ʈ ��û
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        // ������Ʈ�� �Ϸ�� ������ ���
        yield return www.SendWebRequest();

        // ������Ʈ�� ����� �����̶��
        if(www.result == UnityWebRequest.Result.Success)
        {
            // �ٿ���� �ؽ�ó �����ϴ� �ڵ�
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Texture2D�� UI���� ���� ���� sprite���·� ��ȯ
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);

            Debug.Log("�̹����� ���������� �����Խ��ϴ�.");
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("�̹����� �������� ���߽��ϴ�.");
        }
    }
}
