using System;

namespace Daan.Interface.Entity
{
    /// <summary>
	///	登录用户信息
	/// </summary>
	[Serializable]
	public sealed class LoginUserInfo
    {
        #region Private Members
        private bool isChanged;
        private bool isDeleted;
        private int? _userType;
        private string _userName;
        private string _userId;
        private string _userCode;
        private string _sid;
        #endregion

        #region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
        public LoginUserInfo()
		{
            _userType = null;
            _userName=null;
            _userId=null;
            _userCode = null;
            _sid = null;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// 当前用户登录类型 0-达安外勤 1-医院用户
        /// </summary>	
        [LogInfo("当前用户登录类型 0-达安外勤 1-医院用户")]
        public int? UserType
        {
            get { return _userType; }
            set { isChanged |= (_userType != value); _userType = value; }
        }

        /// <summary>
        /// 当前用户名
        /// </summary>	
        [LogInfo("当前用户名")]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentOutOfRangeException("Invalid value for Dbversion", value, value.ToString());

                isChanged |= (_userName != value); _userName = value;
            }
        }

        /// <summary>
        /// 当前用户ID
        /// </summary>	
        [LogInfo("当前用户ID")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentOutOfRangeException("Invalid value for Hospname", value, value.ToString());

                isChanged |= (_userId != value); _userId = value;
            }
        }

        /// <summary>
        /// 当前用户编码或工号
        /// </summary>	
        [LogInfo("当前用户编码或工号")]
        public string UserCode
        {
            get { return _userCode; }
            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentOutOfRangeException("Invalid value for Conveta4", value, value.ToString());

                isChanged |= (_userCode != value); _userCode = value;
            }
        }

        /// <summary>
        /// 当前用户登录webserivce的SID
        /// </summary>	
        [LogInfo("当前用户登录webserivce的SID")]
        public string SID
        {
            get { return _sid; }
            set
            {
                if (value != null && value.Length > 200)
                    throw new ArgumentOutOfRangeException("Invalid value for SID", value, value.ToString());

                isChanged |= (_sid != value); _sid = value;
            }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsChanged
        {
            get { return isChanged; }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        #endregion 
    }
    

}
