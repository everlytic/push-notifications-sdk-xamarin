﻿using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Util;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Com.EverlyticPush;

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
            FindViewById<Button>(Resource.Id.btn_unsubscribe).Click += OnUnsubscribeClicked;
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
                .SetPositiveButton("Subscribe", (a, b) =>
                {
                    Everlytic.Instance.Subscribe(et.Text, result =>
                    {
                        try
                        {
                            RunOnUiThread(() =>
                            {
                                if (result.IsSuccessful)
                                {
                                    new AlertDialog.Builder(this)
                                        .SetTitle("Success")
                                        .SetMessage("Subscription was successful")
                                        .Show();
                                }
                                else
                                    new AlertDialog.Builder(this)
                                        .SetTitle("Failed")
                                        .SetMessage(result.Exception?.Message ?? "An unknown exception occurred")
                                        .Show();
                            });
                        }
                        catch (Exception e)
                        {
                            Log.Warn("SubscribeFail", e.Message, e);
                        }
                    });
                })
                .Show();
        }

        private void OnUnsubscribeClicked(object sender, EventArgs eventArgs)
        {
            new AlertDialog.Builder(this)
                .SetTitle("Unsubscribe")
                .SetMessage("Unsubscribe the current contact?")
                .SetPositiveButton("Unsubscribe",
                    (o, args) =>
                    {
                        Everlytic.Instance.Unsubscribe(result =>
                        {
                            RunOnUiThread(() =>
                            {
                                if (result.IsSuccessful)
                                {
                                    Toast.MakeText(this, "success", ToastLength.Long).Show();
                                }
                                else
                                {
                                    Toast.MakeText(this, result.Exception?.Message ?? "Unknown error", ToastLength.Long)
                                        .Show();
                                }
                            });
                        });
                    })
                .Show();
        }
    }
}