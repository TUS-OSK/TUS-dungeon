using UnityEngine;
using System.Collections;
namespace Actor
{
    public class NPC : MonoBehaviour {

        public string talk = "hello";
        public GameObject MessageManager;
        public GameObject QuizManeger;

        public string ColTalk = "正解";
        public string BadTalk = "ハズレ";

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void OnTap() {
            MessageManager mm = MessageManager.GetComponent<MessageManager>();
            mm.WriteNameMassage(this.name);
            mm.WriteTalkMassage(talk);
            QuizManeger qm = QuizManeger.GetComponent<QuizManeger>();
            qm.MakeQuiz(1);
        }

        public void ColTalkMessage()
        {
            MessageManager mm = MessageManager.GetComponent<MessageManager>();
            mm.WriteTalkMassage(ColTalk);
        }

        public void BadTalkMessage()
        {
            MessageManager mm = MessageManager.GetComponent<MessageManager>();
            mm.WriteTalkMassage(BadTalk);
        }

    }
}