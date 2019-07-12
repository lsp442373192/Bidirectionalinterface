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
	public sealed class DAReport:BaseDomain
	{
		#region Private Members
		private bool isChanged;
		private bool isDeleted;
		private decimal? reportid; 
		private string requestcode; 
		private string hospsamplenumber; 
		private string hospsampleid; 
        private byte[] reportdata; 
		private DateTime createdate; 
		private decimal? printcount; 
		private DateTime? printtime; 
		private string reporttype; 
		private string status;
        private string papersize;
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DAReport()
		{
			reportid = null; 
			requestcode = null; 
			hospsamplenumber = null; 
			hospsampleid = null;
            reportdata = new byte[0]; 
			createdate = new DateTime(); 
			printcount = null; 
			printtime =null; 
			reporttype = null; 
			status = null;
            papersize = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>	
		[LogInfo("主键")]
        public decimal? Reportid
		{
			get { return reportid; }
			set { isChanged |= (reportid != value); reportid = value; }
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
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Requestcode", value, value.ToString());
				
				isChanged |= (requestcode != value); requestcode = value;
			}
		}
			
		/// <summary>
		/// 医院样本号（唯一）
		/// </summary>	
		[LogInfo("医院样本号（唯一）")]
		public string Hospsamplenumber
		{
			get { return hospsamplenumber; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Hospsamplenumber", value, value.ToString());
				
				isChanged |= (hospsamplenumber != value); hospsamplenumber = value;
			}
		}
			
		/// <summary>
		/// 医院条码（唯一）
		/// </summary>	
		[LogInfo("医院条码（唯一）")]
		public string Hospsampleid
		{
			get { return hospsampleid; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Hospsampleid", value, value.ToString());
				
				isChanged |= (hospsampleid != value); hospsampleid = value;
			}
		}
			
		/// <summary>
		/// 报告内容 BASE64编码
		/// </summary>	
		[LogInfo("报告内容 BASE64编码")]
        public byte[] Reportdata
		{
			get { return reportdata; }
			set { isChanged |= (reportdata != value); reportdata = value; }
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
		/// 打印次数
		/// </summary>	
		[LogInfo("打印次数")]
		public decimal? Printcount
		{
			get { return printcount; }
			set { isChanged |= (printcount != value); printcount = value; }
		}
			
		/// <summary>
		/// 打印时间
		/// </summary>	
		[LogInfo("打印时间")]
		public DateTime? Printtime
		{
			get { return printtime; }
			set { isChanged |= (printtime != value); printtime = value; }
		}
			
		/// <summary>
		/// 报告类型（直接写汉字）分为：常规报告、病理报告、微生物报告
		/// </summary>	
		[LogInfo("报告类型（直接写汉字）分为：常规报告、病理报告、微生物报告")]
		public string Reporttype
		{
			get { return reporttype; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Reporttype", value, value.ToString());
				
				isChanged |= (reporttype != value); reporttype = value;
			}
		}
			
		/// <summary>
		/// 1正常报告2取消审核报告
		/// </summary>	
		[LogInfo("1正常报告2取消审核报告")]
		public string Status
		{
			get { return status; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				isChanged |= (status != value); status = value;
			}
		}


        /// <summary>
        /// 纸张大小A4 A5
        /// </summary>	
        [LogInfo("纸张大小A4 A5")]
        public string Papersize
        {
            get { return papersize; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Papersize", value, value.ToString());

                isChanged |= (papersize != value); papersize = value;
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
