using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;


namespace Actor
{
    internal class QuizManeger : MonoBehaviour
    {
        QuizList quizlist;
        public GameObject quizpanel;
        private NPC npc;
        
        TextReader txtReader;
        string description;

        // Use this for initialization

        void Start()
        {
            var json = "{\"body\":[{\"problem\":\"東京理科大学の前身の名前は何でしょう\",\"choice\":[\"東京物理学校\",\"東京科学学校\",\"東京化学学校\",\"東京理科学校\"]},{\"problem\":\"東京理科大学の略称は何でしょう？\",\"choice\":[\"TUS\",\"TRD\",\"TDR\",\"TDN\"]}]}";
            quizlist = JsonUtility.FromJson<QuizList>(json);
            
            Debug.Log(quizlist.body[0].choice[0]);
        }
        

        // Update is called once per frame
        void Update()
        {

        }

        public void MakeQuiz(CharType ct, NPC npc)
        {
            //    Quiz quiz = new Quiz();
            //    quiz.problem = "Qust1";
            //    quiz.choice[0] = "A";
            //    quiz.choice[1] = "B";
            //    quiz.choice[2] = "C";
            //    quiz.choice[3] = "D";

            var quiz = quizlist.body[1];
            Debug.Log(quiz);
            this.npc = npc;
            QuizPanel qp = quizpanel.GetComponent<QuizPanel>();
            qp.MoveIn(quiz);
        }
        



    }

    [Serializable]
    public class Quiz
    {
        public string problem;
        public string start;
        public string correct;
        public string wrong;
        public string[] choice; 
        //public string[] choice { get; set; }
    }

    [Serializable]
    public class QuizList
    {
        public List<Quiz> body;
        //public Quiz[] body { get; set; }
    }
}
