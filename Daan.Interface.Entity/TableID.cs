using System;

namespace Daan.Interface.Entity
{

	[Serializable]
	public class TableID 
	{

		#region Private Fields
		private String _name;
		private int _nextId;
		#endregion


		public TableID() { }

		public TableID(String name, int nextId) 
		{
			this._name = name;
			this._nextId = nextId;
		}

		#region Properties 

		public string Name 
		{
			set{_name = value;}
			get { return _name; }
		}


		public int NextId
		{
			set{_nextId = value;}
			get { return _nextId; }
		}
		#endregion

	}
}
