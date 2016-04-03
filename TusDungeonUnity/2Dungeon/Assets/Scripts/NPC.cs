using UnityEngine;
namespace Actor
{
    public class NPC : MonoBehaviour {

        public string talk = "hello";
        public GameObject MessageManager;
        public GameObject QuizManeger;

        public CharType ct;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void OnTap() {
            if (this.GetComponent<BoxCollider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>()))
            {
            MessageManager mm = MessageManager.GetComponent<MessageManager>();
            mm.WriteNameMassage(this.name);
            mm.WriteTalkMassage(talk);
            QuizManeger qm = QuizManeger.GetComponent<QuizManeger>();
            qm.MakeQuiz(ct);

            }
        }
        

    }

    public enum CharType {man,woman,professor}
}