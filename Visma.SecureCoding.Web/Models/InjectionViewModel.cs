using System.ComponentModel.DataAnnotations;

namespace Visma.SecureCoding.Web.Models
{
    public class InjectionViewModel
    {
        [Display(Name="Connection string", ShortName="Connection", Description="The connection string to the Microsoft SQL server")]
        public string ConnectionString { get; set; }

        [Display(Name="Initialize database statement", ShortName="Statement", Description="SQL statement which initialize the database")]
        public string InitializeDatabaseStatement { get; set; }

        [Display(Name="Account collection filter", ShortName="Filter", Description="The account collection filter")]
        public string AccountFilterWithSqlInjection { get; set; }

        [Display(Name="Last query result", ShortName="Result", Description="The result of the last query")]
        public string LastQueryResult { get; set; }
    }
}