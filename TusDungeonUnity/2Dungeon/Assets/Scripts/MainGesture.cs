﻿using UnityEngine;
using System.Collections;

namespace Actor
{
    public class MainGesture : MonoBehaviour, InputGesture
    {
        private Camera mainCamera;
        private GameObject player;
        public InputGestureManager IGM;

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
            InputGestureManager.Instance.UnregisterGesture(this);
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