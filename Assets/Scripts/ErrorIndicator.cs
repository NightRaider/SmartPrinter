using UnityEngine;
using System.Collections;

public class ErrorIndicator : MonoBehaviour {
    public KeyCode triggerKey;
    public float timePeriod = 0.5f;
    private bool errorFlag = false;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(triggerKey))
        {
            FlashGameObject();
        }
    }
    private void FlashGameObject()
    {
        errorFlag = !errorFlag;
        if (errorFlag)
        {
            StartCoroutine("flash");
        }
        else
        {
            StopCoroutine("flash");
            GetComponent<Renderer>().enabled = false;
        }
    }
    private IEnumerator flash()
    {
        while (true)
        {
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(timePeriod);
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(2 * timePeriod);
        }
    }
}
