/*
insert license info here
*/
using System;

namespace Daan.Interface.Entity
{
	/// <summary>
	///	Generated by MyGeneration using the IBatis Object Mapping template
	/// </summary>
	[Serializable]
	public sealed class DADictuser:BaseDomain
	{
		#region Private Members
		private bool isChanged;
		private bool isDeleted;
        private decimal? dictuserid; 
		private string usercode; 
		private string username; 
		private string password; 
		private string remark;
        private string isactive; 
		private DateTime createdate;
        private DateTime lastupdate;
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DADictuser()
		{
			dictuserid = null; 
			usercode = null; 
			username = null; 
			password = null; 
			remark = null; 
			isactive = null; 
			createdate = new DateTime();
            lastupdate = new DateTime();
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 用户ID，系统生成
		/// </summary>	
		[LogInfo("用户ID，系统生成")]
        public decimal? Dictuserid
		{
			get { return dictuserid; }
			set { isChanged |= (dictuserid != value); dictuserid = value; }
		}
			
		/// <summary>
		/// 用户编码或工号
		/// </summary>	
		[LogInfo("用户编码或工号")]
		public string Usercode
		{
			get { return usercode; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Usercode", value, value.ToString());
				
				isChanged |= (usercode != value); usercode = value;
			}
		}
			
		/// <summary>
		/// 用户名
		/// </summary>	
		[LogInfo("用户名")]
		public string Username
		{
			get { return username; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Username", value, value.ToString());
				
				isChanged |= (username != value); username = value;
			}
		}
			
		/// <summary>
		/// 用户密码
		/// </summary>	
		[LogInfo("用户密码")]
		public string Password
		{
			get { return password; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Password", value, value.ToString());
				
				isChanged |= (password != value); password = value;
			}
		}
			
		/// <summary>
		/// 备注
		/// </summary>	
		[LogInfo("备注")]
		public string Remark
		{
			get { return remark; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Remark", value, value.ToString());
				
				isChanged |= (remark != value); remark = value;
			}
		}
			
		/// <summary>
		/// 是否可用 0-否  1-是
		/// </summary>	
		[LogInfo("是否可用 0-否  1-是")]
        public string Isactive
		{
			get { return isactive; }
			set { isChanged |= (isactive != value); isactive = value; }
		}
			
		/// <summary>
		/// 记录生成日期
		/// </summary>	
		[LogInfo("记录生成日期")]
		public DateTime Createdate
		{
			get { return createdate; }
			set { isChanged |= (createdate != value); createdate = value; }
		}

        /// <summary>
        /// 更新时间
        /// </summary>	
        [LogInfo("更新时间")]
        public DateTime Lastupdate
        {
            get { return lastupdate; }
            set { isChanged |= (lastupdate != value); lastupdate = value; }
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
		
		
		#region Public Functions
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public void MarkAsDeleted()
		{
			isDeleted = true;
			isChanged = true;
		}
		
		#endregion
		
		
	}
}
