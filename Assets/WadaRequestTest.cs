using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WadaRequestTest : MonoBehaviour
{
    private string csrfToken;

    private void Start()
    {
        StartCoroutine(GetCsrfTokenAndRegisterUser()); // WebTest���R���[�`���Ƃ��ČĂяo��
    }

    IEnumerator GetCsrfTokenAndRegisterUser()
    {
        // ���[�U�[�̓o�^
        string registerUrl = "http://bakusoumaru.site:3000/api/register";
        WWWForm form = new WWWForm();
        form.AddField("username", "bakusoumaru");
        form.AddField("password", "1234");

        UnityWebRequest registerRequest = UnityWebRequest.Post(registerUrl, form);
        // ���N�G�X�g�w�b�_�[��CSRF�g�[�N����ǉ�
        registerRequest.SetRequestHeader("X-CSRF-Token", "5b7f3d0f58f6bc9de7fb6129ebf21cd8");

        yield return registerRequest.SendWebRequest();

        if (registerRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("���[�U�[������ɓo�^����܂���");
        }
        else
        {
            Debug.Log("���[�U�[�o�^�Ɏ��s���܂����F" + registerRequest.error);
        }
    }
}
