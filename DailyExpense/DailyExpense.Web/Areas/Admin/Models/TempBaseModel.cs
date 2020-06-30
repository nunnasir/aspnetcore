using Autofac;
using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class TempBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly ITemperatureService _temperatureService;
        public TempBaseModel(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        public TempBaseModel()
        {
            _temperatureService = Startup.AutofacContainer.Resolve<ITemperatureService>();
        }

        public void Dispose()
        {
            _temperatureService?.Dispose();
        }
    }
}
