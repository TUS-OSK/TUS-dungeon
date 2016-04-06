using UnityEngine;
using System.Collections;


public class BackGroundManager : MonoBehaviour {

    public string location;
    public Vector3 LeftUp=new Vector3(0,0,0);
    public Vector3 RightDown = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void locationSync(Vector3 PlayerPosition)
    {
        if (LeftUp.x<PlayerPosition.x&&PlayerPosition.x<RightDown.x)
        {
            if (LeftUp.y > PlayerPosition.y && PlayerPosition.y > RightDown.y)
            {
                LocationPanel lp = GameObject.Find("LocationPanel").GetComponent<LocationPanel>();
                lp.ChangeLocation(location);
            }
        }
    }
}
