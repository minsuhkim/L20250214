using UnityEngine;

public class GenericSample : MonoBehaviour
{
    // �迭�� ���޹޾Ƽ� �迭�� ��Ҹ� ������� ����ϴ� �ڵ�
    public static void PrintIArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }

    public static void PrintFArray(float[] numbers)
    {
        foreach (float number in numbers)
        {
            Debug.Log(number);
        }
    }

    public static void PrintSArray(string[] words)
    {
        foreach (string word in words)
        {
            Debug.Log(word);
        }
    }

    public static void PrintGArray<T>(T[] values)
    {
        foreach (T value in values)
        {
            Debug.Log(value);
        }
    }

    private void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        float[] numbers2 = { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };
        string[] words = { "hello", "my name", "is", "KMS" };

        PrintGArray<int>(numbers);
        PrintGArray<float>(numbers2);
        PrintGArray<string>(words);
    }
}