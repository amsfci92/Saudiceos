using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Notification
{
    public class Notification
    {
        public int NotificationId { get; set; } 
        public String Title { get; set; } 
        public string Message { get; set; }
        public string Link { get; set; }
        public int Type { get; set; }
        public int TypeId { get; set; }
        public string Icon { get; set; } 
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
