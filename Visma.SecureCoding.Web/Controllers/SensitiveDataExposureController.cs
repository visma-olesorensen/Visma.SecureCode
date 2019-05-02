using System;
using Microsoft.AspNetCore.Mvc;
using Visma.SecureCoding.Logic.Contracts.SensitiveDataExposure;
using Visma.SecureCoding.Logic.SensitiveDataExposure;
using Visma.SecureCoding.Web.Models;

namespace Visma.SecureCoding.Web.Controllers
{
    public class SensitiveDataExposureController : Controller
    {
        #region Private variables

        private readonly IStorePlainTextPasswordCommandHandler _storePlainTextPasswordCommandHandler;
        private readonly IStoreSecuredPasswordCommandHandler _storeSecuredPasswordCommandHandler;

        #endregion

        #region Constructor

        public SensitiveDataExposureController(IStorePlainTextPasswordCommandHandler storePlainTextPasswordCommandHandler, IStoreSecuredPasswordCommandHandler storeSecuredPasswordCommandHandler)
        {
            if (storePlainTextPasswordCommandHandler == null) throw new ArgumentNullException(nameof(storePlainTextPasswordCommandHandler));
            if (storeSecuredPasswordCommandHandler == null) throw new ArgumentNullException(nameof(storeSecuredPasswordCommandHandler));

            _storePlainTextPasswordCommandHandler = storePlainTextPasswordCommandHandler;
            _storeSecuredPasswordCommandHandler = storeSecuredPasswordCommandHandler;
        }

        #endregion
        
        #region Methods

        public IActionResult Index()
        {
            return View("Index", CreateSensitiveDataExposureViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PasswordAsPlainText(SensitiveDataExposureViewModel sensitiveDataExposureViewModel)
        {
            if (sensitiveDataExposureViewModel == null) throw new ArgumentNullException(nameof(sensitiveDataExposureViewModel));

            IStorePasswordCommand storePasswordCommand = new StorePasswordCommand(sensitiveDataExposureViewModel.Password);
            string result = _storePlainTextPasswordCommandHandler.Execute(storePasswordCommand);

            return View("Index", CreateSensitiveDataExposureViewModel(passwordResult: result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PasswordAsSecuredText(SensitiveDataExposureViewModel sensitiveDataExposureViewModel)
        {
            if (sensitiveDataExposureViewModel == null) throw new ArgumentNullException(nameof(sensitiveDataExposureViewModel));

            IStorePasswordCommand storePasswordCommand = new StorePasswordCommand(sensitiveDataExposureViewModel.Password);
            string result =_storeSecuredPasswordCommandHandler.Execute(storePasswordCommand);

            return View("Index", CreateSensitiveDataExposureViewModel(passwordResult: result));
        }

        private SensitiveDataExposureViewModel CreateSensitiveDataExposureViewModel(string password = null, string passwordResult = null)
        {
            return new SensitiveDataExposureViewModel
            {
                Password = password,
                PasswordResult = passwordResult
            };
        }

        #endregion
    }
}