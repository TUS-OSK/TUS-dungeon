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

        public Sprite BackSprite;

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
                    QuizManager qm = this.QuizManager.GetComponent<QuizManager>();
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

        public void SpriteChange(bool isBack) {
            this.GetComponent<SpriteRenderer>().sprite = BackSprite;
        }


    }

    public enum CharType { man, woman, professor }
}