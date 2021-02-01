using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Stfalcon.Chatkit.Commons;
using Com.Stfalcon.Chatkit.Commons.Models;
using Java.Util;
using SampleApp.Controls;
using SampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DialogsListControl), typeof(DialogsListControlRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class DialogsListControlRenderer: ViewRenderer<DialogsListControl, LinearLayout>
    {
        public DialogsListControlRenderer(Context context):base(context)
        {
            
        }

        private Com.Stfalcon.Chatkit.Dialogs.DialogsList dialogsList;

        private LinearLayout linearLayout;

        private Com.Stfalcon.Chatkit.Dialogs.DialogsListAdapter dialogsListAdapter;
        protected override void OnElementChanged(ElementChangedEventArgs<DialogsListControl> e)
        {
            var x = Inflate(Context, Resource.Layout.DialogsListLayout, null);

            if (linearLayout == null)
            {
                linearLayout = x as LinearLayout;
            }

            if (dialogsList==null)
            {
                var dialogsListView=linearLayout.FindViewById<Com.Stfalcon.Chatkit.Dialogs.DialogsList>(Resource.Id.dialogsList1);
                dialogsList = dialogsListView;
            }            

            dialogsListAdapter = new Com.Stfalcon.Chatkit.Dialogs.DialogsListAdapter(new SampleImageLoader(Context));

            dialogsList.SetAdapter(dialogsListAdapter);

            dialogsListAdapter.AddItem(new SampleDialog());
            dialogsListAdapter.AddItem(new SampleDialog());
            dialogsListAdapter.AddItem(new SampleDialog());
            dialogsListAdapter.AddItem(new SampleDialog());
            dialogsListAdapter.AddItem(new SampleDialog());
            dialogsListAdapter.AddItem(new SampleDialog());
            
            SetNativeControl(linearLayout);
        }
    }

    public class SampleImageLoader : Java.Lang.Object, IImageLoader
    {
        private Context context;
        public SampleImageLoader(Context mcontext)
        {
            context = mcontext;
        }

        public void LoadImage(ImageView p0, string p1, Java.Lang.Object p2)
        {
            var assets = context.Assets;

            Bitmap imageBitmap = null;

            using (var stream = assets.Open("logo.jpg"))
            {
                imageBitmap=BitmapFactory.DecodeStream(stream);
            }
            p0.SetImageBitmap(imageBitmap);
        }
    }

    public class SampleUser : Java.Lang.Object, IUser
    {
        public string Avatar => "XXX";

        public string Id => Guid.NewGuid().ToString();

        public string Name => "Speed";    
    }

    public class SampleMessage : Java.Lang.Object, IMessage
    {
        public Date CreatedAt => new Java.Util.Date();

        public string Id => Guid.NewGuid().ToString();

        public string Text => "你好哦";

        public IUser User => new SampleUser();
    }

    public class SampleDialog : Java.Lang.Object, Com.Stfalcon.Chatkit.Commons.Models.IDialog
    {
        public SampleDialog()
        {
            var user = new SampleUser();
            var iuser = user as IUser;
            var userList = new List<IUser> { iuser };
            Users = userList;

            LastMessage = new SampleMessage();
        }

        public string DialogName => "Client Session";

        public string DialogPhoto => "";

        public string Id => Guid.NewGuid().ToString();

        public Java.Lang.Object LastMessage { get; set; }

        public int UnreadCount => 88;

        public IList<IUser> Users { get; set; }

        
    }    


}