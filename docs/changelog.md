# Change Log

## `0.0.4-alpha`
- Android 
    - Custom Actions and Parameters
    - Open URL on notification
    - Open app with custom parameters
        - Fix message ID in notification events
        - Restore unactioned notifications on boot
        - Simplify SDK Configuration setup

## `0.0.3-alpha`
- Renamed root namespace to `Com.EverlyticPush`
- Renamed static instance class to `Everlytic.Instance`
- Update to Android SDK `0.0.3-alpha`
  - Fix crash when retrieving the notification history
  - Clear the notification history on contact unsubscribe

## `0.0.2-alpha`

- Updated versioning scheme to follow NuGet conventions
- Android
  - Track notification cancel/dismissal events
  - Resubscribe on new FCM token received
  - Resolve fatal crash if HTTP request fails 
  - Compile for API level 27
  - Add Testing mode that mocks HTTP requests for subscribe, unsubscribe and event uploads

## `0.0.1-alpha01`

- Initial alpha release for Android