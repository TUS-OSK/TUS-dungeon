using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public GameObject NextBeacon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Transform>().position=NextBeacon.GetComponent<Transform>().position;
        }
    }
}
