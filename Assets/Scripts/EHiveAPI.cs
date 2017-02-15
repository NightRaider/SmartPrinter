using UnityEngine;
using System.Collections;


public class EHiveAPI : MonoBehaviour
{
    public string token = "oFuxOxXUKB2kqRnzoHZSQ_6brZwVhIft";
    public string valUrl = "http://www.energyhive.com/mobile_proxy/getCurrentValuesSummary?token=";
    public string test;
    public float timeInterval = 10f;


    private WWW wwwobj;
    [SerializeField]
    private float powerVal;

    // Use this for initialization
    void Start()
    {
        valUrl += token;
        //InvokeRepeating("getPower",0,timeInterval);
        StartCoroutine("getPower");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator getPower()
    {
        while (true)
        {
            wwwobj = new WWW(valUrl);
            yield return wwwobj;
            JSONObject json = new JSONObject(wwwobj.text);
            powerVal = json[1]["data"][0][0].n;
            Debug.Log(powerVal);

            yield return new WaitForSeconds(timeInterval);
        }
    }
}
