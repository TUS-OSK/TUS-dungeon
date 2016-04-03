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
        
        TextReader txtReader;
        string description;

        // Use this for initialization

        void Start()
        {
            var textAsset = Resources.Load("QuizList") as TextAsset;
            quizlist = JsonUtility.FromJson<QuizList>(textAsset.text);
            
            Debug.Log(quizlist.body[0].choice[0]);
        }
        

        // Update is called once per frame
        void Update()
        {

        }

        public void MakeQuiz(CharType ct)
        {
            //    Quiz quiz = new Quiz();
            //    quiz.problem = "Qust1";
            //    quiz.choice[0] = "A";
            //    quiz.choice[1] = "B";
            //    quiz.choice[2] = "C";
            //    quiz.choice[3] = "D";

            var quiz = quizlist.body[1];
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
    }

    [Serializable]
    public class QuizList
    {
        public List<Quiz> body;
    }
}
