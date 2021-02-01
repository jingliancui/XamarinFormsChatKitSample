using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleApp.Controls;
using SampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MessagesListControl), typeof(MessagesListControlRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class MessagesListControlRenderer:ViewRenderer<MessagesListControl, LinearLayout>
    {
        public MessagesListControlRenderer(Context context) : base(context)
        {

        }

        private LinearLayout linearLayout;

        private Com.Stfalcon.Chatkit.Messages.MessagesList messagesList;

        private Com.Stfalcon.Chatkit.Messages.MessagesListAdapter messagesListAdapter;
        protected override void OnElementChanged(ElementChangedEventArgs<MessagesListControl> e)
        {
            var x = Inflate(Context, Resource.Layout.MessagesListLayout, null);

            if (linearLayout == null)
            {
                linearLayout = x as LinearLayout;
            }

            if (messagesList == null)
            {
                var messagesListView = linearLayout.FindViewById<Com.Stfalcon.Chatkit.Messages.MessagesList>(Resource.Id.messagesList);
                messagesList = messagesListView;
            }

            messagesListAdapter = new Com.Stfalcon.Chatkit.Messages.MessagesListAdapter(Guid.NewGuid().ToString(), new SampleImageLoader(Context));

            messagesList.SetAdapter(messagesListAdapter);

            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);
            messagesListAdapter.AddToStart(new SampleMessage(), true);

            SetNativeControl(linearLayout);
        }
    }
}