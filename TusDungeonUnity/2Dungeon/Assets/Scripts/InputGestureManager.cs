using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actor
{
    using UnityEngine;
    using System.Collections.Generic;

    public class InputGestureManager : SingletonMonoBehaviour<InputGestureManager> 
    {
        /// <summary>
        /// 登録済みのジェスチャー配列
        /// </summary>

        private List<InputGesture> gestures = new List<InputGesture>();

        /// <summary>
        /// ジェスチャー情報
        /// </summary>
        private GestureInfo gestureInfo = new GestureInfo();

        /// <summary>
        /// ジェスチャー中のトレースを有効にするかどうか
        /// </summary>
        public bool IsTrace = true;

        /// <summary>
        /// トレース中の位置情報
        /// </summary>
        private Queue<Vector3> tracePositionQueue = new Queue<Vector3>();

        /// <summary>
        /// トレース中の時間情報
        /// </summary>
        private Queue<float> traceTimeQueue = new Queue<float>();

        /// <summary>
        /// トレースデータ保持数
        /// </summary>
        public int TraceQueryCount = 20;

        /// <summary>
        /// 登録済みのジェスチャー配列
        /// </summary>
        public List<InputGesture> Gestures
        {
            get { return gestures; }
            set { gestures = value; }
        }

        /// <summary>
        /// 現在処理中のジェスチャー情報
        /// </summary>
        private InputGesture processingGesture
        {
            get;
            set;
        }

        /// <summary>
        /// ジェスチャーの追加
        /// </summary>
        public void RegisterGesture(InputGesture gesture)
        {
            var index = this.gestures.FindIndex(g => g.Order > gesture.Order);
            if (index < 0)
            {
                index = this.gestures.Count;
            }
            this.gestures.Insert(index, gesture);
        }

        /// <summary>
        /// ジェスチャーの解除を行います
        /// </summary>
        public void UnregisterGesture(InputGesture gesture)
        {
            this.gestures.Remove(gesture);
        }

        void Start()
        {
            if (!IsTrace)
            {
                this.TraceQueryCount = 2;
            }
        }

        void Update()
        {
            this.gestureInfo.IsDown = false;
            this.gestureInfo.IsUp = false;
            this.gestureInfo.IsDrag = false;

            // 入力チェック
            var isInput = IsTouchPlatform() ? InputForTouch(ref this.gestureInfo) : InputForMouse(ref this.gestureInfo);
            if (!isInput)
            {
                // 入力なし
                return;
            }

            // 入力処理
            if (this.gestureInfo.IsDown)
            {
                DoDown(this.gestureInfo);
            }
            if (this.gestureInfo.IsDrag)
            {
                DoDrag(this.gestureInfo);
            }
            if (this.gestureInfo.IsUp)
            {
                DoUp(this.gestureInfo);
            }
        }

        /// <summary>
        /// タッチパネル向けのプラットフォームかどうか取得します
        /// </summary>
        /// <returns>スマートフォン/タブレットの場合にtrueを返します</returns>
        bool IsTouchPlatform()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// タッチされたタッチ情報を取得します
        /// </summary>
        /// <returns>タッチ情報を返します。何もタッチされていなければnullを返します</returns>
        Touch? GetTouch()
        {
            if (Input.touchCount <= 0)
            {
                return null;
            }
            // 前回と同じタッチを追跡します
            for (int n = 0; n < Input.touchCount; n++)
            {
                if (gestureInfo.TouchId == Input.touches[n].fingerId)
                {
                    return Input.touches[n];
                }
            }
            // 新規タッチ(タッチ開始時のみ)
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                gestureInfo.TouchId = Input.touches[0].fingerId;
                return Input.touches[0];
            }

            return null;
        }

        /// <summary>
        /// タッチ入力情報をGestureInfoへ変換します
        /// </summary>
        /// <returns>入力情報があればtrueを返します</returns>
        bool InputForTouch(ref GestureInfo info)
        {
            Touch? touch = GetTouch();
            if (!touch.HasValue)
            {
                return false;
            }

            info.ScreenPosition = touch.GetValueOrDefault().position;
            info.DeltaPosition = touch.GetValueOrDefault().deltaPosition;
            switch (touch.GetValueOrDefault().phase)
            {
                case TouchPhase.Began:
                    info.IsDown = true;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    info.IsDrag = true;
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    info.IsUp = true;
                    gestureInfo.TouchId = -1;
                    break;
            }
            return true;
        }

        /// <summary>
        /// マウス入力情報をGestureInfoへ変換します
        /// </summary>
        /// <returns>入力情報があればtrueを返します</returns>
        bool InputForMouse(ref GestureInfo info)
        {
            if (Input.GetMouseButtonDown(0))
            {
                info.IsDown = true;
                info.DeltaPosition = new Vector3();
                info.ScreenPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                info.IsUp = true;
                info.DeltaPosition = Input.mousePosition - info.ScreenPosition;
                info.ScreenPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                info.IsDrag = true;
                info.DeltaPosition = Input.mousePosition - info.ScreenPosition;
                info.ScreenPosition = Input.mousePosition;
            }
            return true;
        }

        /// <summary>
        /// ジェスチャー開始処理を行います
        /// </summary>
        void DoDown(GestureInfo info)
        {
            this.processingGesture = gestures.Find(ges => ges.IsGestureProcess(info));
            if (this.processingGesture == null)
            {
                return;
            }

            ClearTracePosition();

            info.DeltaTime = 0;
            info.DragDistance = new Vector3();
            info.StartPosition = info.ScreenPosition;
            
            this.processingGesture.OnGestureDown(info);
        }

        /// <summary>
        /// ドラッグジェスチャー処理を行います
        /// </summary>
        void DoDrag(GestureInfo info)
        {
            if (this.processingGesture == null)
            {
                return;
            }

            AddTracePosition(info.ScreenPosition);
            info.DeltaTime = IsTrace ? GetTraceDeltaTime() : info.DeltaTime + Time.deltaTime;
            info.DragDistance = IsTrace ? GetTraceVector(0, 0) : info.DragDistance + GetTraceVector(0, 0);
            info.DragDirection = IsTrace ? GetTraceVector(info.StartPosition, 0) : info.DragDistance + GetTraceVector(info.StartPosition, 0);

            this.processingGesture.OnGestureDrag(info);
        }

        /// <summary>
        /// ジェスチャー終了処理を行います
        /// </summary>
        void DoUp(GestureInfo info)
        {
            if (this.processingGesture == null)
            {
                return;
            }

            info.DeltaTime = IsTrace ? GetTraceDeltaTime() : info.DeltaTime + Time.deltaTime;
            info.DragDistance = IsTrace ? GetTraceVector(0, 0) : info.DragDistance + GetTraceVector(0, 0);
            this.processingGesture.OnGestureUp(info);

            // フリックジェスチャー判定
            var v1 = GetTraceVector(0, 0);
            var v2 = GetTraceVector(this.tracePositionQueue.Count - 5, 0);
            var dot = Vector3.Dot(v1.normalized, v2.normalized);
            if (dot > 0.9)
            {
                this.processingGesture.OnGestureFlick(info);
            }

            this.processingGesture = null;
        }

        /// <summary>
        /// トレース情報をクリアします
        /// </summary>
        void ClearTracePosition()
        {
            this.tracePositionQueue.Clear();
            this.traceTimeQueue.Clear();
        }

        /// <summary>
        /// ドラッグジェスチャー中の入力位置を追加します
        /// </summary>
        void AddTracePosition(Vector3 trace_position)
        {
            this.tracePositionQueue.Enqueue(trace_position);
            this.traceTimeQueue.Enqueue(Time.deltaTime);

            if (this.tracePositionQueue.Count > TraceQueryCount)
            {
                this.tracePositionQueue.Dequeue();
                this.traceTimeQueue.Dequeue();
            }
        }

        /// <summary>
        /// トレース経過時間を取得します
        /// </summary>
        float GetTraceDeltaTime()
        {
            float delta = 0;
            var times = this.traceTimeQueue.ToArray();
            foreach (var t in times)
            {
                delta += t;
            }

            return delta;
        }

        /// <summary>
        /// トレースデータからベクトルを取得します
        /// </summary>
        Vector3 GetTraceVector(int start_index_ofs, int end_index_ofs)
        {
            var positions = this.tracePositionQueue.ToArray();
            var sindex = start_index_ofs;
            var eindex = positions.Length - 1 - end_index_ofs;
            if (sindex < 0)
            {
                sindex = 0;
            }
            if (eindex < 0)
            {
                eindex = positions.Length - 1;
            }
            if (sindex >= positions.Length)
            {
                sindex = positions.Length - 1;
            }
            if (eindex >= positions.Length)
            {
                eindex = positions.Length - 1;
            }
            if (sindex > eindex)
            {
                var temp = sindex;
                sindex = eindex;
                eindex = temp;
            }
            return positions[eindex] - positions[sindex];
        }

        Vector3 GetTraceVector(Vector3 startpos, int end_index_ofs)
        {
            var positions = this.tracePositionQueue.ToArray();
            var eindex = positions.Length - 1 - end_index_ofs;

            if (eindex < 0)
            {
                eindex = positions.Length - 1;
            }

            if (eindex >= positions.Length)
            {
                eindex = positions.Length - 1;
            }
            return positions[eindex] - startpos;
        }

        /// <summary>
        /// デバッグ表示のOn/Off
        /// </summary>
        public bool showDebug = false;

        /// <summary>
        /// デバッグ表示
        /// </summary>
        void OnGUI()
        {
            if (showDebug)
            {
                var info = this.gestureInfo;
                int x = 0;
                int y = 0;
                GUI.Label(new Rect(x, y, 300, 20), "ScreenPosition = " + info.ScreenPosition.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "DeltaPosition = " + info.DeltaPosition.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "IsDown = " + info.IsDown.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "IsDrag = " + info.IsDrag.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "IsUp = " + info.IsUp.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "DeltaTime = " + info.DeltaTime.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "DragDistance = " + info.DragDistance.ToString());
                y += 20;
                GUI.Label(new Rect(x, y, 300, 20), "processingGesture = " + (this.processingGesture == null ? "null" : "live"));
            }
        }
    }
}
