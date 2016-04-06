using UnityEngine;
using System.Collections;

public class YesNoPanel : MonoBehaviour
{


    public Vector3 InPosition;
    public Vector3 OutPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveIn()
    {
        this.GetComponent<Transform>().localPosition = InPosition;
    }

    public void MoveOut()
    {
        this.GetComponent<Transform>().localPosition = OutPosition;
    }
}