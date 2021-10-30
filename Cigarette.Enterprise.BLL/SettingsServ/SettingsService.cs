using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;

namespace Cigarette.Enterprise.BLL.SettingsServ
{
    public class SettingsService : ISettingsService
    {
        #region Fields
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor
        public SettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public Setting GetSettings()
        {
            var settings = _unitOfWork.Settings.GetAll().FirstOrDefault();
             
            return settings;
        }

        public Result Update(Setting settingsModel)
        {
            var result = _unitOfWork.Settings.Update(settingsModel);

            return new Result
            {
                Succeeded = result > 0
            };
        }
         

        #endregion

    }
}
