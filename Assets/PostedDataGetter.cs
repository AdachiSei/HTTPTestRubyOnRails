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
        // API��POST���N�G�X�g�𑗐M
        SendRequest().Forget();
    }

    private async UniTask SendRequest()
    {
        // �N�G���p�����[�^���܂�URL���\�z
        string urlWithParameters = $"{apiUrl}/{_id}";

        // GET���N�G�X�g���쐬
        UnityWebRequest request = UnityWebRequest.Get(urlWithParameters);

        // ���N�G�X�g�𑗐M
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("API Response: " + request.downloadHandler.text);
        else
            Debug.LogError("Error sending request: " + request.error);
    }
}
