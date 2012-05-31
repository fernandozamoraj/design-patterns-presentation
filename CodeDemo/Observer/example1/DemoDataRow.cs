using System;
using System.Collections.Generic;

namespace Observer.example1
{
    /// <summary>
    /// Implements observer design pattern
    /// </summary>
    public class DemoDataRow
    {
        protected List<IColumnChangingObserver> _changingObservers = new List<IColumnChangingObserver>();
        protected List<IColumnChangedObserver> _changedObservers = new List<IColumnChangedObserver>();
        protected List<Action<DemoDataRow, ColumnChangedArgs>> _columnDeleteObservers = new List<Action<DemoDataRow, ColumnChangedArgs>>();

        //Row values
        protected Dictionary<string, string> _values = new Dictionary<string, string>();
        protected string _rowName = "DemoDataRow";
        

        public DemoDataRow()
        {
        }


        public DemoDataRow(string rowName)
        {
            _rowName = rowName;
        }

        public void AttachColumnChangedObserver(IColumnChangedObserver columnChanged)
        {
            _changedObservers.Add(columnChanged);
        }

        public void AttachColumnChangingObserver(IColumnChangingObserver columnChanged)
        {
            _changingObservers.Add(columnChanged);
        }

        public void AttachColumnDeletedObserver(Action<DemoDataRow, ColumnChangedArgs> handler)
        {
            _columnDeleteObservers.Add(handler);
        }

        public void DetachColumnDeletedObserver(Action<DemoDataRow, ColumnChangedArgs> handler)
        {
            _columnDeleteObservers.Remove(handler);
        }

        public void ToConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Values for {0}:", _rowName);

            foreach(var key in _values.Keys)
            {
                Console.WriteLine("{0}: {1}", key, _values[key]);
            }

            Console.WriteLine();
        }

        public string this[string key]
        {
            get
            {
                if (_values.ContainsKey(key))
                    return _values[key];
                
                return string.Empty;
            }
            set
            {
                string oldValue = string.Empty;

                if (_values.ContainsKey(key))
                {
                    oldValue = _values[key];
                }

                bool cancelled = PublishChangingEvent(key, oldValue, value);

                if(!cancelled)
                {
                    if (!_values.ContainsKey(key))
                        _values.Add(key, value);
                    else
                        _values[key] = value;
                    

                    PublishChangedEvent(key, oldValue, value);
                }
            }
        }

        public void DeleteColumn(string key)
        {
            if(_values.ContainsKey(key))
            {
                string oldValue = _values[key];
                _values.Remove(key);
                PublishColumnDeletedEvents(key, oldValue);
            }
        }

        protected void PublishColumnDeletedEvents(string key, string oldValue)
        {
            foreach (var observer in _columnDeleteObservers)
            {
                observer.Invoke(this, new ColumnChangedArgs{ ColumnName = key, OldValue = oldValue});
            }
        }

        protected bool PublishChangingEvent( string columnName, string oldValue, string newValue)
        {
            bool cancelled = false;

            for(int i = 0; i < _changingObservers.Count; i++)
            {
                ColumnChangedArgs columnChangedArgs = new ColumnChangedArgs
                                                          {
                                                              CancelEvent = false,
                                                              ColumnName = columnName,
                                                              NewValue = newValue,
                                                              OldValue = oldValue
                                                          }; 
                
                _changingObservers[i].Handle(this, columnChangedArgs);

                if(columnChangedArgs.CancelEvent)
                {
                    cancelled = true;
                }
            }

            return cancelled;
        }

        protected void PublishChangedEvent(string columnName, string oldValue, string newValue)
        {
            for (int i = 0; i < _changedObservers.Count; i++)
            {
                ColumnChangedArgs columnChangedArgs = new ColumnChangedArgs
                {
                    CancelEvent = false,
                    ColumnName = columnName,
                    NewValue = newValue,
                    OldValue = oldValue
                };

                _changedObservers[i].Handle(this, columnChangedArgs);
            }

        }
    }
}
