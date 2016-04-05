using UnityEngine;
namespace Actor
{
    public class NPC : MonoBehaviour
    {

        public string talk = "hello";
        public GameObject MessageManager;
        public GameObject QuizManeger;
        private bool isQuized;

        public CharType ct;

        // Use this for initialization
        void Start()
        {
            isQuized = true;
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
                    QuizManeger qm = QuizManeger.GetComponent<QuizManeger>();
                    qm.MakeQuiz(ct);
                    isQuized = false;
                }

            }
            else
            {
                MessageManager mm = MessageManager.GetComponent<MessageManager>();
                mm.WriteNameMassage(this.name);
                mm.WriteTalkMessage(talk);
            }
        }


    }

    public enum CharType { man, woman, professor }
}