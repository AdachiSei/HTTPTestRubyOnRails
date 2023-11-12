using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTest : MonoBehaviour
{
    [SerializeField]
    [Header("保存したい情報")]
    private string _saveData = "";

    private string apiUrl = "http://bakusoumaru.site:3000/api/post_text";

    private void Start()
    {
        GetCsrfTokenAndRegisterUser().Forget();
    }

    private async UniTask GetCsrfTokenAndRegisterUser()
    {

        // 送信するデータを作成
        WWWForm form = new WWWForm();
        form.AddField("key1", "value1");
        form.AddField("key2", _saveData);

        UnityWebRequest registerRequest = UnityWebRequest.Post(apiUrl, form);

        await registerRequest.SendWebRequest();

        if (registerRequest.result == UnityWebRequest.Result.Success)
            Debug.Log("Data sent successfully");
        else
            Debug.LogError("Error sending data: " + registerRequest.error);
    }
}