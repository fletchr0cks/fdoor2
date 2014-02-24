﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqToTwitterMvcDemo.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="fd1")]
	public partial class fddbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertggl(ggl instance);
    partial void Updateggl(ggl instance);
    partial void Deleteggl(ggl instance);
    partial void Inserttwt(twt instance);
    partial void Updatetwt(twt instance);
    partial void Deletetwt(twt instance);
    #endregion
		
		public fddbDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["fd1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public fddbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public fddbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public fddbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public fddbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<ggl> ggls
		{
			get
			{
				return this.GetTable<ggl>();
			}
		}
		
		public System.Data.Linq.Table<twt> twts
		{
			get
			{
				return this.GetTable<twt>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[user]")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Guid _guid;
		
		private System.DateTime _lastlogin;
		
		private EntitySet<ggl> _ggls;
		
		private EntitySet<twt> _twts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnguidChanging(System.Guid value);
    partial void OnguidChanged();
    partial void OnlastloginChanging(System.DateTime value);
    partial void OnlastloginChanged();
    #endregion
		
		public user()
		{
			this._ggls = new EntitySet<ggl>(new Action<ggl>(this.attach_ggls), new Action<ggl>(this.detach_ggls));
			this._twts = new EntitySet<twt>(new Action<twt>(this.attach_twts), new Action<twt>(this.detach_twts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_guid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid guid
		{
			get
			{
				return this._guid;
			}
			set
			{
				if ((this._guid != value))
				{
					this.OnguidChanging(value);
					this.SendPropertyChanging();
					this._guid = value;
					this.SendPropertyChanged("guid");
					this.OnguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastlogin", DbType="DateTime NOT NULL")]
		public System.DateTime lastlogin
		{
			get
			{
				return this._lastlogin;
			}
			set
			{
				if ((this._lastlogin != value))
				{
					this.OnlastloginChanging(value);
					this.SendPropertyChanging();
					this._lastlogin = value;
					this.SendPropertyChanged("lastlogin");
					this.OnlastloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_ggl", Storage="_ggls", ThisKey="id", OtherKey="userid")]
		public EntitySet<ggl> ggls
		{
			get
			{
				return this._ggls;
			}
			set
			{
				this._ggls.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_twt", Storage="_twts", ThisKey="id", OtherKey="userid")]
		public EntitySet<twt> twts
		{
			get
			{
				return this._twts;
			}
			set
			{
				this._twts.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ggls(ggl entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_ggls(ggl entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
		
		private void attach_twts(twt entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_twts(twt entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ggl")]
	public partial class ggl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _userid;
		
		private string _refreshtoken;
		
		private string _idlist;
		
		private int _status;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnuseridChanging(int value);
    partial void OnuseridChanged();
    partial void OnrefreshtokenChanging(string value);
    partial void OnrefreshtokenChanged();
    partial void OnidlistChanging(string value);
    partial void OnidlistChanged();
    partial void OnstatusChanging(int value);
    partial void OnstatusChanged();
    #endregion
		
		public ggl()
		{
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userid", DbType="Int NOT NULL")]
		public int userid
		{
			get
			{
				return this._userid;
			}
			set
			{
				if ((this._userid != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnuseridChanging(value);
					this.SendPropertyChanging();
					this._userid = value;
					this.SendPropertyChanged("userid");
					this.OnuseridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_refreshtoken", DbType="VarChar(MAX)")]
		public string refreshtoken
		{
			get
			{
				return this._refreshtoken;
			}
			set
			{
				if ((this._refreshtoken != value))
				{
					this.OnrefreshtokenChanging(value);
					this.SendPropertyChanging();
					this._refreshtoken = value;
					this.SendPropertyChanged("refreshtoken");
					this.OnrefreshtokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idlist", DbType="VarChar(MAX)")]
		public string idlist
		{
			get
			{
				return this._idlist;
			}
			set
			{
				if ((this._idlist != value))
				{
					this.OnidlistChanging(value);
					this.SendPropertyChanging();
					this._idlist = value;
					this.SendPropertyChanged("idlist");
					this.OnidlistChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Int NOT NULL")]
		public int status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_ggl", Storage="_user", ThisKey="userid", OtherKey="id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.ggls.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.ggls.Add(this);
						this._userid = value.id;
					}
					else
					{
						this._userid = default(int);
					}
					this.SendPropertyChanged("user");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.twt")]
	public partial class twt : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _userid;
		
		private string _twtid;
		
		private string _accesstoken;
		
		private string _oauthtoken;
		
		private int _status;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnuseridChanging(int value);
    partial void OnuseridChanged();
    partial void OntwtidChanging(string value);
    partial void OntwtidChanged();
    partial void OnaccesstokenChanging(string value);
    partial void OnaccesstokenChanged();
    partial void OnoauthtokenChanging(string value);
    partial void OnoauthtokenChanged();
    partial void OnstatusChanging(int value);
    partial void OnstatusChanged();
    #endregion
		
		public twt()
		{
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userid", DbType="Int NOT NULL")]
		public int userid
		{
			get
			{
				return this._userid;
			}
			set
			{
				if ((this._userid != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnuseridChanging(value);
					this.SendPropertyChanging();
					this._userid = value;
					this.SendPropertyChanged("userid");
					this.OnuseridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_twtid", DbType="VarChar(MAX)")]
		public string twtid
		{
			get
			{
				return this._twtid;
			}
			set
			{
				if ((this._twtid != value))
				{
					this.OntwtidChanging(value);
					this.SendPropertyChanging();
					this._twtid = value;
					this.SendPropertyChanged("twtid");
					this.OntwtidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_accesstoken", DbType="VarChar(MAX)")]
		public string accesstoken
		{
			get
			{
				return this._accesstoken;
			}
			set
			{
				if ((this._accesstoken != value))
				{
					this.OnaccesstokenChanging(value);
					this.SendPropertyChanging();
					this._accesstoken = value;
					this.SendPropertyChanged("accesstoken");
					this.OnaccesstokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_oauthtoken", DbType="VarChar(MAX)")]
		public string oauthtoken
		{
			get
			{
				return this._oauthtoken;
			}
			set
			{
				if ((this._oauthtoken != value))
				{
					this.OnoauthtokenChanging(value);
					this.SendPropertyChanging();
					this._oauthtoken = value;
					this.SendPropertyChanged("oauthtoken");
					this.OnoauthtokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Int NOT NULL")]
		public int status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_twt", Storage="_user", ThisKey="userid", OtherKey="id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.twts.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.twts.Add(this);
						this._userid = value.id;
					}
					else
					{
						this._userid = default(int);
					}
					this.SendPropertyChanged("user");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
