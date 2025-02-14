using System.Threading.Tasks;
//using UnityEditor.PackageManager.UI;
using UnityEngine;

public class AsyncSample : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("작업 시작");
        Sample1();
        Debug.Log("Process A");
    }

    private async void Sample1()
    {
        Debug.Log("Process B");
        await Task.Delay(5000);
        Debug.Log("Process C");
    }
}
