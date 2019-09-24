using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KsWare.Configuration {

	public abstract partial class ConfigurationElementCollection<T> : IDictionary<string, T> {

		//public new IEnumerator<T> GetEnumerator() => new Enumerator(base.GetEnumerator());


		IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => new DictionaryEnumerator(this);

		void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item) {
			//TODO check key
			BaseAdd(item.Value);
		}

		bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) => BaseGet(item.Key) != null;

		void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex) {
			//TODO check array limits
			for (int i = 0; i < Count; i++) { array[i + arrayIndex] = new KeyValuePair<string, T>((string) BaseGetKey(i), (T) BaseGet(i)); }
		}

		bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item) {
			BaseRemove(item.Value);
			return BaseIsRemoved(item.Key);
		}

		bool ICollection<KeyValuePair<string, T>>.IsReadOnly => IsReadOnly();

		public bool ContainsKey(string key) => BaseGet(key) != null;

		void IDictionary<string, T>.Add(string key, T value) {
			//TODO check key
			BaseAdd(value);
		}

		public bool Remove(string key) {
			BaseRemove(key);
			return BaseIsRemoved(key);
		}

		public bool TryGetValue(string key, out T value) {
			value = (T) BaseGet(key);
			return value != null;
		}

		public ICollection<string> Keys => BaseGetAllKeys().Cast<string>().ToList();
		public ICollection<T> Values => this;

		private class DictionaryEnumerator : IEnumerator<KeyValuePair<string, T>> {

			private IEnumerator _enumerator;
			private ConfigurationElementCollection<T> _collection;

			public DictionaryEnumerator(ConfigurationElementCollection<T> collection) {
				_collection = collection;
				_enumerator = ((System.Configuration.ConfigurationElementCollection) _collection).GetEnumerator();
			}

			public void Dispose() {
				_enumerator = null;
				_collection = null;
			}

			public bool MoveNext() => _enumerator.MoveNext();

			public void Reset() => _enumerator.Reset();

			public KeyValuePair<string, T> Current =>
				new KeyValuePair<string, T>(
					(string) _collection.BaseGetKey(
						_collection.BaseIndexOf((System.Configuration.ConfigurationElement) _enumerator.Current)), (T) _enumerator.Current);

			object IEnumerator.Current => Current;

		}

	}

}
