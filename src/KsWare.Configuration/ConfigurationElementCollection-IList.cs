using System;
using System.Collections;
using System.Collections.Generic;

namespace KsWare.Configuration {

	public abstract partial class ConfigurationElementCollection<T> : IList<T> {

		public new IEnumerator<T> GetEnumerator() => new ListEnumerator(base.GetEnumerator());

		public void Add(T item) => BaseAdd(item);

		public void Clear() => BaseClear();

		public bool Contains(T item) => BaseIndexOf(item) >= 0;

		public void CopyTo(T[] array, int arrayIndex) {
			//TODO check array limits
			for (int i = 0; i < Count; i++) { array[i + arrayIndex] = (T) BaseGet(i); }
		}

		public bool Remove(T item) {
			var key = GetElementKey(item);
			BaseRemove(key);
			return BaseIsRemoved(key);
		}

		bool ICollection<T>.IsReadOnly => base.IsReadOnly();

		public int IndexOf(T item) => BaseIndexOf(item);


		void IList<T>.Insert(int index, T item) {
			throw new NotSupportedException("Insert is not supported at this collection type!");
		}

		public void RemoveAt(int index) => BaseRemoveAt(index);


		private class ListEnumerator : IEnumerator<T> {

			private IEnumerator _enumerator;

			public ListEnumerator(IEnumerator enumerator) {
				_enumerator = enumerator;
			}

			public void Dispose() {
				_enumerator = null;
			}

			public bool MoveNext() => _enumerator.MoveNext();

			public void Reset() => _enumerator.Reset();

			public T Current => (T) _enumerator.Current;

			object IEnumerator.Current => Current;

		}

	}

}
