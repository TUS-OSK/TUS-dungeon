using UnityEngine;
using System.Collections;

namespace Actor
{

    public class GestureInfo
    {

        /// <summary>
        /// ジェスチャー座標
        /// </summary>
        public Vector3 ScreenPosition
        {
            get;
            set;
        }

        /// <summary>
        /// 前フレームからの移動距離
        /// </summary>
        public Vector3 DeltaPosition
        {
            get;
            set;
        }
        
        public Vector3 StartPosition
        {
            get;
            set;
        }
        public Vector3 DragDirection
        {
            get;
            set;
        }

        /// <summary>
        /// 前フレームからの経過時間
        /// </summary>
        public double DeltaTime
        {
            get;
            set;
        }

        /// <summary>
        /// ドラッグ距離
        /// </summary>
        /// <value> トレース有効時は特定期間中のドラッグ距離 </value>
        public Vector3 DragDistance
        {
            get;
            set;
        }

        /// <summary>
        /// 管理しているタッチ
        /// </summary>
        public int TouchId
        {
            get;
            set;
        }

        /// <summary>
        /// ジェスチャーステータス
        /// </summary>
        public bool IsDown
        {
            get;
            set;
        }
        public bool IsUp
        {
            get;
            set;
        }
        public bool IsDrag
        {
            get;
            set;
        }
    }
}