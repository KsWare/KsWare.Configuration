using System;
using System.ComponentModel;
using System.Configuration;
using JetBrains.Annotations;

namespace KsWare.Configuration {

	public class ConfigurationSection : /*ConfigurationElementEx, */ System.Configuration.ConfigurationSection {

		[NotNull]
		protected internal static ConfigurationProperty Register(Type declaringType, ConfigurationProperty property) =>
			ConfigurationElement.Register(declaringType, property);

		[NotNull]
		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType) =>
			ConfigurationElement.Register(declaringType, new ConfigurationProperty(name, type));

		[NotNull]
		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType,
			object defaultValue) =>
			ConfigurationElement.Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, null, null, ConfigurationPropertyOptions.None,
					null));

		[NotNull]
		protected internal static ConfigurationProperty Register(string name, Type type,
			Type declaringType,
			object defaultValue, ConfigurationPropertyOptions options) =>
			ConfigurationElement.Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, options));

		[NotNull]
		protected internal static ConfigurationProperty Register(
			string name,
			Type type,
			Type declaringType,
			object defaultValue,
			TypeConverter typeConverter,
			ConfigurationValidatorBase validator,
			ConfigurationPropertyOptions options) =>
			ConfigurationElement.Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, typeConverter, validator, options, null));

		[NotNull]
		protected internal static ConfigurationProperty Register(
			string name,
			Type type,
			Type declaringType,
			object defaultValue,
			TypeConverter typeConverter,
			ConfigurationValidatorBase validator,
			ConfigurationPropertyOptions options,
			string description) =>
			ConfigurationElement.Register(declaringType,
				new ConfigurationProperty(name, type, defaultValue, typeConverter, validator, options, description));

		protected override System.Configuration.ConfigurationPropertyCollection Properties =>
			ConfigurationElement.GetProperties(this.GetType());

	}

}