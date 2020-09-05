 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
using Newtonsoft.Json;

public class WebRequest : MonoBehaviour
{
    public TextMeshProUGUI dataTimeText;
    public GameObject popUpWebError;
    public GameObject reconnecting;

    private WebDataTime dataTime;
    private bool webLoaded = false;

    public delegate void OnEverySecondHandler();
    public static OnEverySecondHandler SecondHandlerDelegate = null;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(EverySecondsCoroutine());
    }
    private void Awake()
    {
        dataTime = new WebDataTime();
        //SecondHandler += 
        StartCoroutine(GetText());
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void ClockHandler()
    {
        if (webLoaded)
        {
            dataTime.datetime = dataTime.datetime.AddSeconds(1);
            Debug.Log(dataTime.datetime + "");
            dataTimeText.text = dataTime.datetime + "";
        }
    }
    public void Reconnect()
    {
        reconnecting.SetActive(true);
        StartCoroutine(GetText());
    }
    IEnumerator EverySecondsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SecondHandlerDelegate?.Invoke();
        }
    }
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://worldtimeapi.org/api/ip");
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
            popUpWebError.SetActive(true);
            webLoaded = false;
            reconnecting.SetActive(false);
        }
        else
        {
            popUpWebError.SetActive(false);
            reconnecting.SetActive(false);
            // Show results as text
            //Debug.Log(www.downloadHandler.text);
            try
            {
                dataTime = JsonConvert.DeserializeObject<WebDataTime>(www.downloadHandler.text);
                Debug.Log(dataTime.datetime + "");
                dataTimeText.text = dataTime.datetime + "";
                webLoaded = true;
                SecondHandlerDelegate += ClockHandler;
            }
            catch(System.Exception e)
            {
                popUpWebError.SetActive(true);
                reconnecting.SetActive(false);
                webLoaded = false;
            }
        }
    }
}
