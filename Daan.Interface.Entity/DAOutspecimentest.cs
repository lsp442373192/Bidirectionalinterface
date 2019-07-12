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
	public sealed class DAOutspecimentest:BaseDomain
	{
		#region Private Members
		private bool isChanged;
		private bool isDeleted;
		private decimal? outspecimentestid; 
		private string requestcode; 
		private string hospsampleid; 
		private string hospsamplenumber; 
		private string customertestcode; 
		private string customertestname; 
		private string datestcode;
        private string datestname;
        private string status; 
		private DateTime createdate;
        private string sampleType;

       
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DAOutspecimentest()
		{
			outspecimentestid = null; 
			requestcode = null; 
			hospsampleid = null; 
			hospsamplenumber = null; 
			customertestcode = null; 
			customertestname = null; 
			datestcode = null; 
			datestname = null; 
			createdate = new DateTime();
            status = null;
            sampleType = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>	
		[LogInfo("主键")]
		public decimal? Outspecimentestid
		{
			get { return outspecimentestid; }
			set { isChanged |= (outspecimentestid != value); outspecimentestid = value; }
		}
			
		/// <summary>
		/// 请求代码（达安条码）
		/// </summary>	
		[LogInfo("请求代码（达安条码）")]
		public string Requestcode
		{
			get { return requestcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Requestcode", value, value.ToString());
				
				isChanged |= (requestcode != value); requestcode = value;
			}
		}
			
		/// <summary>
		/// 医院条码
		/// </summary>	
		[LogInfo("医院条码")]
		public string Hospsampleid
		{
			get { return hospsampleid; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Hospsampleid", value, value.ToString());
				
				isChanged |= (hospsampleid != value); hospsampleid = value;
			}
		}
			
		/// <summary>
		/// 医院样本号
		/// </summary>	
		[LogInfo("医院样本号")]
		public string Hospsamplenumber
		{
			get { return hospsamplenumber; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Hospsamplenumber", value, value.ToString());
				
				isChanged |= (hospsamplenumber != value); hospsamplenumber = value;
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
				if( value!= null && value.Length > 2000)
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
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Customertestname", value, value.ToString());
				
				isChanged |= (customertestname != value); customertestname = value;
			}
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
				if( value!= null && value.Length > 2000)
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
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Datestname", value, value.ToString());
				
				isChanged |= (datestname != value); datestname = value;
			}
		}

        /// <summary>
        /// 项目状态
        /// </summary>	
        [LogInfo("项目状态")]
        public string Status
        {
            get { return status; }
            set
            {
                if (value != null && value.Length > 1)
                    throw new ArgumentOutOfRangeException("Invalid value for status", value, value.ToString());

                isChanged |= (status != value); status = value;
            }
        }
			
		/// <summary>
		/// 创建时间
		/// </summary>	
		[LogInfo("创建时间")]
		public DateTime Createdate
		{
			get { return createdate; }
			set { isChanged |= (createdate != value); createdate = value; }
		}
        /// <summary>
        /// 标本状态
        /// </summary>
        [LogInfo("标本状态")]
        public string SampleType
        {
            get { return sampleType; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for status", value, value.ToString());

                isChanged |= (sampleType != value); sampleType = value;
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
