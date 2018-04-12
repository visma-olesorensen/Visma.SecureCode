using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Visma.SecureCoding.Domain.Contracts;
using Visma.SecureCoding.Logic.Contracts.Injection;
using Visma.SecureCoding.Logic.Injection;
using Visma.SecureCoding.Web.Models;

namespace Visma.SecureCoding.Web.Controllers
{
    public class InjectionController : Controller
    {
        #region Private variables

        private readonly IInitializeDatabaseCommandHandler _initializeDatabaseCommandHandler;
        private readonly IAllowedSqlInjectionQueryHandler _allowedSqlInjectionQueryHandler;
        private readonly IDisallowedSqlInjectionByParametersQueryHandler _disallowedSqlInjectionByParametersQueryHandler;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public InjectionController(IInitializeDatabaseCommandHandler initializeDatabaseCommandHandler, IAllowedSqlInjectionQueryHandler allowedSqlInjectionQueryHandler, IDisallowedSqlInjectionByParametersQueryHandler disallowedSqlInjectionByParametersQueryHandler, IConfiguration configuration)
        {
            if (initializeDatabaseCommandHandler == null) throw new ArgumentNullException(nameof(initializeDatabaseCommandHandler));
            if (allowedSqlInjectionQueryHandler == null) throw new ArgumentNullException(nameof(allowedSqlInjectionQueryHandler));
            if (disallowedSqlInjectionByParametersQueryHandler == null) throw new ArgumentNullException(nameof(disallowedSqlInjectionByParametersQueryHandler));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            _initializeDatabaseCommandHandler = initializeDatabaseCommandHandler;
            _allowedSqlInjectionQueryHandler = allowedSqlInjectionQueryHandler;
            _disallowedSqlInjectionByParametersQueryHandler = disallowedSqlInjectionByParametersQueryHandler;
            _configuration = configuration;
        }

        #endregion
                
        #region Methods

        public IActionResult Index()
        {
            return View("Index", CreateDefaultInjectionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InitializeDatabase(InjectionViewModel injectionViewModel)
        {
            if (injectionViewModel == null) throw new ArgumentNullException(nameof(injectionViewModel));

            IInitializeDatabaseCommand initializeDatabaseCommand = CreateInitializeDatabaseCommand(GetConnectionString());
            _initializeDatabaseCommandHandler.Execute(initializeDatabaseCommand);

            return View("Index", CreateDefaultInjectionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeAllowedSqlInjectionQuery(InjectionViewModel injectionViewModel)
        {
            if (injectionViewModel == null) throw new ArgumentNullException(nameof(injectionViewModel));

            IFilteredAccountCollectionQuery filteredAccountCollectionQuery = new FilteredAccountCollectionQuery(GetConnectionString(), injectionViewModel.AccountFilterWithSqlInjection);
            IEnumerable<IAccount> filteredAccountCollection = _allowedSqlInjectionQueryHandler.Execute(filteredAccountCollectionQuery);

            return View("Index", CreateDefaultInjectionViewModel(filteredAccountCollection.ToText().Replace(Environment.NewLine, "<br />")));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeDisallowSqlInjectionByParametsQuery(InjectionViewModel injectionViewModel)
        {
            if (injectionViewModel == null) throw new ArgumentNullException(nameof(injectionViewModel));

            IFilteredAccountCollectionQuery filteredAccountCollectionQuery = new FilteredAccountCollectionQuery(GetConnectionString(), injectionViewModel.AccountFilterWithSqlInjection);
            IEnumerable<IAccount> filteredAccountCollection = _disallowedSqlInjectionByParametersQueryHandler.Execute(filteredAccountCollectionQuery);

            return View("Index", CreateDefaultInjectionViewModel(filteredAccountCollection.ToText().Replace(Environment.NewLine, "<br />")));
        }

        private InjectionViewModel CreateDefaultInjectionViewModel(string lastQueryResult = null)
        {
            string connectionString = GetConnectionString();
            IInitializeDatabaseCommand initializeDatabaseCommand = CreateInitializeDatabaseCommand(connectionString);

            return new InjectionViewModel
            {
                ConnectionString = connectionString,
                InitializeDatabaseStatement = initializeDatabaseCommand.Statement,
                AccountFilterWithSqlInjection = "2;UPDATE Accounts SET Salary=Salary*2 WHERE AccountId=2;",
                LastQueryResult = lastQueryResult
            };
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("Visma.SecureCoding");
        }

        private IInitializeDatabaseCommand CreateInitializeDatabaseCommand(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            return new InitializeDatabaseCommand(connectionString);
        }

        #endregion
    }
}
