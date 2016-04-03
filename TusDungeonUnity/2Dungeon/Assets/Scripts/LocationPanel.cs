using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour {

    public GameObject locationtext;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeLocation(string loc) {
        locationtext.GetComponent<Text>().text = loc;
    }
}
