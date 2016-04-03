using UnityEngine;
using System.Collections;

namespace Actor
{
    public class Player : MonoBehaviour
    {
        Animator anim;

        public float speed = 0.01f;


        // Use this for initialization
        void Start()
        {
            this.anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 vel = GetComponent<Rigidbody2D>().velocity;
            if (vel.x==0&&vel.y==0)
            {
                anim.speed = 0;
            }

        }

        public void Move(Vector3 direction)
        {
            Vector2 vel= new Vector2(0,0);
            vel = new Vector2(speed*direction.x,speed*direction.y);
            GetComponent<Rigidbody2D>().velocity = vel;
            anim.speed = 1;
            int dir = 0;
            
            //east:0,west=1,north=2,South=3
            if (vel.y<vel.x)
            {
                if (-vel.x<vel.y)
                {
                    dir = 0;
                }
                if (-vel.x>vel.y)
                {
                    dir = 3;
                }
            }
            if (vel.x < vel.y)
            {
                if (-vel.x < vel.y)
                {
                    dir = 2;
                }
                if (-vel.x > vel.y)
                {
                    dir = 1;
                }
            }
            anim.SetInteger("MoveDire",dir);
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