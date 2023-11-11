using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PostedDataGetter : MonoBehaviour
{
    [SerializeField]
    [Header("ID")]
    private int _id = 0;

    private string apiUrl = "http://bakusoumaru.site:3000/api/get_posted_text/";

    void Start()
    {
        // APIにPOSTリクエストを送信
        SendRequest().Forget();
    }

    private async UniTask SendRequest()
    {
        // クエリパラメータを含むURLを構築
        string urlWithParameters = $"{apiUrl}/{_id}";

        // GETリクエストを作成
        UnityWebRequest request = UnityWebRequest.Get(urlWithParameters);

        // リクエストを送信
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("API Response: " + request.downloadHandler.text);
        else
            Debug.LogError("Error sending request: " + request.error);
    }
}
