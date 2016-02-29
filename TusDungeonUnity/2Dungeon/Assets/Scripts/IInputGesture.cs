using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actor
{
    public interface InputGesture
    {
        /// <summary>
        /// ジェスチャーの処理優先度
        /// </summary>
        /// <value> 0が優先度高、数値が大きくなるにつれて優先度低 </value>
        int Order
        {
            get;
        }

        /// <summary>
        /// ジェスチャーを処理する必要があるのかを判定
        /// </summary>
        bool IsGestureProcess(GestureInfo info);

        /// <summary>
        /// ジェスチャー開始時に呼ばれる
        /// </summary>
        void OnGestureDown(GestureInfo info);

        /// <summary>
        /// ジェスチャー終了時に呼ばれる
        /// </summary>
        void OnGestureUp(GestureInfo info);

        /// <summary>
        /// ドラッグジェスチャー中に呼ばれる
        /// </summary>
        void OnGestureDrag(GestureInfo info);

        /// <summary>
        /// フリックジェスチャー時に呼ばれる
        /// </summary>
        void OnGestureFlick(GestureInfo info);
    }
}
