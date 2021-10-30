using Cigarette.Enterprise.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.SettingsServ
{
    public interface ISettingsService
    {
        Setting GetSettings();
        Result Update(Setting settingsModel);
    }
}
