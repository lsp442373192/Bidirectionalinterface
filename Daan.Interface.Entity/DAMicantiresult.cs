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
	public sealed class DAMicantiresult:BaseDomain
	{
		#region Private Members
		private bool isChanged;
		private bool isDeleted;
		private decimal? micantiresultid; 
		private string hospsamplenumber; 
		private string hospsampleid; 
		private string requestcode; 
		private decimal? micorgresultid; 
		private string anticode; 
		private string antiname; 
		private string engantiname; 
		private decimal? displayorder; 
		private string resultvalue; 
		private string testresult; 
		private decimal? srange; 
		private decimal? rrange; 
		private DateTime createdate; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DAMicantiresult()
		{
			micantiresultid = null; 
			hospsamplenumber = null; 
			hospsampleid = null; 
			requestcode = null; 
			micorgresultid = null; 
			anticode = null; 
			antiname = null; 
			engantiname = null; 
			displayorder = null; 
			resultvalue = null; 
			testresult = null; 
			srange = null; 
			rrange = null; 
			createdate = new DateTime(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 抗生素结果ID，系统内码
		/// </summary>	
		[LogInfo("抗生素结果ID，系统内码")]
		public decimal? Micantiresultid
		{
			get { return micantiresultid; }
			set { isChanged |= (micantiresultid != value); micantiresultid = value; }
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
				if( value!= null && value.Length > 20)
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
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Hospsampleid", value, value.ToString());
				
				isChanged |= (hospsampleid != value); hospsampleid = value;
			}
		}
			
		/// <summary>
		/// 请求代码（达安条码号）
		/// </summary>	
		[LogInfo("请求代码（达安条码号）")]
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
		/// 细菌结果ID，系统内码
		/// </summary>	
		[LogInfo("细菌结果ID，系统内码")]
		public decimal? Micorgresultid
		{
			get { return micorgresultid; }
			set { isChanged |= (micorgresultid != value); micorgresultid = value; }
		}
			
		/// <summary>
		/// 
		/// </summary>	
		[LogInfo("")]
		public string Anticode
		{
			get { return anticode; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Anticode", value, value.ToString());
				
				isChanged |= (anticode != value); anticode = value;
			}
		}
			
		/// <summary>
		/// 抗生素中文名
		/// </summary>	
		[LogInfo("抗生素中文名")]
		public string Antiname
		{
			get { return antiname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Antiname", value, value.ToString());
				
				isChanged |= (antiname != value); antiname = value;
			}
		}
			
		/// <summary>
		/// 抗生素英文名
		/// </summary>	
		[LogInfo("抗生素英文名")]
		public string Engantiname
		{
			get { return engantiname; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Engantiname", value, value.ToString());
				
				isChanged |= (engantiname != value); engantiname = value;
			}
		}
			
		/// <summary>
		/// 显示及打印顺序
		/// </summary>	
		[LogInfo("显示及打印顺序")]
		public decimal? Displayorder
		{
			get { return displayorder; }
			set { isChanged |= (displayorder != value); displayorder = value; }
		}
			
		/// <summary>
		/// 结果值   存KB值或MIC值
		/// </summary>	
		[LogInfo("结果值   存KB值或MIC值")]
		public string Resultvalue
		{
			get { return resultvalue; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Resultvalue", value, value.ToString());
				
				isChanged |= (resultvalue != value); resultvalue = value;
			}
		}
			
		/// <summary>
		/// 最终测定/显示的结果   存耐药、敏感、中介
		/// </summary>	
		[LogInfo("最终测定/显示的结果   存耐药、敏感、中介")]
		public string Testresult
		{
			get { return testresult; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Testresult", value, value.ToString());
				
				isChanged |= (testresult != value); testresult = value;
			}
		}
			
		/// <summary>
		/// 抗生素敏感起始值
		/// </summary>	
		[LogInfo("抗生素敏感起始值")]
		public decimal? Srange
		{
			get { return srange; }
			set { isChanged |= (srange != value); srange = value; }
		}
			
		/// <summary>
		/// 抗生素耐药起始值
		/// </summary>	
		[LogInfo("抗生素耐药起始值")]
		public decimal? Rrange
		{
			get { return rrange; }
			set { isChanged |= (rrange != value); rrange = value; }
		}
			
		/// <summary>
		/// 
		/// </summary>	
		[LogInfo("")]
		public DateTime Createdate
		{
			get { return createdate; }
			set { isChanged |= (createdate != value); createdate = value; }
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