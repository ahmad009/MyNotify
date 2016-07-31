using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNotify
{
    public class Notify
    {
        public static List<frmNotify> NotifyForms = new List<frmNotify>();

        public static void Show(string Title, string Message, Notify.NotifyType Icon)
        {
            frmNotify _frmNotify = null;
            switch (Icon)
            {
                case Notify.NotifyType.Success:
                    {
                        _frmNotify = new frmNotify(Title, Message, 0);
                        break;
                    }
                case Notify.NotifyType.Info:
                    {
                        _frmNotify = new frmNotify(Title, Message, 1);
                        break;
                    }
                case Notify.NotifyType.Warning:
                    {
                        _frmNotify = new frmNotify(Title, Message, 2);
                        break;
                    }
                case Notify.NotifyType.Error:
                    {
                        _frmNotify = new frmNotify(Title, Message, 3);
                        break;
                    }
                default:
                    {
                        _frmNotify = new frmNotify(Title, Message, 1);
                        break;
                    }
            }
            _frmNotify.Show();
            Notify.NotifyForms.Add(_frmNotify);
        }

        public enum NotifyType
        {
            Success,
            Info,
            Warning,
            Error
        }
    }
}
