using UnityEngine;
using System.Collections;

namespace Actor
{
    public class Goal : MonoBehaviour
    {

        public Vector3 InPosition;
        public Vector3 OutPosition;

        private GameObject MessageManager;
        public GameObject YesNoPanel;
        public GameObject QuizManager;
        

        private static bool created = false;
        int score = 0;

        void Awake()
        {
            if (!created)
            {
                // シーンを切り替えても指定のオブジェクトを破棄せずに残す
                DontDestroyOnLoad(this.gameObject);
                // 生成した
                created = true;
            }
            else {
                Destroy(this.gameObject);
            }
        }

        // Use this for initialization
        void Start()
        {
            MessageManager = GameObject.FindGameObjectWithTag("MessageManager");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D col)
        {
            MessageManager.GetComponent<MessageManager>().WriteTalkMessage("この先はゴールになっています。現在の成績で終了しますか？");
            YesNoPanel.GetComponent<YesNoPanel>().MoveIn();
        }

        public void OnTouchYes()
        {
            this.score = QuizManager.GetComponent<QuizManager>().GetScore();
            Application.LoadLevel("EndScene");
        }

        public void OnTouchNo()
        {
            YesNoPanel.GetComponent<YesNoPanel>().MoveOut();
        }

        public string GetNickName() {
            string nm = "新入生";
            if (score >= 0)
                nm = "新入生";
            if (score >= 1)
                nm = "駆け出し理科大生";
            if (score >= 5)
                nm = "新米理科大生";
            if (score >= 10)
                nm = "情弱理科大生";
            if (score >= 20)
                nm = "普通の理科大生";
            if (score >= 30)
                nm = "リア充理科大生";
            if (score >= 40)
                nm = "エリート理科大生";
            if (score >= 50)
                nm = "理科大マニア";
            if (score >= 55)
                nm = "理科大エキスパート";
            return nm;
        }

    }
}