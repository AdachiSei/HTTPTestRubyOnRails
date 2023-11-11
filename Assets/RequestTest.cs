using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestTest : MonoBehaviour
{
    private string apiUrl = "http://bakusoumaru.site:3000/api/post_text";

    private void Start()
    {
        StartCoroutine(GetCsrfTokenAndRegisterUser()); // WebTest���R���[�`���Ƃ��ČĂяo��
    }

    IEnumerator GetCsrfTokenAndRegisterUser()
    {

           // ���M����f�[�^���쐬
           WWWForm form = new WWWForm();
        form.AddField("key1", "value1");
        form.AddField("key2", "wada");

        UnityWebRequest registerRequest = UnityWebRequest.Post(apiUrl, form);
        //registerRequest.SetRequestHeader("X-CSRF-Token", "b654179120ddcd22d84d1def43e02f85");

        yield return registerRequest.SendWebRequest();

        if (registerRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Data sent successfully");
        }
        else
        {
            Debug.LogError("Error sending data: " + registerRequest.error);
        }
    }
}