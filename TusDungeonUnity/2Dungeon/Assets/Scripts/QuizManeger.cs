using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Actor
{
    internal class QuizManeger : MonoBehaviour
    {
        QuizList quizlist;
        public GameObject quizpanel;
        private NPC npc;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MakeQuiz(int level,NPC npc)
        {
            //return quizlist.body[(int)UnityEngine.Random.value];
            Quiz quiz = new Quiz();
            quiz.problem = "Qust1";
            quiz.choice[0] = "A";
            quiz.choice[1] = "B";
            quiz.choice[2] = "C";
            quiz.choice[3] = "D";

            this.npc = npc;
            QuizPanel qp = quizpanel.GetComponent<QuizPanel>();
            qp.MoveIn(quiz);
        }

        public void QuizTorF(bool isCol) {
            NPC n = npc.GetComponent<NPC>();
            if (isCol)
            {
                n.ColTalkMessage();
            }
            else
                    {
                n.BadTalkMessage();
            }
        }
        

        
    }

    [Serializable]
    public class Quiz
    {
        public string problem { get; set; }
        public string[] choice { get; set; }
        public Quiz() {
            choice = new string[] { "A", "B", "C", "D" };
        }
    }

    [Serializable]
    public class QuizList
    {
        public Quiz[] body { get; set; }

        public QuizList()
        {
            body = new Quiz[100];
        }
    }
}
