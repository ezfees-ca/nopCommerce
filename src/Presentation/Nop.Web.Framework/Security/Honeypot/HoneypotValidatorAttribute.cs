﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Services.Logging;

namespace Nop.Web.Framework.Security.Honeypot
{
    /// <summary>
    /// Represents a filter attribute enabling honeypot validation
    /// </summary>
    public class HoneypotValidatorAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public HoneypotValidatorAttribute() : base(typeof(ValidateHoneypotFilter))
        {
        }

        #region Nested filter

        /// <summary>
        /// Represents a filter enabling honeypot validation
        /// </summary>
        private class ValidateHoneypotFilter : IAuthorizationFilter
        {
            #region Fields

            private readonly ILogger _logger;
            private readonly IWebHelper _webHelper;
            private readonly SecuritySettings _securitySettings;

            #endregion

            #region Ctor

            public ValidateHoneypotFilter(ILogger logger,
                IWebHelper webHelper,
                SecuritySettings securitySettings)
            {
                this._logger = logger;
                this._webHelper = webHelper;
                this._securitySettings = securitySettings;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="filterContext">Authorization filter context</param>
            public void OnAuthorization(AuthorizationFilterContext filterContext)
            {
                if (filterContext == null)
                    throw new ArgumentNullException("filterContext");

                //whether honeypot is enabled
                if (!_securitySettings.HoneypotEnabled)
                    return;

                //try get honeypot input value 
                var inputValue = filterContext.HttpContext.Request.Form[_securitySettings.HoneypotInputName];

                //if exists, bot is caught
                if (!StringValues.IsNullOrEmpty(inputValue))
                {
                    //warning admin about it
                    _logger.Warning("A bot detected. Honeypot.");

                    //and redirect to the original page
                    filterContext.Result = new RedirectResult(_webHelper.GetThisPageUrl(true));
                }
            }

            #endregion
        }

        #endregion
    }
}