using Android.App;
using Android.Widget;
using Android.OS;
using System;
using SALLab12;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView MessageText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var listColors = FindViewById<ListView>(Resource.Id.listView1);
            MessageText = FindViewById<TextView>(Resource.Id.MessageText);

            listColors.Adapter = new CustomAdapters.ColorAdapter(
                this, Resource.Layout.ListItem, Resource.Id.textView1, 
                Resource.Id.textView2, Resource.Id.imageView1);

            Validate();
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            var studentEmail = "jzuluaga55@gmail.com";
            var password = "XXX";
            var myDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, 
                Android.Provider.Settings.Secure.AndroidId);
            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);
            MessageText.Text = $"{result.Status}\n{result.FullName}\n{result.Token}";
        }
    }
}

