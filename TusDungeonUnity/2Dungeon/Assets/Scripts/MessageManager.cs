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
            if (isCon)
            {
                StartCoroutine(Wait(1.0f));
                isCon = false;
            }
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            QuizPanel.GetComponent<QuizPanel>().MoveIn(quiz);
        }
    }

}