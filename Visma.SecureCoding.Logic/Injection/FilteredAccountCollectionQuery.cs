using System;
using Visma.SecureCoding.Logic.Contracts.Injection;

namespace Visma.SecureCoding.Logic.Injection
{
    public class FilteredAccountCollectionQuery : SqlQueryBase, IFilteredAccountCollectionQuery
    {
        #region Constructors

        public FilteredAccountCollectionQuery(string connectionString, string filter)
            : base(connectionString)
        {
            if (string.IsNullOrWhiteSpace(filter)) throw new ArgumentNullException(nameof(filter));

            Filter = filter;
        }

        #endregion

        #region Properties

        public string Filter { get; private set; }

        #endregion
    }
}