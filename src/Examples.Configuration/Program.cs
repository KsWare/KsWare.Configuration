using System;
using System.Configuration;
using Examples.Configuration.Lab;
using KsWare.Configuration;
using ConfigurationElement = KsWare.Configuration.ConfigurationElement;
using ConfigurationSection = KsWare.Configuration.ConfigurationSection;

namespace Examples.Configuration {

	class Program {

		static void Main(string[] args) {
			GetExampleSettings();
		}

		static void GetExampleSettings() {
			ExampleSection section = ConfigurationManager.GetSection("example") as ExampleSection;
			if (section != null) {
				var s = section.StringValue;
				var b = section.BooleanValue;
				var t = section.TimeSpanValue;
				var u = section.Unit;

				var nt = section.Nested.DateTimeValue;
				var ni = section.Nested.IntegerValue;

				var c = section.Things;
				var cc = c.Count;
				var c0 = c[0];
				var c0c = c0.Color;
				var c0n = c0.Name;
				var c0t = c0.Type;
			}
		}

	}

	/// <summary>
	/// An example configuration section class.
	/// </summary>
	public class ExampleSection : ConfigurationSection {

		// [ConfigurationProperty("stringValue", IsRequired = true)]
		private static readonly ConfigurationProperty StringValueProperty = Register("stringValue",
			typeof(string),
			typeof(ExampleSection),
			null, ConfigurationPropertyOptions.IsRequired);

		// [ConfigurationProperty("boolValue")]
		private static readonly ConfigurationProperty BoolValueProperty = Register("boolValue",
			typeof(bool),
			typeof(ExampleSection),
			false, ConfigurationPropertyOptions.None);

		// [ConfigurationProperty("timeSpanValue")]
		private static readonly ConfigurationProperty TimeSpanValueProperty = Register("timeSpanValue",
			typeof(TimeSpan),
			typeof(ExampleSection),
			null, ConfigurationPropertyOptions.None);

		// step 2 nested element
		// <nestedElement>
		// [ConfigurationProperty("nestedElement")]
		private static readonly ConfigurationProperty NestedElementProperty = Register("nestedElement",
			typeof(NestedElement),
			typeof(ExampleSection),
			null, ConfigurationPropertyOptions.IsRequired);

		// step 3 collection
		// <things>
		// [ConfigurationProperty("things")]
		private static readonly ConfigurationProperty ThingsProperty = Register("things",
			typeof(ExampleThingElementCollection),
			typeof(ExampleSection),
			null, ConfigurationPropertyOptions.IsRequired);

		// step 4 advanced collection
		// <things>
		// [ConfigurationProperty("things2")]
		private static readonly ConfigurationProperty Things2Property = Register("things2",
			typeof(ExampleThingElementCollectionAdv),
			typeof(ExampleSection),
			null, ConfigurationPropertyOptions.IsRequired);

		// step 5
		// case insensitive enum value
		// <unit>
		// [ConfigurationProperty("unit", DefaultValue = MeasurementUnits.None)]
		// [TypeConverter(typeof(CaseInsensitiveEnumConfigConverter<MeasurementUnits>))]
		private static readonly ConfigurationProperty UnitProperty = Register("unit",
			typeof(MeasurementUnits),
			typeof(ExampleSection),
			MeasurementUnits.None, CaseInsensitiveEnumConfigConverter<MeasurementUnits>.Default, null, ConfigurationPropertyOptions.None);

		public string StringValue {
			get => (string) base[StringValueProperty];
			set => base[StringValueProperty]=value;
		}

		public bool BooleanValue => (bool) base[BoolValueProperty];

		public TimeSpan TimeSpanValue => (TimeSpan) base[TimeSpanValueProperty];

		public NestedElement Nested => (NestedElement) base[NestedElementProperty];

		public ExampleThingElementCollection Things => (ExampleThingElementCollection) base[ThingsProperty];

		public ExampleThingElementCollection Things2 => (ExampleThingElementCollection) base[Things2Property];

		public MeasurementUnits Unit => (MeasurementUnits) this[UnitProperty];

	}

	public enum MeasurementUnits {

		None,
		Pixel,
		Inches,
		Points,
		MM,

	}

	/// <summary>
	/// An example configuration element class.
	/// </summary>
	public class NestedElement : ConfigurationElement {

		// [ConfigurationProperty("dateTimeValue", IsRequired = true)]
		private static ConfigurationProperty DateTimeValueProperty = Register("dateTimeValue",
			typeof(DateTime),
			typeof(NestedElement),
			null, ConfigurationPropertyOptions.IsRequired);

		// [ConfigurationProperty("integerValue")]
		private static ConfigurationProperty IntegerValueProperty = Register("integerValue",
			typeof(int),
			typeof(NestedElement),
			0, ConfigurationPropertyOptions.IsRequired);
	
		public DateTime DateTimeValue => (DateTime) base[DateTimeValueProperty];

		public int IntegerValue => (int) base[IntegerValueProperty];

	}

	[ConfigurationCollection(typeof(ThingElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
	public class ExampleThingElementCollection : ConfigurationElementCollection<ThingElement> {

		protected override object GetElementKey(System.Configuration.ConfigurationElement element) => (element as ThingElement).Name;

		public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.AddRemoveClearMap;

	}

	public class ThingElement : ConfigurationElement {

		// [ConfigurationProperty("name", IsRequired = true)]
		private static ConfigurationProperty NameProperty = Register("name",
			typeof(string),
			typeof(ThingElement),
			null, ConfigurationPropertyOptions.IsRequired);

		// [ConfigurationProperty("type")]
		private static ConfigurationProperty TypeProperty = Register("type",
			typeof(string),
			typeof(ThingElement),
			"Normal", ConfigurationPropertyOptions.None);

		// [ConfigurationProperty("color")]
		private static ConfigurationProperty ColorProperty = Register("color",
			typeof(string),
			typeof(ThingElement),
			"Green", ConfigurationPropertyOptions.None);

		public string Name => (string) base[NameProperty];

		public string Type => (string) base[TypeProperty];

		public string Color => (string) base[ColorProperty];

	}


	[ConfigurationCollection(typeof(ThingElement), AddItemName = "thing",
		CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ExampleThingElementCollectionAdv : ExampleThingElementCollection {

		public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

		protected override string ElementName => "thing"; //WORKAROUND AddItemNameAttribute is ignored

	}

}
