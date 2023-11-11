using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    // ‚²©g‚ÌAPI‚ÌURL‚É’u‚«Š·‚¦‚Ä‚­‚¾‚³‚¢
    public string apiURL = "http://bakusoumaru.site:3000/api/get_response"; 

    void Start()
    {
        StartCoroutine(GetTextFromAPI());
    }

    IEnumerator GetTextFromAPI()
    {

        Debug.Log("Ú‘±’†");
        UnityWebRequest www = UnityWebRequest.Get(apiURL);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            string textResponse = www.downloadHandler.text;
            Debug.Log("API Response: " + textResponse);
            // ‚±‚±‚ÅtextResponse‚ğˆ—‚Ü‚½‚Í•\¦‚·‚é‚±‚Æ‚ª‚Å‚«‚Ü‚·
        }
    }
}