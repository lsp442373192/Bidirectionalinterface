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
    public partial class FrmUserAdd : Form
    {
        #region property
        DADictuserBLL userBll = new DADictuserBLL();
        DESEncrypt desencrypt = new DESEncrypt();
        private string curUserCode = string.Empty;
        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _userCode = "";
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }
        private string password = string.Empty;
        #endregion

        public FrmUserAdd()
        {
            InitializeComponent();
        }

        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            //获取当前用户编号
            if (SystemConfig.UserInfo != null)
            {
                curUserCode = SystemConfig.UserInfo.UserCode;
            }
            DataBind();
        }
        //关闭
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //保存
        private void btnSava_Click(object sender, EventArgs e)
        {
            DADictuser user = new DADictuser();
            user.Dictuserid = Id;
            if (tbxUserCode.Text.Contains(" "))
            {
                ShowMessageHelper.ShowBoxMsg("用户编码不能存在空格!");
                tbxUserCode.Focus();
                return;
            }
            if (tbxUserCode.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("用户编码不能为空!");
                tbxUserCode.Focus();
                return;
            }
            user.Usercode = tbxUserCode.Text.Trim().ToString();
            if (isExist(user))
            {
                ShowMessageHelper.ShowBoxMsg("用户编码已经存在,请重新输入!");
                tbxUserCode.Focus();
                return;
            }
            if (tbxUserName.Text.Trim() == string.Empty)
            {
                ShowMessageHelper.ShowBoxMsg("用户名称不能为空!");
                tbxUserName.Focus();
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
            if (tbxUserPwd.Text.Length < 6)
            {
                ShowMessageHelper.ShowBoxMsg("密码过于简单,请输入大于6位的密码!");
                return;
            }
            if (tbxPwdOK.Text.ToString() !=tbxUserPwd.Text.ToString())
            {
                ShowMessageHelper.ShowBoxMsg("两次输入的密码不一致,请重新输入!");
                tbxPwdOK.Focus();
                return;
            }
            if (tbxPwdOK.Text.ToString() == password)
            {
                user.Password = password;
            }
            else
            {
                user.Password = desencrypt.getMd5Hash(tbxPwdOK.Text.ToString());
            }
            user.Usercode = tbxUserCode.Text.Trim().ToString();
            user.Username = tbxUserName.Text.ToString();
            user.Isactive = cbUserIdOK.Checked == true ? "1" : "0";
            user.Remark = tbxUserDescript.Text.ToString();
            user.Createdate = DateTime.Now;
            if (userBll.Save(user))
            {
                ShowMessageHelper.ShowBoxMsg("保存成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowMessageHelper.ShowBoxMsg("保存失败!");
            }
        }
        //绑定数据
        private void DataBind()
        {
            
            if (Id != 0)
            {
                
                //限制用户修改权限
                if (curUserCode.ToLower() != "admin" && UserCode.ToLower() != curUserCode.ToLower())
                {
                    //当前用户不是管理员时不能保存
                    btnSava.Enabled = false;
                }
                //当前用户为管理员，要修改的用户也为管理员，不能修改管理员用户名
                if (curUserCode.ToLower() == "admin" && UserCode.ToLower() == "admin")
                {
                    tbxUserCode.Enabled = false;
                }
                //当前用户不为管理员,修改的是自己的用户
                if (curUserCode.ToLower() != "admin" && UserCode.ToLower() == curUserCode.ToLower())
                {
                    btnSava.Enabled = true;
                    tbxUserCode.Enabled = false;
                }
                Hashtable ht = new Hashtable();
                ht.Add("Dictuserid", Id);
                List<DADictuser> userLst = userBll.GetDADictuserInfo(ht);

                if (userLst.Count>0)
                {
                    
                    DADictuser user = userLst[0];
                    tbxUserCode.Text = user.Usercode;
                    tbxUserName.Text = user.Username;
                    tbxUserPwd.Text =user.Password;
                    tbxPwdOK.Text = user.Password;
                    password = user.Password;
                    tbxUserDescript.Text = user.Remark;
                    if (user.Isactive == "1")
                    {
                        cbUserIdOK.Checked = true;
                    }
                    else
                    {
                        cbUserIdOK.Checked = false;
                    }
                }
            }
            else
            {
                this.Text = "添加用户信息";
            }
        }
        //判断是否已经存在用户编码
        private bool isExist(DADictuser dictUser)
        {
            bool istrue = false;
            DADictuser user = new DADictuser();
            user = userBll.GetDADictuserInfoByUserCode(dictUser);
            if (user != null)
            {
                if (Id==0)//如果是添加
                {
                    istrue = true;
                }
                else
                {
                    if (user.Dictuserid != dictUser.Dictuserid)
                    {
                        istrue = true;
                    }
                }
            }
            return istrue;
        }
        
    }
}
