- [SDK Reference](./quick_reference.html)
- [Everlytic Push List Setup](./list_setup.html)
- [Change Log](./changelog.html)
- [Test Scripts](./test_script.html)

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

using Com.EverlyticPush;

public class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
        
        // Initialize the Everlytic SDK
        Everlytic.Instance.Initialize();
        
        // Initialize the Everlytic SDK with Testing mode enabled
        Everlytic.Instance
            .SetTestMode(true)
            .Initialize();
    }
}

```

### Android

```c#

using Com.EverlyticPush;

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
        Everlytic.Instance.Initialize();
            
        // Initialize the Everlytic SDK with Testing mode enabled
        Everlytic.Instance
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
    Everlytic.Instance.Subscribe(email);
    
    // If you want to get the success or failure result of the subscription call
    Everlytic.Instance.Subscribe(email, result => 
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
    Everlytic.Instance.Unsubscribe();
    
    // If you want to get the success or failure result of the subscription call
    Everlytic.Instance.Unsubscribe(result => 
    {
        // Handle the result. Note this does not return on the main thread
    });
}
```

### Retrieve the Notification History

```c#
public void GetNotificationHistory() 
{   
    Everlytic.Instance.GetNotificationHistory(resultSet => 
    {
        // Handle the result set
    });
}
```

### Basic Customization

- Change the default icon by adding a `ic_ev_notification_small` drawable
- Change the default color by updating the `styles.xml` `colorPrimary` property 