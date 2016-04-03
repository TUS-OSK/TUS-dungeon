using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Actor
{
    public class QuizPanel : MonoBehaviour
    {
        private int colans;

        public Vector3 InPosition;
        public Vector3 OutPosition;

        public GameObject buttonRU;
        public GameObject buttonLU;
        public GameObject buttonRD;
        public GameObject buttonLD;

        public GameObject MessageManager;
        public GameObject QuizManeger;

        public string[] choice;


        // Use this for initialization
        void Start()
        {
            colans = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MoveIn(Quiz quiz)
        {
            this.GetComponent<Transform>().localPosition = InPosition;
            string col = quiz.choice[0];
            Shuffle(quiz.choice);
            if (col == quiz.choice[0])
                colans = 0;
            SetText("ButtonRU", quiz.choice[0]);
            if (col == quiz.choice[1])
                colans = 1;
            SetText("ButtonLU", quiz.choice[1]);
            if (col == quiz.choice[2])
                colans = 2;
            SetText("ButtonRD", quiz.choice[2]);
            if (col == quiz.choice[3])
                colans = 3;
            SetText("ButtonLD", quiz.choice[3]);
        }


        void Shuffle(string[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                string temp = deck[i];
                int randomIndex = Random.Range(0, deck.Length);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
        }

        public void SetText(string name, string text)
        {
            foreach (Transform child in this.transform)
            {
                if (child.name == name)
                {
                    foreach (Transform child2 in child.transform)
                    {
                        if (child2.name == "Text")
                        {
                            Text t = child2.GetComponent<Text>();
                            t.text = text;
                            
                            return;
                        }
                    }
                }
            }
            Debug.LogWarning("Not found objname:" + name);
        }

        public void MoveOut(int ans)
        {
            QuizManeger qm = QuizManeger.GetComponent<QuizManeger>();
            if (ans==colans)
            {
                //正解
                qm.QuizTorF(true);
            }
            else
            {
                //ハズレ
                qm.QuizTorF(false);
            }

            StartCoroutine(Wait(1.0f));
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            transform.localPosition = OutPosition;
        }
    }
}