using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Windows;

namespace WpfApplication1.message
{
    public class MessageViewModel : MetroWindow
    {

        public MessageViewModel() {
           // string message = "";
           // string caption = "";
        
        }
        public string Message { get; set; }
        public string Caption { get; set; }

        public  void mensajeria()
        {
            try
            {
               // await this.ShowMessageAsync(Caption, Message);
                MessageBox.Show(Message, Caption);
            }
            catch (Exception e)
            {
                ToStringAllExceptionDetails(e);
                
                
            }
        }

        public static void WriteExceptionDetails(Exception exception, StringBuilder builderToFill, int level)
        {
            var indent = new string(' ', level);

            if (level > 0)
            {
                builderToFill.AppendLine(indent + "=== INNER EXCEPTION ===");
            }

            Action<string> append = (prop) =>
            {
                var propInfo = exception.GetType().GetProperty(prop);
                var val = propInfo != null ? propInfo.GetValue(exception, null) : null;

                if (val != null)
                {
                    builderToFill.AppendFormat("{0}{1}: {2}{3}", indent, prop, val.ToString(), Environment.NewLine);
                }
            };

            append("Message");
            append("HResult");
            append("HelpLink");
            append("Source");
            append("StackTrace");
            append("TargetSite");

            foreach (DictionaryEntry de in exception.Data)
            {
                builderToFill.AppendFormat("{0} {1} = {2}{3}", indent, de.Key, de.Value, Environment.NewLine);
            }

            if (exception.InnerException != null)
            {
                WriteExceptionDetails(exception.InnerException, builderToFill, ++level);
            }
        }

        public  string ToStringAllExceptionDetails(Exception exception)
        {
            StringBuilder builderToFill = new StringBuilder();
            WriteExceptionDetails(exception, builderToFill, 0);
            return builderToFill.ToString();
        }
    }
}
