﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoETL
{
    public interface IChoReader
    {
        event EventHandler<ChoBeginLoadEventArgs> BeginLoad;
        event EventHandler<ChoEndLoadEventArgs> EndLoad;

        event EventHandler<ChoBeforeRecordLoadEventArgs> BeforeRecordLoad;
        event EventHandler<ChoAfterRecordLoadEventArgs> AfterRecordLoad;
        event EventHandler<ChoRecordLoadErrorEventArgs> RecordLoadError;

        event EventHandler<ChoBeforeRecordFieldLoadEventArgs> BeforeRecordFieldLoad;
        event EventHandler<ChoAfterRecordFieldLoadEventArgs> AfterRecordFieldLoad;
        event EventHandler<ChoRecordFieldLoadErrorEventArgs> RecordFieldLoadError;
    }

    public class ChoBeginLoadEventArgs : EventArgs
    {
        public object Source
        {
            get;
            internal set;
        }

        public bool Stop
        {
            get;
            set;
        }
    }

    public class ChoEndLoadEventArgs : EventArgs
    {
        public object Source
        {
            get;
            internal set;
        }
    }

    public class ChoSkipUntilEventArgs : EventArgs
    {
        public long Index
        {
            get;
            internal set;
        }
        public object Source
        {
            get;
            set;
        }
        public bool Skip
        {
            get;
            set;
        }
    }

    public class ChoDoWhileEventArgs : EventArgs
    {
        public long Index
        {
            get;
            internal set;
        }
        public object Source
        {
            get;
            set;
        }
        public bool Stop
        {
            get;
            set;
        }
    }

    public class ChoBeforeRecordLoadEventArgs : EventArgs
    {
        public object Record
        {
            get;
            internal set;
        }
        public long Index
        {
            get;
            internal set;
        }
        public object Source
        {
            get;
            set;
        }
        public bool Skip
        {
            get;
            set;
        }
    }

    public class ChoBeforeRecordFieldLoadEventArgs : ChoBeforeRecordLoadEventArgs
    {
        public string PropertyName
        {
            get;
            internal set;
        }
    }

    public class ChoAfterRecordLoadEventArgs : EventArgs
    {
        public object Record
        {
            get;
            internal set;
        }
        public long Index
        {
            get;
            internal set;
        }
        public object Source
        {
            get;
            internal set;
        }
        public bool Stop
        {
            get;
            set;
        }
        public bool Skip
        {
            get;
            set;
        }
    }

    public class ChoAfterRecordFieldLoadEventArgs : ChoAfterRecordLoadEventArgs
    {
        public string PropertyName
        {
            get;
            internal set;
        }
    }

    public class ChoRecordLoadErrorEventArgs : EventArgs
    {
        public object Record
        {
            get;
            internal set;
        }
        public long Index
        {
            get;
            internal set;
        }
        public object Source
        {
            get;
            internal set;
        }
        public Exception Exception
        {
            get;
            internal set;
        }
        public bool Handled
        {
            get;
            set;
        }
    }

    public class ChoRecordFieldLoadErrorEventArgs : ChoRecordLoadErrorEventArgs
    {
        public string PropertyName
        {
            get;
            internal set;
        }
    }

    public class ChoMapColumnEventArgs : EventArgs
    {
        public int ColPos
        {
            get;
            private set;
        }
        public string ColName
        {
            get;
            private set;
        }
        public string NewColName
        {
            get;
            set;
        }
        public bool Resolved
        {
            get;
            set;
        }

        public ChoMapColumnEventArgs(int colPos, string colName)
        {
            ColPos = colPos;
            ColName = colName;
        }
    }

    public class ChoEmptyLineEventArgs : EventArgs
    {
        public long LineNo
        {
            get;
            private set;
        }
        public bool Continue
        {
            get;
            set;
        }

        public ChoEmptyLineEventArgs(long lineNo)
        {
            Continue = true;
            LineNo = lineNo;
        }
    }
}
