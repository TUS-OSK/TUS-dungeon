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
        SetText("Score",score.ToString());
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
