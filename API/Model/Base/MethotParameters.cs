using System;
using Core.Entities;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{ 
    public class MethotParameters : IEntity
    {

        private bool _ParameterName;
        public bool ParameterName
        {
            get { return _ParameterName; }
            set { _ParameterName = value; }
        }

        private bool _ParameterMappingName;
        public bool ParameterMappingName
        {
            get { return _ParameterMappingName; }
            set { _ParameterMappingName = value; }
        }

        private string _ProcedureName;
        public string ProcedureName
        {
            get { return _ProcedureName; }
            set { _ProcedureName = value; }
        }
        private bool _IsResponse;
        public bool IsResponse
        {
            get { return _IsResponse; }
            set { _IsResponse = value; }
        }
    
        private bool _IsNullable;
        public bool IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }

        private string _ParameterValue;
        public string ParameterValue { 
            get { return _ParameterValue; }
            set { _ParameterValue = value; }
        }

        private string _DefaultValue;
        public string DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }



        private bool _IsOrderBy;
        public bool IsOrderBy
        {
            get { return _IsOrderBy; }
            set { _IsOrderBy = value; }
        }
        private bool _IsGroupBy;
        public bool IsGroupBy
        {
            get { return _IsGroupBy; }
            set { _IsGroupBy = value; }
        }
        private bool _Distinct;
        public bool Distinct
        {
            get { return _Distinct; }
            set { _Distinct = value; }
        }
    }
}
