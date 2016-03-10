using UnityEngine;
using System.Collections;

namespace Actor
{
    public class Player : MonoBehaviour
    {
        Operater operater;
        public float speed = 0.01f;
        // Use this for initialization
        void Start()
        {
            this.operater = new Operater();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(Vector3 direction)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed*direction.x,speed*direction.y);
        }

        public void Move(MoveDirection md)
        {
            switch (md)
            {
                case MoveDirection.none:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    break;
                case MoveDirection.up:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                    break;
                case MoveDirection.down:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                    break;
                case MoveDirection.right:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    break;
                case MoveDirection.left:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }
        }
    }

    public enum MoveDirection{none,up,down,right,left};
}