using UnityEngine;
using System.Collections;


public class BackGroundManager : MonoBehaviour {

    public string location;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            LocationPanel lp = GameObject.Find("LocationPanel").GetComponent<LocationPanel>();
            lp.ChangeLocation(location);
            Debug.Log(location);
        }
    }
}
