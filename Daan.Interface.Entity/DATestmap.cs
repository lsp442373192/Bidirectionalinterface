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
	public sealed class DATestmap:BaseDomain
	{
		#region Private Members
		private bool isChanged;
		private bool isDeleted;
		private decimal? testmapid; 
		private string datestcode; 
		private string datestname; 
		private string customertestcode; 
		private string customertestname; 
		private DateTime createtime;
        private string dagroupcode;
        private string dagroupname;
        private DateTime lastupdate;
       

		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DATestmap()
		{
			testmapid = null; 
			datestcode = null; 
			datestname = null; 
			customertestcode = null; 
			customertestname = null; 
			createtime = new DateTime();
            dagroupcode = null;
            dagroupname = null;
            lastupdate = new DateTime();
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>	
		[LogInfo("主键")]
		public decimal? Testmapid
		{
			get { return testmapid; }
			set { isChanged |= (testmapid != value); testmapid = value; }
		}
			
		/// <summary>
		/// 达安项目代码
		/// </summary>	
		[LogInfo("达安项目代码")]
		public string Datestcode
		{
			get { return datestcode; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Datestcode", value, value.ToString());
				
				isChanged |= (datestcode != value); datestcode = value;
			}
		}
			
		/// <summary>
		/// 达安项目名称
		/// </summary>	
		[LogInfo("达安项目名称")]
		public string Datestname
		{
			get { return datestname; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Datestname", value, value.ToString());
				
				isChanged |= (datestname != value); datestname = value;
			}
		}
			
		/// <summary>
		/// 客户项目代码
		/// </summary>	
		[LogInfo("客户项目代码")]
		public string Customertestcode
		{
			get { return customertestcode; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Customertestcode", value, value.ToString());
				
				isChanged |= (customertestcode != value); customertestcode = value;
			}
		}
			
		/// <summary>
		/// 客户项目名称
		/// </summary>	
		[LogInfo("客户项目名称")]
		public string Customertestname
		{
			get { return customertestname; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Customertestname", value, value.ToString());
				
				isChanged |= (customertestname != value); customertestname = value;
			}
		}
			
		/// <summary>
		/// 创建时间
		/// </summary>	
		[LogInfo("创建时间")]
		public DateTime Createtime
		{
			get { return createtime; }
			set { isChanged |= (createtime != value); createtime = value; }
		}

        public string Dagroupcode
        {
            get { return datestcode; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Datestcode", value, value.ToString());
				
				isChanged |= (datestcode != value); datestcode = value;
			}
           
        }

        public string Dagroupname
        {
            get { return datestname; }
            set
            {
                if (value != null && value.Length > 80)
                    throw new ArgumentOutOfRangeException("Invalid value for Datestname", value, value.ToString());

                isChanged |= (datestname != value); datestname = value;
            }
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