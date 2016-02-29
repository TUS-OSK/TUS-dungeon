using UnityEngine;
using System.Collections;

namespace Actor
{
    public class ButtonClick : MonoBehaviour
    {

        private GameObject player;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClickRight()
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.right);
        }

        public void OnClickLeft()
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.left);
        }
        public void OnClickUp()
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.up);
        }
        public void OnClickDown()
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.down);
        }
    }
}