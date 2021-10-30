//using Firebase.Database;
//using Firebase.Database.Query;
//using FirebaseAdmin;
//using FirebaseAdmin.Auth;
//using FirebaseAdmin.Messaging;
//using Google.Apis.Auth.OAuth2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.NotificationManager
{
    public class NotificationManagemer
    {
        //private readonly FirebaseMessaging messaging;
        //private readonly FirebaseAuth auth;

        //private readonly FirebaseMessagingException ex;
        //private readonly ICredential credential;
        //public static void SetFirebase(string serverPath)
        //{
        //    var fullPath = Path.Combine(serverPath, "Models\\serviceAccountKey.json");
        //    var app = FirebaseApp.Create(

        //         new AppOptions()
        //         {
        //             Credential = GoogleCredential.FromFile(fullPath)
        //        .CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
        //         }, "app");
        //}

        //public NotificationManagemer(string serverPath)
        //{
        //    var app = FirebaseApp.GetInstance("app");
        //    messaging = FirebaseMessaging.GetMessaging(app);
        //    auth = FirebaseAuth.GetAuth(app);
        //    credential = GoogleCredential.FromFile(serverPath)
        //        .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");

        //    var token = credential.GetAccessTokenForRequestAsync().Result;

        //}

        //public async Task SendNotificationWeb(ViewModels.ViewModels.Notification.Notification notification, string token)
        //{
        //    var firebase = new FirebaseClient("https://Saudiceos-14d5a.firebaseio.com/");

        //    await firebase
        //   .Child($"notifications")
        //   .Child(token)
        //   .PostAsync(notification);
        //}

        //public async Task SendNotification(ViewModels.ViewModels.Notification.Notification notification, string token)
        //{
        //    try
        //    {
        //        var result = await messaging.SendAsync(new Message()
        //        {
        //            Token = credential.GetAccessTokenForRequestAsync().Result,
        //            Notification = new Notification
        //            {
        //                Title = notification.Title,
        //                Body = notification.Message
        //            },
        //            Data = new Dictionary<string, string>(){
        //                { "Link", notification.Link },
        //                { "Type", notification.Type.ToString() },
        //                { "DateCreated", notification.CreationDate.ToString() },
        //                { "TypeId", notification.TypeId.ToString() }
        //            },
        //            Android = new AndroidConfig()
        //            {
        //                TimeToLive = TimeSpan.FromHours(1),
        //                Notification = new AndroidNotification()
        //                {
        //                    Icon = "stock_ticker_update",
        //                    Color = "#f45342",
        //                },
        //            },
        //            Apns = new ApnsConfig()
        //            {
        //                Aps = new Aps()
        //                {
        //                    Badge = 42,
        //                },
        //            },
        //        });

        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
