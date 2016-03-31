using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour {

    public GameObject BGfloor;

	// Use this for initialization
	void Start ()
    {
        Vector3 basePlacePosition = new Vector3(0, 0, 0);
        Vector3 placePosition = new Vector3(basePlacePosition.x, basePlacePosition.y, basePlacePosition.z);
        //配置する回転角を設定
        Quaternion q = new Quaternion();
        q = Quaternion.identity;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                placePosition.x =  basePlacePosition.x + j*BGfloor.transform.localScale.x;
                Instantiate(BGfloor, placePosition, q);
            }
            placePosition.y += BGfloor.transform.localScale.y;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
