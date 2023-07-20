using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using InternalApplication;
using Module.Abstract;

namespace INTERNAL.APPLICATION.Controllers
{
    /// <summary>
    /// Base Api for All the Controller
    /// </summary>
    /// <typeparam name="Tc">Controllers</typeparam>
    /// <typeparam name="Ts">Services</typeparam>
    public abstract class BaseApiController<Tc, Ts> : ControllerBase
    {
        #region Fields

        protected internal readonly ILogger Logger;
        protected internal readonly Ts Service;
        protected internal readonly IStringLocalizer<CommonResource> CommonResourceLocalizer;

        #endregion

        #region Contructor
        /// <summary>
        /// initialization contructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        /// <param name="commonResourceLocalizer"></param>
        protected BaseApiController(ILogger<Tc> logger, Ts service,IStringLocalizer<CommonResource> commonResourceLocalizer)
        {
            Logger = logger;
            Service = service;
            CommonResourceLocalizer = commonResourceLocalizer;
        }

        #endregion

    }
}
