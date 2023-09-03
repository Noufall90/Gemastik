using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      // Remove notifications that have already been displayer
      AndroidNotificationCenter.CancelAllNotifications();

      // Create channel first to be able to send notification
      var channel = new AndroidNotificationChannel()
      {
        Id = "channel_id",
        Name = "Default Channel",
        Importance = Importance.Default,
        Description = "Generic notifications",
      };
      // Register the channel
      AndroidNotificationCenter.RegisterNotificationChannel(channel);
      var notification = new AndroidNotification()
      {
        Title = "Malika",
        Text = "Ayo main bareng yuk",
        SmallIcon = "default",
        LargeIcon = "default",
        FireTime = System.DateTime.Now.AddSeconds(180),
      };
      // Send the notifications
      var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

      // If the script is run and a message is already scheduled, cancel it and reschedule Importance
      if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
      {
        AndroidNotificationCenter.CancelNotification(id);
        id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
