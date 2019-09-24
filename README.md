# KsWare.Configuration
Extentend System.Configuration classes. property registration (w/o attributes), IList&lt;T>/IDictionary&lt;string,T> support.

- [ConfigurationElement](#ConfigurationElement)
- [ConfigurationElementCollection&lt;Tgt;](#ConfigurationElementCollection&lt;T&gt;)

## ConfigurationElement
- derives from [`System.Configuration.ConfigurationElement`](https://docs.microsoft.com/en-US/dotnet/api/system.configuration.configurationelement)
- added [property registration](#Property-registration)

## ConfigurationElementCollection&lt;T&gt;
- derives from [`System.Configuration.ConfigurationElementCollection`](https://docs.microsoft.com/en-US/dotnet/api/system.configuration.configurationelementcollection)
- added [property registration](#Property-registration)
- implements `IList&lt;T&gt;`
- implements `IDictionary&lt;string,T&gt;`

Differences to [System.ConfigurationElementCollection](https://docs.microsoft.com/de-de/dotnet/api/system.configuration.configurationelementcollection):
- `public T this[string name]` instead of `protected internal object this[string propertyName]`
- `public IEnumerator<T> GetEnumerator()` instead of `public IEnumerator GetEnumerator()`

## Property registration
Properties can be configurated like [dependency](https://docs.microsoft.com/de-de/dotnet/framework/wpf/advanced/how-to-implement-a-dependency-property) or attached properties.

```csharp
private static readonly ConfigurationProperty StringValueProperty = Register("stringValue",
	typeof(string),
	typeof(ExampleSection),
	null, ConfigurationPropertyOptions.IsRequired);

public string StringValue {
	get => (string) base[StringValueProperty];
	set => base[StringValueProperty]=value;
}

```
same with Attribute syntax
```csharp
[ConfigurationProperty("stringValue", IsRequired = true)]
public string StringValue {
	get => (string) base["stringValue"];
	set => base["stringValue"]=value;
}
```