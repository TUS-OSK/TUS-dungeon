using UnityEngine;
namespace Actor
{
    public class NPC : MonoBehaviour
    {

        public string talk = "hello";
        private GameObject MessageManager;
        private GameObject QuizManager;
        private bool isQuized;
        public bool isQuizEnd;

        public CharType ct;

        // Use this for initialization
        void Start()
        {
            isQuized = true;
            isQuizEnd = false;
            MessageManager = GameObject.FindGameObjectWithTag("MessageManager");
            QuizManager = GameObject.FindGameObjectWithTag("QuizManager");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTap()
        {
            if (isQuized)
            {
                if (this.GetComponent<BoxCollider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>()))
                {
                    MessageManager mm = MessageManager.GetComponent<MessageManager>();
                    mm.WriteNameMassage(this.name);
                    QuizManeger qm = this.QuizManager.GetComponent<QuizManeger>();
                    qm.MakeQuiz(this,ct);
                    isQuized = false;
                }

            }
            else
            {
                if (isQuizEnd)
                {
                    MessageManager mm = MessageManager.GetComponent<MessageManager>();
                    mm.WriteNameMassage(this.name);
                    mm.WriteTalkMessage(talk);
                }
            }
        }


    }

    public enum CharType { man, woman, professor }
}