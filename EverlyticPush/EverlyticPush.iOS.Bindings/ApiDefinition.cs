using System;

using Foundation;
using UIKit;
using UserNotifications;

namespace Com.EverlyticPush.iOS
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //

    delegate void EVESubscribeCallback(bool isSuccessful, NSError error);
    delegate void EVEUnsubscribeCallback(bool isSuccessful, NSError error);
    delegate void EVENotificationHistoryCallback(NSArray notifications);
    delegate void EVEPermissionPromptCallback(bool granted);

    [BaseType(typeof(NSObject))]
    interface EverlyticPush
    {
        [Static]
        [Export("initWithPushConfig:")]
        IntPtr InitializeWithPushConfig(string configString);

        [Static]
        [Export("promptForNotificationPermissionWithUserResponse:")]
        void PromptForNotificationPermissionWithUserResponse(EVEPermissionPromptCallback callback);

        [Static]
        [Export("subscribeUserWithEmail:completionHandler:")]
        void SubscribeUserWithEmail(string email, EVESubscribeCallback callback);

        [Static]
        [Export("subscribeUserWithUniqueId:emailAddress:completionHandler:")]
        void SubscribeUserWithUniqueIdAndEmail(string uniqueId, String email, EVESubscribeCallback callback);

        [Static]
        [Export("unsubscribeUserWithCompletionHandler:")]
        void UnsubscribeUserWithCompletionHandler(EVEUnsubscribeCallback callback);

        [Static]
        [Export("notificationHistoryWithCompletionListener:")]
        void NotificationHistoryWithCompletionListener(EVENotificationHistoryCallback callback);

        [Static]
        [Export("notificationHistoryCount")]
        IntPtr NotificationHistoryCount();
    }

    [BaseType(typeof(NSObject))]
    public interface EverlyticNotificationServiceExtensionHandler
    {
        [Static]
        [Export("didReceiveNotificationRequest:withMutableNotificationContent:")]
        void DidReceiveNotificationRequestWithMutableNotificationContent(UNNotificationRequest request, UNMutableNotificationContent mutableContent);

        [Static]
        [Export("serviceExtensionTimeWillExpireWithRequest:withMutableNotificationContent:")]
        void ServiceExtensionTimeWillExpireWithRequestWithMutableNotificationContent(UNNotificationRequest request, UNMutableNotificationContent mutableContent);
    }

    [BaseType(typeof(NSObject))]
    public interface EverlyticNotification
    {
        [Export("messageId")]
        NSNumber MessageId { get; set; }

        [Export("title")]
        NSString Title { get; set; }

        [Export("body")]
        NSString Body { get; set; }

        [Export("receivedAt")]
        NSDate ReceivedAt { get; set; }

        [Export("readAt")]
        NSDate ReadAt { get; set; }

        [Export("dismissedAt")]
        NSDate DismissedAt { get; set; }

        [Export("customAttributes")]
        NSDictionary<NSString, NSString> CustomAttributes { get; set; }
    }

}

