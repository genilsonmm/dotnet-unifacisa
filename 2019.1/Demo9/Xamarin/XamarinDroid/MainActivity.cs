using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using CodeShare;

namespace XamarinDroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView tvMessage;
        private Button btnMessage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Increment increment = new Increment();

            tvMessage = FindViewById<TextView>(Resource.Id.tvMessage);
            btnMessage = FindViewById<Button>(Resource.Id.btnMessage);

            btnMessage.Click += delegate
            {
                tvMessage.Text = $"Andorid Xamarin {increment.GetNext()}";
            };
        }
    }
}