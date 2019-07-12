using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daan.Interface.Dao;
using Daan.Interface.BLL;
using System.Collections;
using Daan.Interface.Entity;
using Daan.Interface.Util;

namespace Daan.LIMS.Manage
{
    public partial class FrmModifyPwd : Form
    {
        #region property
        DADictuserBLL userBll = new DADictuserBLL();
        DESEncrypt desencrypt = new DESEncrypt();
        private string _userCode =string.Empty;
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }
        private string password = string.Empty;
        #endregion

        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        #region >>>> fhp 页面事件
        
        private void FrmModifyPwd_Load(object sender, EventArgs e)
        {
            //医院用户才能修改密码
            if (SystemConfig.UserInfo.UserType == 1)
            {
                UserCode = SystemConfig.UserInfo.UserCode;
                DADictuser user = new DADictuser();
                user.Usercode = UserCode;
                user = userBll.GetDADictuserInfoByUserCode(user);
                password = user.Password;
            }
            else
            {
                btnOK.Enabled = false;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //验证
            if (desencrypt.getMd5Hash(tbxOldUserPwd.Text.ToString()) != password)
            {
                ShowMessageHelper.ShowBoxMsg("旧密码错误,请重新输入!");
                tbxOldUserPwd.Focus();
                return;
            }
            if (tbxUserPwd.Text.Contains(" "))
            {
                ShowMessageHelper.ShowBoxMsg("密码不能存在空格!");
                tbxUserPwd.Focus();
                return;
            }
            if (tbxUserPwd.Text == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("密码不能为空!");
                tbxUserPwd.Focus();
                return;
            }
            if (tbxUserPwd.Text.Trim().Length < 6)
            {
                ShowMessageHelper.ShowBoxMsg("密码过于简单,请输入大于6位的密码!");
                return;
            }
            if (tbxPwdOK.Text.ToString() != tbxUserPwd.Text.ToString())
            {
                ShowMessageHelper.ShowBoxMsg("两次输入的密码不一致,请重新输入!");
                tbxPwdOK.Focus();
                return;
            }

            DADictuser user = new DADictuser();
            user.Usercode = UserCode;
            user = userBll.GetDADictuserInfoByUserCode(user);
            user.Password = desencrypt.getMd5Hash(tbxPwdOK.Text.ToString());
            if (userBll.Save(user))
            {
                ShowMessageHelper.ShowBoxMsg("修改成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("修改失败!");
            }
        }
        #endregion
    }
}
