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
	public sealed class DADictlibrary : BaseDomain
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private decimal? _dictlibraryid; 
		private string _librarytypecode; 
		private string _librarytypename; 
		private string _fastcode; 
		private string _active; 
		private decimal? _displayorder; 
		private string _libraryname; 
		private string _remark; 
		private string _englibraryname; 
		private DateTime _lastupdatedate; 
		private string _uniqueid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public DADictlibrary()
		{
			_dictlibraryid = 0; 
			_librarytypecode = null; 
			_librarytypename = null; 
			_fastcode = null; 
			_active = null; 
			_displayorder = 0; 
			_libraryname = null; 
			_remark = null; 
			_englibraryname = null; 
			_lastupdatedate = new DateTime(); 
			_uniqueid = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// ID,主键，自增长
		/// </summary>		
		public decimal? Dictlibraryid
		{
			get { return _dictlibraryid; }
			set { _isChanged |= (_dictlibraryid != value); _dictlibraryid = value; }
		}
			
		/// <summary>
		/// 库类别
		/// </summary>		
		public string Librarytypecode
		{
			get { return _librarytypecode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Librarytypecode", value, value.ToString());
				
				_isChanged |= (_librarytypecode != value); _librarytypecode = value;
			}
		}
			
		/// <summary>
		/// 库名字
		/// </summary>		
		public string Librarytypename
		{
			get { return _librarytypename; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Librarytypename", value, value.ToString());
				
				_isChanged |= (_librarytypename != value); _librarytypename = value;
			}
		}
			
		/// <summary>
		/// 助记码
		/// </summary>		
		public string Fastcode
		{
			get { return _fastcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Fastcode", value, value.ToString());
				
				_isChanged |= (_fastcode != value); _fastcode = value;
			}
		}
			
		/// <summary>
		/// 是否可用  0-否  1- 是
		/// </summary>		
		public string Active
		{
			get { return _active; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Active", value, value.ToString());
				
				_isChanged |= (_active != value); _active = value;
			}
		}
			
		/// <summary>
		/// 显示顺序
		/// </summary>		
		public decimal? Displayorder
		{
			get { return _displayorder; }
			set { _isChanged |= (_displayorder != value); _displayorder = value; }
		}
			
		/// <summary>
		/// 描述
		/// </summary>		
		public string Libraryname
		{
			get { return _libraryname; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Libraryname", value, value.ToString());
				
				_isChanged |= (_libraryname != value); _libraryname = value;
			}
		}
			
		/// <summary>
		/// 备注
		/// </summary>		
		public string Remark
		{
			get { return _remark; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Remark", value, value.ToString());
				
				_isChanged |= (_remark != value); _remark = value;
			}
		}
			
		/// <summary>
		/// 英文描述
		/// </summary>		
		public string Englibraryname
		{
			get { return _englibraryname; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Englibraryname", value, value.ToString());
				
				_isChanged |= (_englibraryname != value); _englibraryname = value;
			}
		}
			
		/// <summary>
		/// 最后操作时间，新增、修改都要保存最后操作的时间
		/// </summary>		
		public DateTime Lastupdatedate
		{
			get { return _lastupdatedate; }
			set { _isChanged |= (_lastupdatedate != value); _lastupdatedate = value; }
		}
			
		/// <summary>
		/// 全国统一码
		/// </summary>		
		public string Uniqueid
		{
			get { return _uniqueid; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Uniqueid", value, value.ToString());
				
				_isChanged |= (_uniqueid != value); _uniqueid = value;
			}
		}
			
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		
		#region Public Functions
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion
		
		
	}
}
