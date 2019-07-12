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
    public sealed class VDaLisrequesttest : BaseDomain
    {
        #region Private Members
        private bool isChanged;
        private bool isDeleted;
        private string hospsampleid;
        private string hospsamplenumber;
        private string patientnumber;
        private string testcode;
        private string testname;
        private string datestcode;
        private string datestname;

        private  bool isselect;
        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public VDaLisrequesttest()
        {
            hospsampleid = null;
            hospsamplenumber = null;
            patientnumber = null;
            testcode = null;
            testname = null;
            datestcode = null;
            datestname = null;
            IsSelect = true;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelect
        {
            get { return isselect; }
            set { isselect = value; }
        }

        /// <summary>
        /// 
        /// </summary>	
        [LogInfo("")]
        public string Hospsampleid
        {
            get { return hospsampleid; }
            set
            {
                if (value != null && value.Length > 40)
                    throw new ArgumentOutOfRangeException("Invalid value for Hospsampleid", value, value.ToString());

                isChanged |= (hospsampleid != value); hospsampleid = value;

                if (hospsampleid != null) { hospsampleid = hospsampleid.Trim(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>	
        [LogInfo("")]
        public string Hospsamplenumber
        {
            get { return hospsamplenumber; }
            set
            {
                if (value != null && value.Length > 40)
                    throw new ArgumentOutOfRangeException("Invalid value for Hospsamplenumber", value, value.ToString());

                isChanged |= (hospsamplenumber != value); hospsamplenumber = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>	
        [LogInfo("")]
        public string Patientnumber
        {
            get { return patientnumber; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for Patientnumber", value, value.ToString());

                isChanged |= (patientnumber != value); patientnumber = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>	
        [LogInfo("")]
        public string Testcode
        {
            get { return testcode; }
            set
            {
                //if( value!= null && value.Length > 20)
                //    throw new ArgumentOutOfRangeException("Invalid value for Testcode", value, value.ToString());

                isChanged |= (testcode != value); testcode = value;
                if (testcode != null) { testcode = testcode.Trim(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>	
        [LogInfo("")]
        public string Testname
        {
            get { return testname; }
            set
            {
                //if( value!= null && value.Length > 100)
                //    throw new ArgumentOutOfRangeException("Invalid value for Testname", value, value.ToString());

                isChanged |= (testname != value); testname = value;
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
                //if (value != null && value.Length > 100)
                //    throw new ArgumentOutOfRangeException("Invalid value for Datestcode", value, value.ToString());

                isChanged |= (datestcode != value); datestcode = value;

                if (datestcode != null) { datestcode = datestcode.Trim(); }
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
                //if (value != null && value.Length >200)
                //    throw new ArgumentOutOfRangeException("Invalid value for Datestname", value, value.ToString());

                isChanged |= (datestname != value); datestname = value;
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
