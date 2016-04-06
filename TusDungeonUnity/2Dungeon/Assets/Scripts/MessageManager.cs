using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;

namespace Actor
{
    public class MessageManager : MonoBehaviour
    {

        public GameObject TalkMassage;
        public GameObject NameMassage;
        public GameObject QuizPanel;
        bool isCon;
        Quiz quiz;
        private string temp;

        // Use this for initialization
        void Start()
        {
            isCon = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void WriteTalkMessage(string message)
        {
            TalkMassage.GetComponent<Text>().text = message;
        }

        public void WriteTalkMessage(Quiz quiz)
        {
            TalkMassage.GetComponent<Text>().text = quiz.start;
            isCon = true;
            this.quiz = quiz;
        }

        public void WriteNameMassage(string name)
        {
            NameMassage.GetComponent<Text>().text = name;
        }

        public void OnTap()
        {
            temp = TalkMassage.GetComponent<Text>().text;
            //StartCoroutine(WaitRead(deleteTime,temp));
            if (isCon)
            {
                StartCoroutine(Wait(3.0f));
                isCon = false;
            }
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            QuizPanel.GetComponent<QuizPanel>().MoveIn(quiz);
        }

        private IEnumerator WaitRead(float time,string temp2)
        {
            yield return new WaitForSeconds(time);
            if (temp==temp2)
            {
                TalkMassage.GetComponent<Text>().text = " ";
            }
        }
    }

}