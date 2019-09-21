using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace KsWare.Configuration {

	public class ConfigurationElement : System.Configuration.ConfigurationElement {

		private static readonly Dictionary<Type, System.Configuration.ConfigurationPropertyCollection> TypeProperties =
			new Dictionary<Type, System.Configuration.ConfigurationPropertyCollection>();

		protected internal static ConfigurationProperty Register(Type declaringType, ConfigurationProperty property) {
			if (!TypeProperties.TryGetValue(declaringType, out var list)) {
				list = new System.Configuration.ConfigurationPropertyCollection();
				TypeProperties.Add(declaringType, list);
			}

			list.Add(property);
			return property;
		}

		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType) {
			return Register(declaringType, new ConfigurationProperty(name, type));
		}

		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType,
			object defaultValue) {
			return Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, null, null, ConfigurationPropertyOptions.None,
					null));
		}

		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType,
			object defaultValue, ConfigurationPropertyOptions options) {
			return Register(declaringType, new ConfigurationProperty(name, type, defaultValue, options));
		}

		protected internal static ConfigurationProperty Register(
			string name,
			Type type,
			Type declaringType,
			object defaultValue,
			TypeConverter typeConverter,
			ConfigurationValidatorBase validator,
			ConfigurationPropertyOptions options) {
			return Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, typeConverter, validator, options, null));
		}

		protected internal static ConfigurationProperty Register(
			string name,
			Type type,
			Type declaringType,
			object defaultValue,
			TypeConverter typeConverter,
			ConfigurationValidatorBase validator,
			ConfigurationPropertyOptions options,
			string description) {
			return Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, typeConverter, validator, options, description));
		}


		protected override System.Configuration.ConfigurationPropertyCollection Properties => GetProperties(this.GetType());

		internal static System.Configuration.ConfigurationPropertyCollection GetProperties(Type type) {
			var t = type;

			System.Configuration.ConfigurationPropertyCollection colex;
			if (TypeProperties.TryGetValue(t, out var colex0)) {
				if (colex0.GetType() == typeof(ConfigurationPropertyCollection)) return colex0;
				colex = new ConfigurationPropertyCollection();
				foreach (ConfigurationProperty v in colex0) colex.Add(v);
				TypeProperties[t] = colex;
			}
			else {
				colex = new ConfigurationPropertyCollection();
				TypeProperties.Add(t, colex);
			}

			t = t.BaseType;


			while (t != typeof(ConfigurationElement) && t != typeof(ConfigurationSection) &&
			       t != typeof(ConfigurationElementCollection)) {
				if (TypeProperties.TryGetValue(t, out var col)) {
					foreach (ConfigurationProperty v in col) colex.Add(v);
					if (col.GetType() == typeof(ConfigurationPropertyCollection)) break;
				}

				t = t.BaseType;
			}

			return colex;
		}

	}

}