using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static System.Net.WebRequestMethods;

public class GeolocationCheck : MonoBehaviour
{
    private const string apiUrl = "https://ipinfo.io/json";
    private const string wikiUrl = "https://uk.wikipedia.org/";

    private WebViewObject webView;

    private IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {

            GeoData geoData = JsonUtility.FromJson<GeoData>(request.downloadHandler.text);

            if (geoData.country != "UA")
            {
                webView = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
                webView.Init(enableWKWebView: true, transparent: false, zoom: true,  ua: "custom-user-agent");
                webView.SetMargins(10, 100, 10, 10);
                webView.LoadURL(wikiUrl);
                webView.SetVisibility(true);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }


    [System.Serializable]
    public class GeoData
    {
        public string ip;
        public string city;
        public string region;
        public string country;
        public string loc;
    }
}
