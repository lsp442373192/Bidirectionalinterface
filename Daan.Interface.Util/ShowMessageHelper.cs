using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Entity;

namespace Daan.Interface.Util
{
    public class ShowMessageHelper
    {
        #region >>>> zhouy 弹出消息

        /// <summary>
        /// 弹出消息
        /// </summary>
        /// <param name="msg">需要弹出的消息</param>
        public static DialogResult ShowBoxMsg(string msg)
        {
            return MessageBox.Show(msg, DefaultConfig.MSGTITLE);
        }

        /// <summary>
        /// 弹出消息-自定义按钮
        /// </summary>
        /// <param name="msg">需要弹出的消息</param>
        /// <param name="msgbtn">显示按钮</param>
        public static DialogResult ShowBoxMsg(string msg, MessageBoxButtons msgbtn)
        {
            return MessageBox.Show(msg, DefaultConfig.MSGTITLE, msgbtn);
        }

        /// <summary>
        /// 弹出消息-自定义按钮
        /// </summary>
        /// <param name="msg">需要弹出的消息</param>
        /// <param name="msgbtn">显示按钮</param>
        /// <param name="mbgicon">提示图标</param>
        public static DialogResult ShowBoxMsg(string msg, MessageBoxButtons msgbtn, MessageBoxIcon msgicon)
        {
            return MessageBox.Show(msg, DefaultConfig.MSGTITLE, msgbtn, msgicon);
        }

        /// <summary>
        /// 弹出消息-自定义按钮
        /// </summary>
        /// <param name="msg">需要弹出的消息</param>
        /// <param name="msgbtn">显示按钮</param>
        /// <param name="mbgicon">提示图标</param>
        /// <param name="msgdefbtn">默认按钮</param>
        public static DialogResult ShowBoxMsg(string msg, MessageBoxButtons msgbtn, MessageBoxIcon msgicon,MessageBoxDefaultButton msgdefbtn)
        {
            return MessageBox.Show(msg, DefaultConfig.MSGTITLE, msgbtn, msgicon, msgdefbtn);
        }

        #endregion
    }
}
