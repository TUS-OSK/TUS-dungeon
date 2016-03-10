using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public string talk="hello";
    public GameObject MessageManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTap() {
        MessageManager mm = MessageManager.GetComponent<MessageManager>();
        mm.WriteNameMassage(this.name);
        mm.WriteTalkMassage(talk);
    }
}
