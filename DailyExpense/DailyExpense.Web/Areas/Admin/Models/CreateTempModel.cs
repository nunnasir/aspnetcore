using DailyExpense.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpense.Web.Areas.Admin.Models
{
    public class CreateTempModel : TempBaseModel
    {
        public string TempValue { get; set; }
        public int Status { get; set; }

        public CreateTempModel(ITemperatureService temperatureService) : base(temperatureService) { }
        public CreateTempModel() : base() { }

        public void Create()
        {
            var temp = new Temperature
            {
                TempValue = this.TempValue,
                Status = 0
            };
            _temperatureService.CreateTemp(temp);
        }
    }
}
