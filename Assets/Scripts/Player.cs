using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.score = 0;
    }
}
