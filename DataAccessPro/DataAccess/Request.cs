using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataAccess
{
    public class Request
    {
        public Guid Id { get; set; }
        public Dictionary<string, NameValueCollection> Sections { get; private set; }


        public Request()
        {
            this.Id = Guid.NewGuid();
            this.Sections = new Dictionary<string, NameValueCollection>();
        }


        public NameValueCollection this[string section]
        {
            get
            {
                NameValueCollection result;

                if (Sections.TryGetValue(section, out result) == false)
                {
                    result = new NameValueCollection();
                    Sections.Add(section, result);
                }

                return result;
            }
        }


        public override string ToString()
        {
            return DebugViewString();
        }


        public string DebugViewString()
        {
            var sb = new StringBuilder();

            var database = this["Attributes"]["Category"].Value;
            var procedure = this["Attributes"]["Command"].Value;
            var parameters = this["Parameters"];

            sb.Append("Exec ");
            sb.Append(database);
            sb.Append("..");
            sb.Append(procedure);

            var first = true;

            foreach (var parameter in parameters)
            {
                var name = parameter.Name;
                var value = parameter.Value;

                if (value.Length > 1000)
                    value = value.Substring(0, 1000) + "...";

                value = value.Replace("'", "''");

                if (first)
                    sb.Append(" ");
                else
                    sb.Append(", ");

                sb.Append("@");
                sb.Append(name);
                sb.Append("='");
                sb.Append(value);
                sb.Append("'");

                first = false;
            }

            //if (string.IsNullOrEmpty(Globals.SessionID) == false)
            //{
            //    if (first)
            //        sb.Append(" ");
            //    else
            //        sb.Append(", ");

            //    sb.Append("@SessionID='" + Globals.SessionID + "'");
            //    first = false;
            //}

            return sb.ToString();
        }
    }
}