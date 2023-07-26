using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;

namespace CS2010.ArcSys.Business
{
	/// <summary>Class used to hold data read from the config file</summary>
	public class Config
	{
		#region Constructors

		static Config()
		{
			_EDIConfig = new EDIConfiguration();
		}
		#endregion		// #region Constructors

		#region EDI Config

		private static EDIConfiguration _EDIConfig;
		public static EDIConfiguration EDIConfig { get { return _EDIConfig; } }

		public static int EDISectionCount { get { return EDIConfig.Count; } }

		public static void LoadEDIConfig()
		{
			EDIConfig.LoadSections();
		}
		#endregion		// #region EDI Config
	}

	/// <summary>Class used to hold data read from the config file specific to EDI</summary>
	public class EDIConfiguration : IEnumerable
	{
		#region Fields/Properties/Indexers

		private List<EDIConfigurationSection> Sections;
		public int Count { get { return Sections.Count; } }

		private bool _ShowArchive;
		public bool ShowArchive { get { return _ShowArchive; } set { _ShowArchive = value; } }

		EDIConfigurationSection this[int index]
		{
			get { return (index >= 0 && index < Sections.Count) ? Sections[index] : null; }
		}

		EDIConfigurationSection this[string sectionName]
		{
			get
			{
				return Sections.Find(delegate(EDIConfigurationSection sec)
				{ return string.Compare(sec.SectionInformation.Name, sectionName, true) == 0; });
			}
		}
		#endregion		// #region Fields/Properties/Indexers

		#region Constructors/Initialization

		public EDIConfiguration()
		{
			_ShowArchive = false;
			Sections = new List<EDIConfigurationSection>();
		}

		public void LoadSections()
		{
			
			if( Sections == null )
				Sections = new List<EDIConfigurationSection>();
			else
				Sections.Clear();

			Configuration config =
				ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			foreach( ConfigurationSectionGroup grp in config.SectionGroups )
			{
				foreach( ConfigurationSection sec in grp.Sections )
				{
					EDIConfigurationSection edisec = sec as EDIConfigurationSection;
					if( edisec == null ) continue;

					Sections.Add(edisec);
				}
			}
		}
		#endregion		// #region Constructors/Initialization

		#region Public Methods

		public List<string> GetScanDirectories()
		{
			List<string> result = new List<string>();
			if( Sections != null && Sections.Count > 0 )
			{
				foreach( EDIConfigurationSection sec in Sections )
				{
					result.Add(sec.ErrorSubFolder);
					if( ShowArchive ) result.Add(sec.ArchiveSubFolder);
				}
			}
			return result;
		}

		public List<string> GetUniqueDelimiters()
		{
			List<string> result = new List<string>();
			if( Sections != null && Sections.Count > 0 )
			{
				foreach( EDIConfigurationSection sec in Sections )
					foreach( EDIDelimiter delim in sec.Delimiters )
						if( !result.Contains(delim.Delimiter) ) result.Add(delim.Delimiter);
			}
			return result;
		}

		public List<string> GetUniqueITVUsers()
		{
			List<string> result = new List<string>();
			if( Sections != null && Sections.Count > 0 )
			{
				foreach( EDIConfigurationSection sec in Sections )
					foreach( ITVUser user in sec.ITVUsers )
						if( !result.Contains(user.User) ) result.Add(user.User);
			}
			return result;
		}
		#endregion		// #region Public Methods

		#region IEnumerable Interface Implementation

		public IEnumerator GetEnumerator()
		{
			return new EDIConfiguratoinSectionEnumerator(Sections);
		}

		private class EDIConfiguratoinSectionEnumerator : IEnumerator
		{
			#region Fields and Constructor

			private int Position;
			public EDIConfigurationSection[] Sections;

			public EDIConfiguratoinSectionEnumerator(List<EDIConfigurationSection> list)
			{
				Sections = list.ToArray();
				Position = -1;
			}
			#endregion		// #region Fields and Constructor

			#region IEnumerator Interface Implementation

			public object Current
			{
				get { return Sections[Position]; }
			}

			public bool MoveNext()
			{
				Position++;
				return (Position < Sections.Length);
			}

			public void Reset()
			{
				Position = -1;
			}
			#endregion		// #region IEnumerator Interface Implementation
		}
		#endregion		// #region IEnumerable Interface Implementation
	}

	#region Delimiter Collection Definition
	[ConfigurationCollection(typeof(EDIDelimiter),
		CollectionType=ConfigurationElementCollectionType.AddRemoveClearMap)]
	public class EDIDelimiterCollection : ConfigurationElementCollection
	{
		#region Constants

		private const string ElementPropName = "EDIDelimiter";

		#endregion		// #region Constants

		#region Static Section

		private static ConfigurationPropertyCollection CollectionProperties;

		static EDIDelimiterCollection()
		{
			CollectionProperties = new ConfigurationPropertyCollection();
		}
		#endregion		// #region Static Section

		#region Constructors

		public EDIDelimiterCollection()
		{
		}
		#endregion		// #region Constructors

		#region Indexers

		public EDIDelimiter this[int index]
		{
			get { return base.BaseGet(index) as EDIDelimiter; }
			set
			{
				if( base.BaseGet(index) != null ) base.BaseRemoveAt(index);
				base.BaseAdd(index, value);
			}
		}

		new public EDIDelimiter this[string name]
		{
			get { return base.BaseGet(name) as EDIDelimiter; }
		}
		#endregion		// #region Indexers

		#region Overrides

		protected override ConfigurationPropertyCollection Properties
		{
			get { return CollectionProperties; }
		}

		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.BasicMap; }
		}

		protected override string ElementName
		{
			get { return ElementPropName; }
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new EDIDelimiter();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as EDIDelimiter).FieldName;
		}
		#endregion		// #region Overrides
		}
	#endregion

	#region ITV User Collection Definition
	[ConfigurationCollection(typeof(ITVUser),
		CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
	public class ITVUserCollection : ConfigurationElementCollection
	{
		#region Constants

		private const string ElementPropName = "ITVUser";

		#endregion		// #region Constants

		#region Static Section

		private static ConfigurationPropertyCollection CollectionProperties;

		static ITVUserCollection()
		{
			CollectionProperties = new ConfigurationPropertyCollection();
		}
		#endregion		// #region Static Section

		#region Constructors

		public ITVUserCollection()
		{
		}
		#endregion		// #region Constructors

		#region Indexers

		public ITVUser this[int index]
		{
			get { return base.BaseGet(index) as ITVUser; }
			set
			{
				if( base.BaseGet(index) != null ) base.BaseRemoveAt(index);
				base.BaseAdd(index, value);
			}
		}

		new public ITVUser this[string name]
		{
			get { return base.BaseGet(name) as ITVUser; }
		}
		#endregion		// #region Indexers

		#region Overrides

		protected override ConfigurationPropertyCollection Properties
		{
			get { return CollectionProperties; }
		}

		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.BasicMap; }
		}

		protected override string ElementName
		{
			get { return ElementPropName; }
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ITVUser();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as ITVUser).User;
		}
		#endregion		// #region Overrides
	}
	#endregion

	#region Individual Delimiter Definition
	public class EDIDelimiter : ConfigurationElement
	{
		#region Constants

		private const string DelimiterPropName = "Delimiter";
		private const string FieldNamePropName = "FieldName";
		private const string PositionPropName = "Position";

		#endregion		// #region Constants

		#region Static Programmatic Implementation

		private static ConfigurationProperty DelimiterProperty;
		private static ConfigurationProperty FieldNameProperty;
		private static ConfigurationProperty PositionProperty;

		private static ConfigurationPropertyCollection ElementProperties;

		static EDIDelimiter()
		{
			DelimiterProperty = new ConfigurationProperty(DelimiterPropName,
				typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			FieldNameProperty = new ConfigurationProperty(FieldNamePropName,
				typeof(string), null, ConfigurationPropertyOptions.IsRequired);
			PositionProperty = new ConfigurationProperty(PositionPropName,
				typeof(int), 0, ConfigurationPropertyOptions.IsRequired);

			ElementProperties = new ConfigurationPropertyCollection();
			ElementProperties.Add(DelimiterProperty);
			ElementProperties.Add(FieldNameProperty);
			ElementProperties.Add(PositionProperty);
		}
		#endregion		// #region Static Programmatic Implementation

		#region Declarative Implementation

		public EDIDelimiter()
		{
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get { return ElementProperties; }
		}

		[ConfigurationProperty(DelimiterPropName, IsRequired = true)]
		public string Delimiter
		{
			get { return base[DelimiterProperty] as string; }
			set { base[DelimiterProperty] = value; }
		}

		[ConfigurationProperty(FieldNamePropName, IsRequired = true)]
		public string FieldName
		{
			get { return base[FieldNameProperty] as string; }
			set { base[FieldNameProperty] = value; }
		}

		[ConfigurationProperty(PositionPropName, IsRequired = true)]
		public int Position
		{
			get { return (int)base[PositionProperty]; }
			set { base[PositionProperty] = value; }
		}
		#endregion		// #region Declarative Implementation
	}
	#endregion

	#region Individual ITV User  Definition
	public class ITVUser : ConfigurationElement
	{
		#region Constants

		private const string UserPropName = "User";

		#endregion		// #region Constants

		#region Static Programmatic Implementation

		private static ConfigurationProperty UserProperty;

		private static ConfigurationPropertyCollection ElementProperties;

		static ITVUser()
		{
			UserProperty = new ConfigurationProperty(UserPropName,
				typeof(string), null, ConfigurationPropertyOptions.IsRequired);

			ElementProperties = new ConfigurationPropertyCollection();
			ElementProperties.Add(UserProperty);
		}
		#endregion		// #region Static Programmatic Implementation

		#region Declarative Implementation

		public ITVUser()
		{
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get { return ElementProperties; }
		}

		[ConfigurationProperty(UserPropName, IsRequired = true)]
		public string User
		{
			get { return base[UserProperty] as string; }
			set { base[UserProperty] = value; }
		}

		#endregion		// #region Declarative Implementation
	}
	#endregion

	#region Main EDI Configuration Section
	public class EDIConfigurationSection : ConfigurationSection
	{
		#region Constants

		private const string MessageNoPropName = "MessageNo";
		private const string MessageDscPropName = "MessageDsc";
		private const string ArchiveSubFolderPropName = "ArchiveSubFolder";
		private const string ErrorSubFolderPropName = "ErrorSubFolder";
		private const string ProcessSubFolderPropName = "ProcessSubFolder";
		private const string InOutPropName="InOut";
		private const string SerialDelimiterName = "SerialDelimiter";
		private const string SerialPositionName = "SerialPosition";
		private const string ActionDelimiterName = "ActionDelimiter";
		private const string POLDelimiterName = "POLDelimiter";
		private const string MainDelimiterName = "MainDelimiter";
		private const string MainPositionName = "MainPosition";
		private const string ActionPositionName = "ActionPosition";
		private const string POLPositionName = "POLPosition";
		private const string DelimiterCollectionPropName = "EDIDelimiters";
		private const string ITVUserCollectionPropName = "ITVUsers";


		#endregion		// #region Constants

		#region Static Programmatic Implementation

		private static ConfigurationProperty MessageNoProperty;
		private static ConfigurationProperty MessageDscProperty;
		private static ConfigurationProperty ArchiveSubFolderProperty;
		private static ConfigurationProperty ErrorSubFolderProperty;
		private static ConfigurationProperty ProcessSubFolderProperty;
		private static ConfigurationProperty InOutProperty;
		private static ConfigurationProperty SerialDelimterProperty;
		private static ConfigurationProperty SerialPositionProperty;
		private static ConfigurationProperty ActionDelimterProperty;
		private static ConfigurationProperty POLDelimiterProperty;
		private static ConfigurationProperty MainDelimiterProperty;
		private static ConfigurationProperty ActionPositionProperty;
		private static ConfigurationProperty POLPositionProperty;
		private static ConfigurationProperty DelimiterCollectionProperty;
		private static ConfigurationProperty ITVUserCollectionProperty;

		private static ConfigurationPropertyCollection SectionProperties;

		static EDIConfigurationSection()
		{
			MessageNoProperty = new ConfigurationProperty(MessageNoPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			MessageDscProperty = new ConfigurationProperty(MessageDscPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			ArchiveSubFolderProperty = new ConfigurationProperty(ArchiveSubFolderPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			ErrorSubFolderProperty = new ConfigurationProperty(ErrorSubFolderPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			ProcessSubFolderProperty = new ConfigurationProperty(ProcessSubFolderPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			InOutProperty = new ConfigurationProperty(InOutPropName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			SerialDelimterProperty = new ConfigurationProperty(SerialDelimiterName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			SerialPositionProperty = new ConfigurationProperty(SerialPositionName,
				typeof(int), 0, ConfigurationPropertyOptions.None);
			ActionDelimterProperty = new ConfigurationProperty(ActionDelimiterName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			POLDelimiterProperty = new ConfigurationProperty(POLDelimiterName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			MainDelimiterProperty = new ConfigurationProperty(MainDelimiterName,
				typeof(string), null, ConfigurationPropertyOptions.None);
			ActionPositionProperty = new ConfigurationProperty(ActionPositionName,
				typeof(int), 0, ConfigurationPropertyOptions.None);
			POLPositionProperty = new ConfigurationProperty(POLPositionName,
				typeof(int), 0, ConfigurationPropertyOptions.None);
			DelimiterCollectionProperty = new ConfigurationProperty(DelimiterCollectionPropName,
				typeof(EDIDelimiterCollection), null, ConfigurationPropertyOptions.None);
			ITVUserCollectionProperty = new ConfigurationProperty(ITVUserCollectionPropName,
				typeof(ITVUserCollection), null, ConfigurationPropertyOptions.None);

			SectionProperties = new ConfigurationPropertyCollection();
			SectionProperties.Add(MessageNoProperty);
			SectionProperties.Add(MessageDscProperty);
			SectionProperties.Add(ArchiveSubFolderProperty);
			SectionProperties.Add(ErrorSubFolderProperty);
			SectionProperties.Add(ProcessSubFolderProperty);
			SectionProperties.Add(InOutProperty);
			SectionProperties.Add(SerialDelimterProperty);
			SectionProperties.Add(SerialPositionProperty);
			SectionProperties.Add(ActionDelimterProperty);
			SectionProperties.Add(POLDelimiterProperty);
			SectionProperties.Add(MainDelimiterProperty);
			SectionProperties.Add(ActionPositionProperty);
			SectionProperties.Add(POLPositionProperty);
			SectionProperties.Add(DelimiterCollectionProperty);
			SectionProperties.Add(ITVUserCollectionProperty);
		}
		#endregion		// #region Static Programmatic Implementation

		#region Declarative Implementation

		public EDIConfigurationSection()
		{
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get { return SectionProperties; }
		}

		[ConfigurationProperty(MessageNoPropName, IsRequired = false)]
		public string MessageNo
		{
			get { return base[MessageNoProperty] as string; }
			set { base[MessageNoProperty] = value; }
		}

		[ConfigurationProperty(MessageDscPropName, IsRequired = true)]
		public string MessageDsc
		{
			get { return base[MessageDscProperty] as string; }
			set { base[MessageDscProperty] = value; }
		}

		[ConfigurationProperty(ArchiveSubFolderPropName, IsRequired = true)]
		public string ArchiveSubFolder
		{
			get { return base[ArchiveSubFolderProperty] as string; }
			set { base[ArchiveSubFolderProperty] = value; }
		}

		[ConfigurationProperty(ErrorSubFolderPropName, IsRequired = true)]
		public string ErrorSubFolder
		{
			get { return base[ErrorSubFolderProperty] as string; }
			set { base[ErrorSubFolderProperty] = value; }
		}

		[ConfigurationProperty(ProcessSubFolderPropName, IsRequired = true)]
		public string ProcessSubFolder
		{
			get { return base[ProcessSubFolderProperty] as string; }
			set { base[ProcessSubFolderProperty] = value; }
		}

		[ConfigurationProperty(InOutPropName, IsRequired = true)]
		public string InOut
		{
			get { return base[InOutProperty] as string; }
			set { base[InOutProperty] = value; }
		}

		[ConfigurationProperty(SerialDelimiterName, IsRequired = true)]
		public string SerialDelimiter
		{
			get { return base[SerialDelimterProperty] as string; }
			set { base[SerialDelimterProperty] = value; }
		}

		[ConfigurationProperty(SerialPositionName, IsRequired = true)]
		public int SerialPosition
		{
			get { return (int)base[SerialPositionName]; }
			set { base[SerialPositionName] = value; }
		}

		[ConfigurationProperty(ActionDelimiterName, IsRequired = false)]
		public string ActionDelimiter
		{
			get { return base[ActionDelimterProperty] as string; }
			set { base[ActionDelimterProperty] = value; }
		}

		[ConfigurationProperty(ActionPositionName, IsRequired = false)]
		public int ActionPosition
		{
			get { return (int)base[ActionPositionName]; }
			set { base[ActionPositionName] = value; }
		}

		[ConfigurationProperty(POLDelimiterName, IsRequired = false)]
		public string POLDelimiter
		{
			get { return base[POLDelimiterProperty] as string; }
			set { base[POLDelimiterProperty] = value; }
		}

		[ConfigurationProperty(POLPositionName, IsRequired = false)]
		public int POLPosition
		{
			get { return (int)base[POLPositionName]; }
			set { base[POLPositionName] = value; }
		}


		[ConfigurationProperty(MainDelimiterName, IsRequired = false)]
		public string MainDelimiter
		{
			get { return base[MainDelimiterProperty] as string; }
			set { base[MainDelimiterProperty] = value; }
		}

		[ConfigurationProperty(MainPositionName, IsRequired = false)]
		public int MainPosition
		{
			get { return (int)base[MainPositionName]; }
			set { base[MainPositionName] = value; }
		}		  

		[ConfigurationProperty(DelimiterCollectionPropName, IsRequired = false)]
		public EDIDelimiterCollection Delimiters
		{
			get { return base[DelimiterCollectionProperty] as EDIDelimiterCollection; }
			set { base[DelimiterCollectionProperty] = value; }
		}

		[ConfigurationProperty(ITVUserCollectionPropName, IsRequired = false)]
		public ITVUserCollection ITVUsers
		{
			get { return base[ITVUserCollectionProperty] as ITVUserCollection; }
			set { base[ITVUserCollectionProperty] = value; }
		}
		#endregion		// #region Declarative Implementation
	}
	#endregion
}

