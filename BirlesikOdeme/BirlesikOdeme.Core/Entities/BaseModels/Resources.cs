using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace BirlesikOdeme.Core.Entities.BaseModels;
    public class Resources
    {
        public int Id { get; set; }
        public string SourceKey { get; set; }
        public int LanguageId { get; set; }
        public string SourceValue { get; set; }

    }
 
