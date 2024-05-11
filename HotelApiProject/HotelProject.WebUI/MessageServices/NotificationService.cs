
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Newtonsoft.Json;

    namespace HotelProject.WebUI.MessageServices
    {
        public class NotificationService : INotificationService
        {
            private readonly string _notificationKey = "temp-notify-list";
            private readonly IHttpContextAccessor _contextAccessor;
            private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
            private ITempDataDictionary TempData => _tempDataDictionaryFactory.GetTempData(_contextAccessor.HttpContext);
            public NotificationService(ITempDataDictionaryFactory tempDataDictionaryFactory, IHttpContextAccessor contextAccessor)
            {
                _tempDataDictionaryFactory = tempDataDictionaryFactory;
                _contextAccessor = contextAccessor;
            }




            public virtual IList<NotifyData> GetNotifies()
            {
                return TempData.ContainsKey(_notificationKey)
                    ? JsonConvert.DeserializeObject<IList<NotifyData>>(TempData[_notificationKey].ToString() ?? string.Empty)
                    : new List<NotifyData>();
            }

            protected virtual void PrepareTempData(NotifyType type, string message, bool encode = true)
            {
                var notifies = GetNotifies();
                notifies.Add(new NotifyData { Type = type, Message = message, Encode = encode });

                TempData[_notificationKey] = JsonConvert.SerializeObject(notifies);
            }

            public void Notification(NotifyType type, string message, bool encode = true)
            {
                PrepareTempData(type, message, encode);
            }

            public void SuccessNotification(string message, bool encode = true)
            {
                PrepareTempData(NotifyType.Success, message, encode);
            }

            public void WarningNotification(string message, bool encode = true)
            {
                PrepareTempData(NotifyType.Warning, message, encode);
            }
            public void ErrorNotification(string message, bool encode = true)
            {
                PrepareTempData(NotifyType.Error, message, encode);
            }
            public void ErrorNotification(Exception exception)
            {
                if (exception != null)
                    return;
                ErrorNotification(exception.Message);
            }

        }
    }
