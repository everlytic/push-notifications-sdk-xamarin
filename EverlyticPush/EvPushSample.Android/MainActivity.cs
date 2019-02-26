using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace EvPushSample.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            FindViewById<Button>(Resource.Id.btn_subscribe).Click += OnSubscribeClicked;
        }
        
        private void OnSubscribeClicked(object sender, EventArgs eventArgs)
        {
            var et = new EditText(this)
            {
                InputType = InputTypes.TextVariationEmailAddress
            };

            new AlertDialog.Builder(this)
                .SetTitle("Subscribe")
                .SetView(et)
                .SetPositiveButton("Subscribe", (a, b) => {
                    EverlyticPush.EverlyticPush.Current.Subscribe(et.Text);
                })
                .Show();
        }
    }
}