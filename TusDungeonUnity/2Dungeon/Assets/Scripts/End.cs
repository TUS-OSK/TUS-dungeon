using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Actor {
    public class End : MonoBehaviour {

        // Use this for initialization
        void Start() {

            GameObject Goal = GameObject.Find("Goal");
            this.GetComponent<Text>().text = Goal.GetComponent<Goal>().GetNickName();
        }

        // Update is called once per frame
        void Update() {

        }

        public void ReStart()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}