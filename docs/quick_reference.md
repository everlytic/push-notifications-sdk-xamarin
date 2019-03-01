All methods are accessible on the `EverlyticPush.EverlyticPush.Current` object. The object namespace and/or naming are subject to change.

## Available Methods

```c#
void Initialize()
```
Initializes the SDK in the application. Must be called before any other SDK Methods are called.
****
```c#
void Subscribe(string email);
void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegate);
```
Subscribes a contact using an email address. Accepts optional subscribe success callback.
****
```c#
void Unsubscribe();
void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegate);
```
Unsubscribes the currently subscribed contact from receiving push notifications. Accepts optional unsubscribe success callback.
****
```c#
bool IsContactSubscribed();
```
Returns `true` if a contact is currently subscribed.
****
```c#
bool IsInitialized();
```
Returns `true` if the SDK has been initialized.
****
```c#
void GetNotificationHistory(OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegate);
```
Asynchronously retrieves the notification history for the device and returns the results to an `OnNotificationHistoryResults` delegate

## Android Set Up

Add the following to your `AndroidManifest.xml` file inside the `<application>` tag. Replace values in `{}` with your appropriate values.

```xml
<application>
  <meta-data android:name="com.everlytic.api.API_USERNAME" android:value="{api_username}"></meta-data>
  <meta-data android:name="com.everlytic.api.API_KEY" android:value="{api_key}"></meta-data>
  <meta-data android:name="com.everlytic.api.PUSH_NOTIFICATIONS_LIST_ID" android:value="{list_id}"></meta-data>
  <meta-data android:name="com.everlytic.api.API_INSTALL_URL" android:value="{install_url}"></meta-data>
</application>
```

Change the default icon by adding a new drawable called `ic_ev_notification_small`
Notification color is derived from the `styles.xml` `colorPrimary` value

## Known Issues

- The app may crash if there is a network connection issue, E.g. Everlytic domain cannot be resolved
- `Unsubscribe()` may cause an app crash