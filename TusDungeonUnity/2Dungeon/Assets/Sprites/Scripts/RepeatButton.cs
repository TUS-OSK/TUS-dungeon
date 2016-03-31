using UnityEngine;
using System.Collections;

namespace Actor
{
    public class RepeatButton : MonoBehaviour
    {

        private GameObject player;
        MoveDirection md;

        public void StartPush(int dir)
        {
            MoveDirection md=MoveDirection.none;
            switch (dir)
            {
                case 0:
                    md=MoveDirection.up;
                    break;
                case 1:
                    md = MoveDirection.down;
                    break;
                case 2:
                    md = MoveDirection.right;
                    break;
                case 3:
                    md = MoveDirection.left;
                    break;
                default:
                    break;
            }
            Player pl = player.GetComponent<Player>();
            pl.Move(md);
        }

        public void StopPush()
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.none);
        }

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
        }
    }
}