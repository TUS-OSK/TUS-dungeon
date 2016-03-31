using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public string NextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MoveScene() {
        Application.LoadLevel(NextScene);
    }
}
