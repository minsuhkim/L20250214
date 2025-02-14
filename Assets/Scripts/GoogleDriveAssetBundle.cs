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
        // 해당 주소(URL)을 통해 텍스처를 리퀘스트 요청
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        // 리퀘스트가 완료될 때까지 대기
        yield return www.SendWebRequest();

        // 리퀘스트의 결과가 성공이라면
        if(www.result == UnityWebRequest.Result.Success)
        {
            // 다운받은 텍스처 적용하는 코드
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Texture2D를 UI에서 쓰기 위해 sprite형태로 변환
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);

            Debug.Log("이미지를 성공적으로 가져왔습니다.");
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("이미지를 가져오지 못했습니다.");
        }
    }
}
