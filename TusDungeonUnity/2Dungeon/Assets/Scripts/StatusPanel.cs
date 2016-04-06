using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
            nm = "普通の理科大生";
        if (score >= 30)
            nm = "リア充理科大生";
        if (score >= 40)
            nm = "エリート理科大生";
        if (score >= 50)
            nm = "理科大マニア";
        if (score >= 55)
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
}
