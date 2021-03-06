﻿using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ANAConversationStudio.Models
{
    public class BaseIdEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string __id;
        [DisplayName("Id")]
        [ReadOnly(true)]
        public string _id
        {
            get { return __id; }
            set
            {
                if (__id != value)
                {
                    __id = value;
                    OnPropertyChanged();
                }
            }
        }
    }
    public class BaseEntity : BaseIdEntity
    {
        private string _Alias;
        [JsonIgnore]
        public string Alias
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_Alias))
                    FillAlias();
                return _Alias;
            }
            set
            {
                if (_Alias != value)
                {
                    _Alias = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void FillAlias() { }
        public override string ToString()
        {
            return Alias;
        }
    }

    public class RepeatableBaseEntity : BaseEntity
    {
        #region For Repeat Items

        private bool _DoesRepeat;

        public bool DoesRepeat
        {
            get { return _DoesRepeat; }
            set
            {
                if (_DoesRepeat != value)
                {
                    _DoesRepeat = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _RepeatOn;

        public string RepeatOn
        {
            get { return _RepeatOn; }
            set
            {
                if (_RepeatOn != value)
                {
                    _RepeatOn = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _RepeatAs;

        public string RepeatAs
        {
            get { return _RepeatAs; }
            set
            {
                if (_RepeatAs != value)
                {
                    _RepeatAs = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _StartPosition;

        public int StartPosition
        {
            get { return _StartPosition; }
            set
            {
                if (_StartPosition != value)
                {
                    _StartPosition = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _MaxRepeats;

        public int MaxRepeats
        {
            get { return _MaxRepeats; }
            set
            {
                if (_MaxRepeats != value)
                {
                    _MaxRepeats = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}