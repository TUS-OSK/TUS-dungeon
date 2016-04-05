using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageManager : MonoBehaviour {

    public GameObject TalkMassage;
    public GameObject NameMassage;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WriteTalkMassage(string massage)
    {
        TalkMassage.GetComponent<Text>().text = massage;
    }

    public void WriteNameMassage(string name)
    {
        NameMassage.GetComponent<Text>().text = name;
    }
}
