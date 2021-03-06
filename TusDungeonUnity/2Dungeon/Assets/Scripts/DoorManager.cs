﻿using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public GameObject NextDoor;
    private bool isAct;

	// Use this for initialization
	void Start () {
        isAct = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.tag == "Player")
        {
            if (isAct)
            {
                col.gameObject.GetComponent<Transform>().position = NextDoor.GetComponent<Transform>().position;
                NextDoor.GetComponent<DoorManager>().isAct = false;
                NextDoor.GetComponent<Collider2D>().isTrigger = true;

                StartCoroutine(ChangeLocation(0.5f));
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isAct = true;
            this.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private IEnumerator ChangeLocation(float time)
    {
        yield return new WaitForSeconds(time);
        StatusPanel sp = GameObject.FindGameObjectWithTag("StatusPanel").GetComponent<StatusPanel>();
        sp.SerchLocation();
    }
}
