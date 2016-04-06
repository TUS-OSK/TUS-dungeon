using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;


namespace Actor
{
    internal class QuizManager : MonoBehaviour
    {
        QuizList quizlist;
        public GameObject quizpanel;
        public GameObject Player;
        public GameObject StatusPanel;
        private NPC npc;
        
        TextReader txtReader;
        string description;

        int Score;

        // Use this for initialization

        void Start()
        {
            var textAsset = Resources.Load("QuizList1") as TextAsset;
            quizlist = JsonUtility.FromJson<QuizList>(textAsset.text);
            Score = 0;
            StatusPanel.GetComponent<StatusPanel>().WriteScore(Score);
        }
        

        // Update is called once per frame
        void Update()
        {

        }

        public void MakeQuiz(NPC npc,CharType ct)
        {
            this.npc = npc;
            Player.GetComponent<Player>().isMove = false;
            int n= UnityEngine.Random.Range(0,quizlist.body.Count-1);
            var quiz = quizlist.body[n];
            quizlist.body.Remove(quiz);
            QuizPanel qp = quizpanel.GetComponent<QuizPanel>();
            qp.RendQuiz(quiz);
            
        }

        public void EndQuiz()
        {
            StatusPanel.GetComponent<StatusPanel>().WriteScore(Score);
            npc.isQuizEnd = true;
            Player.GetComponent<Player>().isMove = true;
        }
        
        public void CCincrement()
        {
            switch (npc.ct)
            {
                case CharType.man:
                    Score++;
                    break;
                case CharType.woman:
                    Score += 3;
                    break;
                case CharType.professor:
                    Score += 2;
                    break;
                default:
                    Score++;
                    break;
            }
        }

        public int GetScore()
        {
            return this.Score;
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
