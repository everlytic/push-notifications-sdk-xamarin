- [Quick Reference](/push-notifications-sdk-xamarin/quick_reference.html)
- [Change Log](/push-notifications-sdk-xamarin/changelog.html)
- [Test Scripts](/push-notifications-sdk-xamarin/test_script.html)

## Notes

- iOS is currently not implemented. Called methods will throw `NotImplementedException` when run on an iOS device.
- A Test mode is provided during the alpha phase. This mocks HTTP requests to the Everlytic API for basic testing.

## Getting Started

Add the following to your `AndroidManifest.xml` file, replacing `{}` fields with the appropriate values.

- `{api_username}` - Everlytic username for the API user
- `{api_key}` - API key for the API user
- `{list_id}` - Push Notification list ID the app will subscribe to
- `{install_url}` - URL to your Everlytic install

```xml
<application>
  <meta-data android:name="com.everlytic.api.API_USERNAME" android:value="{api_username}"></meta-data>
  <meta-data android:name="com.everlytic.api.API_KEY" android:value="{api_key}"></meta-data>
  <meta-data android:name="com.everlytic.api.PUSH_NOTIFICATIONS_LIST_ID" android:value="{list_id}"></meta-data>
  <meta-data android:name="com.everlytic.api.API_INSTALL_URL" android:value="{install_url}"></meta-data>
</application>
```

Initialize the SDK in your top level Application class

### Xamarin.Forms

```c#

public class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
        
        // Initialize the Everlytic SDK
        EverlyticPush.EverlyticPush.Current.Initialize();
        
        // Initialize the Everlytic SDK with Testing mode enabled
        EverlyticPush.EverlyticPush.Current
            .SetTestMode(true)
            .Initialize();
    }
}

```

### Android

```c#
[Application]
public class App : Application
{
    public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();

        // Initialize the Everlytic SDK
        EverlyticPush.EverlyticPush.Current.Initialize();
            
        // Initialize the Everlytic SDK with Testing mode enabled
        EverlyticPush.EverlyticPush.Current
            .SetTestMode(true)
            .Initialize();
    }
}
```
***
## Using the SDK
### Subscribing a Contact

```c#
public void SubscribeContact(string email) 
{
    // If you don't require a success or fail result
    EverlyticPush.EverlyticPush.Current.Subscribe(email);
    
    // If you want to get the success or failure result of the subscription call
    EverlyticPush.EverlyticPush.Current.Subscribe(email, result => 
    {
        // Handle the result. Note this does not return on the main thread
    });
}
```

### Unsubscribing a Contact

```c#
public void UnsubscribeContact() 
{
    // If you don't require a success or fail result. 
    // Unsubscribes the current contact
    EverlyticPush.EverlyticPush.Current.Unsubscribe();
    
    // If you want to get the success or failure result of the subscription call
    EverlyticPush.EverlyticPush.Current.Unsubscribe(result => 
    {
        // Handle the result. Note this does not return on the main thread
    });
}
```

### Retrieve the Notification History

```c#
public void UnsubscribeContact() 
{   
    EverlyticPush.EverlyticPush.Current.GetNotificationHistory(resultSet => 
    {
        // Handle the result set
    });
}
```

### Basic Customization

- Change the default icon by adding a `ic_ev_notification_small` drawable
- Change the default color by updating the `styles.xml` `colorPrimary` property 