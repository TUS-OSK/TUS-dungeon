using UnityEngine;
using System.Collections;

namespace Actor
{
    public class MainGesture : MonoBehaviour, InputGesture
    {
        private Camera mainCamera;
        private GameObject player;
        public InputGestureManager IGM;
        public MessageManager messagemanager;

        void Awake()
        {
            EnableGesture();
            mainCamera = Camera.main;
            player = GameObject.FindWithTag("Player");
        }
        void OnDestroy()
        {
            DisableGesture();
        }

        public void EnableGesture()
        {
            InputGestureManager.Instance.RegisterGesture(this);
        }
        public void DisableGesture()
        {
            //InputGestureManager.Instance.UnregisterGesture(this);
        }

        public int Order
        {
            get { return 0; }
        }

        public bool IsGestureProcess(GestureInfo info)
        {
            return true;
        }

        public void OnGestureDown(GestureInfo info)
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d)
            {
                GameObject obj = aCollider2d.transform.gameObject;
                Debug.Log(obj.name);
                NPC npc = obj.GetComponent<NPC>();
                if (npc!=null)
                {
                    npc.OnTap();
                }
                messagemanager.OnTap();
            }
        }

        public void OnGestureUp(GestureInfo info)
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(MoveDirection.none);
        }

        public void OnGestureDrag(GestureInfo info)
        {
            Player pl = player.GetComponent<Player>();
            pl.Move(info.DragDirection);
        }

        public void OnGestureFlick(GestureInfo info)
        {

        }
    }

}