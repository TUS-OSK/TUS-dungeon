using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SerchLocation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteScore(int score)
    {
        SetText("Score",(score*1000).ToString());

        string nm="新入生";
        if (score>=0)
            nm = "新入生";
        if (score >= 1)
            nm = "駆け出し理科大生";
        if (score >= 5)
            nm = "新米理科大生";
        if (score >= 10)
            nm = "情弱理科大生";
        if (score >= 20)
            nm = "ぼっち理科大生";
        if (score >= 30)
            nm = "普通の理科大生";
        if (score >= 40)
            nm = "リア充理科大生";
        if (score >= 50)
            nm = "情強理科大生";
        if (score >= 60)
            nm = "エリート理科大生";
        if (score >= 70)
            nm = "理科大通";
        if (score >= 80)
            nm = "理科大マニア";
        if (score >= 85)
            nm = "理科大エキスパート";

        SetText("NickName", nm);
    }

    public void SetText(string name, string text)
    {
        foreach (Transform child in this.transform)
        {
            if (child.name == name)
            {
                Text t = child.GetComponent<Text>();
                t.text = text;
                return;
            }
        }
        Debug.LogWarning("Not found objname:" + name);
    }


    public void SerchLocation()
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("BackGround"))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }

        SetText("Location", targetObj.GetComponent<BackGroundManager>().location);
    }
}
