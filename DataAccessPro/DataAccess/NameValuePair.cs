using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using MessagePack;

namespace DataAccess
{
    public class NameValuePair
    {
        public bool IsTable { get; set; }
        public bool IsNull { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }


        public NameValuePair()
        {
            this.IsNull = true;
            this.Name = "";
            this.Value = "";
        }


        public NameValuePair(string name, object value)
        {
            this.Name = name;
            this.IsNull = false;

            if (value == null)
            {
                this.IsNull = true;
                this.Value = "";
            }
            else if (value is DataTable)
            {
                this.IsTable = true;
                this.Value = Convert.ToBase64String(MessagePackSerializer.Serialize(value as DataTable));
            }
            else
            {
                this.Value = ConvertToString(value);
            }
        }


        private string ConvertToString(object value)
        {
            var formatEN_US = new CultureInfo("en-US");

            if (value is DateTime) return ((DateTime)value).ToString(formatEN_US);
            if (value is Decimal) return ((Decimal)value).ToString(formatEN_US);
            if (value is Double) return ((Double)value).ToString(formatEN_US);
            if (value is Int16) return ((Int16)value).ToString(formatEN_US);
            if (value is Int32) return ((Int32)value).ToString(formatEN_US);
            if (value is Int64) return ((Int64)value).ToString(formatEN_US);
            if (value is Single) return ((Single)value).ToString(formatEN_US);
            if (value is UInt16) return ((UInt16)value).ToString(formatEN_US);
            if (value is UInt32) return ((UInt32)value).ToString(formatEN_US);
            if (value is UInt64) return ((UInt64)value).ToString(formatEN_US);
            if (value is Boolean) return (bool)value ? "1" : "0";

            return value + "";
        }


        public override string ToString()
        {
            if (IsNull)
            {
                return Name + " = null";
            }
            else
            {
                return Name + " = '" + Value + "'";
            }
        }
    }
}