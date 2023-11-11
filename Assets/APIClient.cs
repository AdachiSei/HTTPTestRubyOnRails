using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    // �����g��API��URL�ɒu�������Ă�������
    public string apiURL = "http://bakusoumaru.site:3000/api/get_response"; 

    void Start()
    {
        GetTextFromAPI().Forget();
    }

    private async UniTask GetTextFromAPI()
    {
        Debug.Log("�ڑ���");
        UnityWebRequest www = UnityWebRequest.Get(apiURL);

        await www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
            Debug.LogError("Error: " + www.error);
        else
        {
            string textResponse = www.downloadHandler.text;
            Debug.Log("API Response: " + textResponse);
            // ������textResponse�������܂��͕\�����邱�Ƃ��ł��܂�
        }
    }
}