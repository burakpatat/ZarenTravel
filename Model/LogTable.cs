using System;
using Dapper.Contrib.Extensions;
using Core.Interfaces;

namespace Model.Concrete
{
    [Table("Logs")]
    public class LogTable : IEntity
    {
        private int _ID;
        [Key]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private int _Type;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private string _LogPath;
        public string LogPath
        {
            get { return _LogPath; }
            set { _LogPath = value; }
        }
        private string _LogMethod;
        public string LogMethod
        {
            get { return _LogMethod; }
            set { _LogMethod = value; }
        }
        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _UserAgent;
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        private string _UserHostAddress;
        public string UserHostAddress
        {
            get { return _UserHostAddress; }
            set { _UserHostAddress = value; }
        }
        private string _UrlOriginalString;
        public string UrlOriginalString
        {
            get { return _UrlOriginalString; }
            set { _UrlOriginalString = value; }
        }
    }
}
