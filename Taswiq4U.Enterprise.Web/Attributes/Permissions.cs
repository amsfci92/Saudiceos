namespace System
{
    public class Permissions
    {
        public const string CEO_ADD = "Permissions.CEO.Add"; 
        public const string CEO_Update = "Permissions.CEO.Update"; 
        public const string CEO_Delete = "Permissions.CEO.Delete";
        public const string CEO_ViewAll = "Permissions.CEO.ViewAll"; 
        public const string CEO_ViewUpdateRequests = "Permissions.CEO.UpdateRequests"; 
        public const string CEO_ViewAddRequests = "Permissions.CEO.AddRequests";
        public const string CEO_All = "Permissions.CEO.Add," +
            "Permissions.CEO.Update," +
            "Permissions.CEO.Delete," +
            "Permissions.CEO.ViewAll," +
            "Permissions.CEO.UpdateRequests," +
            "Permissions.CEO.AddRequests";

        public const string Report_ADD = "Permissions.Report.Add";
        public const string Report_Update = "Permissions.Report.Update";
        public const string Report_Delete = "Permissions.Report.Delete";
        public const string Report_ViewAll = "Permissions.Report.ViewAll";
        public const string Report_All = "Permissions.Report.Add," +
           "Permissions.Report.Update," +
           "Permissions.Report.Delete," +
           "Permissions.Report.ViewAll,";

        public const string Service_ADD = "Permissions.Service.Add";
        public const string Service_Update = "Permissions.Service.Update";
        public const string Service_Delete = "Permissions.Service.Delete";
        public const string Service_ViewAll = "Permissions.Service.ViewAll";
        public const string Service_All = "Permissions.Service.Add," +
           "Permissions.Service.Update," +
           "Permissions.Service.Delete," +
           "Permissions.Service.ViewAll,";

        public const string News_ADD = "Permissions.News.Add";
        public const string News_Update = "Permissions.News.Update";
        public const string News_Delete = "Permissions.News.Delete";
        public const string News_ViewAll = "Permissions.News.ViewAll";
        public const string News_All = "Permissions.News.Add," +
           "Permissions.News.Update," +
           "Permissions.News.Delete," +
           "Permissions.News.ViewAll,";

        public const string User_ADD = "Permissions.User.Add";
        public const string User_Update = "Permissions.User.Update";
        public const string User_Delete = "Permissions.User.Delete";
        public const string User_ViewAll = "Permissions.User.ViewAll";
        public const string User_PassReset = "Permissions.User.ResetPasword";
        public const string User_Permission = "Permissions.User.UserPermission";
        public const string User_All = "Permissions.User.Add," +
           "Permissions.User.Update," +
           "Permissions.User.Delete," +
           "Permissions.User.ViewAll," +
           "Permissions.User.UserPermission," +
           "Permissions.User.ResetPasword";

        public const string Inbox_ADD = "Permissions.Inbox.Add";
        public const string Inbox_Update = "Permissions.Inbox.Update";
        public const string Inbox_Delete = "Permissions.Inbox.Delete";
        public const string Inbox_ViewAll = "Permissions.Inbox.ViewAll";
        public const string Inbox_All = "Permissions.Inbox.Add," +
           "Permissions.Inbox.Update," +
           "Permissions.Inbox.Delete," +
           "Permissions.Inbox.ViewAll,";

        public const string Banner_ADD = "Permissions.Banner.Add";
        public const string Banner_Update = "Permissions.Banner.Update";
        public const string Banner_Delete = "Permissions.Banner.Delete";
        public const string Banner_ViewAll = "Permissions.Banner.ViewAll";
        public const string Banner_All = "Permissions.Banner.Add," +
           "Permissions.Banner.Update," +
           "Permissions.Banner.Delete," +
           "Permissions.Banner.ViewAll,";

        public const string Settings_ADD = "Permissions.Settings.Add";
        public const string Settings_Update = "Permissions.Settings.Update";
        public const string Settings_Delete = "Permissions.Settings.Delete";
        public const string Settings_ViewAll = "Permissions.Settings.ViewAll";
        public const string Settings_All = "Permissions.Settings.Add," +
           "Permissions.Settings.Update," +
           "Permissions.Settings.Delete," +
           "Permissions.Settings.ViewAll,";

        public const string Dashboard_ADD = "Permissions.Dashboard.Add";
        public const string Dashboard_Update = "Permissions.Dashboard.Update";
        public const string Dashboard_Delete = "Permissions.Dashboard.Delete";
        public const string Dashboard_ViewAll = "Permissions.Dashboard.ViewAll";
        public const string Dashboard_All = "Permissions.Dashboard.Add," +
           "Permissions.Dashboard.Update," +
           "Permissions.Dashboard.Delete," +
           "Permissions.Dashboard.ViewAll,";
    }
}