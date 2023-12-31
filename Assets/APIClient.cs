using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    // ご自身のAPIのURLに置き換えてください
    public string apiURL = "http://bakusoumaru.site:3000/api/get_response"; 

    void Start()
    {
        GetTextFromAPI().Forget();
    }

    private async UniTask GetTextFromAPI()
    {
        Debug.Log("接続中");
        UnityWebRequest www = UnityWebRequest.Get(apiURL);

        await www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
            Debug.LogError("Error: " + www.error);
        else
        {
            string textResponse = www.downloadHandler.text;
            Debug.Log("API Response: " + textResponse);
            // ここでtextResponseを処理または表示することができます
        }
    }
}