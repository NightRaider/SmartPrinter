using UnityEngine;
using System.Collections;

public class EIndicator : MonoBehaviour {
    public EHiveAPI eHiveAPI;

    public float timeDelay;
    public float timePeriod=0.5f;

    public Material readyMaterial;
    public Material runMaterial;
    public Material idleMaterial;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().enabled = false;
        StartCoroutine("changeColor");
    }

    // Update is called once per frame
    void Update () {
	
	}
    private IEnumerator changeColor()
    {
        yield return new WaitForSeconds(timeDelay);
        while (true)
        {
            if (eHiveAPI.powerVal < 20.0f)
            {
                GetComponent<Renderer>().material = idleMaterial;
            }
            else if (eHiveAPI.powerVal > 20.0f && eHiveAPI.powerVal <130.0f)
            {
                GetComponent<Renderer>().material = readyMaterial;
            }
            else if (eHiveAPI.powerVal > 130.0f)
            {
                GetComponent<Renderer>().material = runMaterial;
            }
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(timePeriod);
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(2*timePeriod);
        }
    }
}
