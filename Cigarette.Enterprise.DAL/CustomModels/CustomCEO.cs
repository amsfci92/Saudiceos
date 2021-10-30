using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL
{
    public partial class CEO
    {
        public int GetCompletionPercentage()
        {
            int total = 0, step = 100 / 12;
            if (this.Company != null)
                total += step;

            if (this.Twitter != null)
                total += step;

            if (this.LinkedIn != null)
                total += step;

            if (this.ImageUrl != null)
                total += step;

            if (this.Position != null)
                total += step;

            if (this.Name != null)
                total += step;

            if (this.Email != null)
                total += step;

            if (this.CVUrl != null)
                total += step;

            if (this.CVDescription != null)
                total += step;

            if (this.CVNote != null)
                total += step;

            if (this.SnapChat != null)
                total += step;

            if (this.Location != null)
                total += step;

            return total;
        }
    }
}