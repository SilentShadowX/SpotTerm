    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SpotTerm.Utils
{
    class Navigation
    {
        private static readonly List<object> BackStack = new List<object>();

        private static Frame Frame;

        public static void Initialize(Frame mainFrame)
        {
            if (Frame == null)
            {
                Frame = mainFrame;
            }
        }

        public static void NavigateTo(object page)
        {
            if (Frame != null)
            {
                BackStack.Add(page);
                Frame.Content = page;
            }
        }

        public static void Back()
        {
            if (Frame != null)
            {
                if (CanGoBack())
                {
                    var last = BackStack.LastOrDefault();
                    BackStack.Remove(last);
                    var current = BackStack.LastOrDefault();
                    Frame.Content = current;
                }
            }
        }

        private static bool CanGoBack()
        {
            if (BackStack.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClearStack()
        {
            BackStack.Clear();
        }
    }
}
