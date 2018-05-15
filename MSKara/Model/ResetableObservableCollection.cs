using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
namespace MSKara.Model
{
	public class ResetableObservableCollection<T> : ObservableCollection<T>
	{
		public ResetableObservableCollection() : base()
		{

		}

		public ResetableObservableCollection(IEnumerable<T> collection)
        : base(collection) {
		}

		public ResetableObservableCollection(List<T> list)
        : base(list) {
		}
		public void AddRange(IEnumerable<T> range)
		{
			foreach (var item in range)
			{
				Items.Add(item);
			}

			this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void Reset(IEnumerable<T> range)
		{
			Items.Clear();

			AddRange(range);
		}
	}
}
