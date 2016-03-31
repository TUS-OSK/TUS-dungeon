using UnityEngine;
using System.Collections;

namespace Actor
{
    public class Player : MonoBehaviour
    {
        Animator anim;
        Operater operater;
        public float speed = 0.01f;


        // Use this for initialization
        void Start()
        {
            this.operater = new Operater();
            this.anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {



        }

        public void Move(Vector3 direction)
        {
            Vector2 vel= new Vector2(0,0);
            vel = new Vector2(speed*direction.x,speed*direction.y);
            GetComponent<Rigidbody2D>().velocity = vel;
            anim.SetFloat("x_vel", vel.x);
            anim.SetFloat("y_vel", vel.y);
            Debug.Log(GetComponent<Rigidbody2D>().velocity);

        }

        public void Move(MoveDirection md)
        {
            Vector2 vel=new Vector2(0,0);

            switch (md)
            {
                case MoveDirection.none:
                    vel = new Vector2(0, 0);
                    break;
                case MoveDirection.up:
                    vel = new Vector2(0, speed);
                    break;
                case MoveDirection.down:
                    vel = new Vector2(0, -speed);
                    break;
                case MoveDirection.right:
                    vel = new Vector2(speed, 0);
                    break;
                case MoveDirection.left:
                    vel = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }
            GetComponent<Rigidbody2D>().velocity = vel;
        }
    }

    public enum MoveDirection{none,up,down,right,left};
}