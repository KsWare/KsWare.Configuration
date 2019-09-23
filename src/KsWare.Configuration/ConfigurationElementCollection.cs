using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using JetBrains.Annotations;

namespace KsWare.Configuration {

	public abstract class ConfigurationElementCollection : System.Configuration.ConfigurationElementCollection { }

	public abstract partial class ConfigurationElementCollection<T> : /*ConfigurationElement, */ 
		ConfigurationElementCollection
		where T : ConfigurationElement, new() {

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


		public T this[int index] {
			get => (T) base.BaseGet(index);
			set {
				if (base.BaseGet(index) != null) { base.BaseRemoveAt(index); }

				base.BaseAdd(index, value);
			}
		}

		public T this[string name] => (T) base.BaseGet(name);

		protected override System.Configuration.ConfigurationElement CreateNewElement() => new T();

		protected override System.Configuration.ConfigurationPropertyCollection Properties =>
			ConfigurationElement.GetProperties(this.GetType());

	}

}