using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace Examples.Configuration.Lab {

	//TODO move to KsWare.Configuration?
	public class CaseInsensitiveEnumConfigConverter<T> : ConfigurationConverterBase {

		private static readonly Lazy<CaseInsensitiveEnumConfigConverter<T>> LazyDefault=new Lazy<CaseInsensitiveEnumConfigConverter<T>>(() => new CaseInsensitiveEnumConfigConverter<T>());
		public static TypeConverter Default => LazyDefault.Value;

		public override object ConvertFrom(
			ITypeDescriptorContext ctx, CultureInfo ci, object data) {
			return Enum.Parse(typeof(T), (string) data, true);
		}


	}

}
