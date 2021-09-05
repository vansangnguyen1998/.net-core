using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class Constants
    {
        public const string INSERT_BOOK = "1";
        public const string UPDATE_BOOK = "2";
        public const string REMOVE_BOOK = "3";
        public const string SWITCH_MODE_BOOK = "4";
        public const string STOP_APPLICATION = "0";
        public static readonly List<string> MODE = new List<string>() { "TXT", "JSON" };
    }
}
