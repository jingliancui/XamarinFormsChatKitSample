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

[assembly: ExportRenderer(typeof(MessageInputControl), typeof(MessageInputControlRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class MessageInputControlRenderer: ViewRenderer<MessageInputControl, LinearLayout>
    {
        public MessageInputControlRenderer(Context context) : base(context)
        {

        }

        private Com.Stfalcon.Chatkit.Messages.MessageInput messageInput;

        private LinearLayout linearLayout;

        protected override void OnElementChanged(ElementChangedEventArgs<MessageInputControl> e)
        {
            var x = Inflate(Context, Resource.Layout.MessageInputLayout, null);

            if (linearLayout == null)
            {
                linearLayout = x as LinearLayout;
            }

            if (messageInput == null)
            {
                var messageInputView = linearLayout.FindViewById<Com.Stfalcon.Chatkit.Messages.MessageInput>(Resource.Id.theMessageInput);
                messageInput = messageInputView;
            }            

            SetNativeControl(linearLayout);
        }
    }
}