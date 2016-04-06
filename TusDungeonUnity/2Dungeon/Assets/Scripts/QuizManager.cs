using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;


namespace Actor
{
    internal class QuizManager : MonoBehaviour
    {
        QuizList quizlistman;
        QuizList quizlistwoman;
        QuizList quizlistprof;
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
            var textAsset = Resources.Load("QuizListMan") as TextAsset;
            quizlistman = JsonUtility.FromJson<QuizList>(textAsset.text);
            textAsset = Resources.Load("QuizListWoman") as TextAsset;
            quizlistwoman = JsonUtility.FromJson<QuizList>(textAsset.text);
            textAsset = Resources.Load("QuizListProf") as TextAsset;
            quizlistprof = JsonUtility.FromJson<QuizList>(textAsset.text);
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
            int n = 0;
            Quiz quiz;
            
            switch (ct)
            {
                case CharType.man:
                    n = UnityEngine.Random.Range(0, quizlistman.body.Count - 1);
                    quiz = quizlistman.body[n];
                    quizlistman.body.Remove(quiz);
                    break;
                case CharType.woman:
                    n = UnityEngine.Random.Range(0, quizlistwoman.body.Count - 1);
                    quiz = quizlistwoman.body[n];
                    quizlistwoman.body.Remove(quiz);
                    break;
                case CharType.professor:
                    n = UnityEngine.Random.Range(0, quizlistprof.body.Count - 1);
                    quiz = quizlistprof.body[n];
                    quizlistprof.body.Remove(quiz);
                    break;
                default:
                    n = UnityEngine.Random.Range(0, quizlistman.body.Count - 1);
                    quiz = quizlistman.body[n];
                    quizlistman.body.Remove(quiz);
                    break;
            }
            QuizPanel qp = quizpanel.GetComponent<QuizPanel>();
            qp.RendQuiz(quiz);
            
        }

        public void EndQuiz()
        {
            StatusPanel.GetComponent<StatusPanel>().WriteScore(Score);
            npc.isQuizEnd = true;
            npc.SpriteChange(true);
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
