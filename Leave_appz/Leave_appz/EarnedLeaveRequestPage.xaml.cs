﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class EarnedLeaveRequestPage : ContentPage
    {
        public EarnedLeaveRequestPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backgroundImage.Source = ImageSource.FromResource("Leave_appz.Assets.background.png");

            MyEditor.Text = "Please provide the reason for your leave here !!"; //initialize the Editor.Text and TextColor on the XAML file or on the constructor on the code behind with the PlaceHolder or whatever you want.
            MyEditor.TextColor = Color.FromHex("#BFffffff");
        }

        private void MyEditor_Focused(object sender, FocusEventArgs e) //triggered when the user taps on the Editor to interact with it
        {
            if (MyEditor.Text.Equals("Please provide the reason for your leave here !!")) //if you have the placeholder showing, erase it and set the text color to black
            {
                MyEditor.Text = "";
                MyEditor.TextColor = Color.White;
            }
        }

        private void MyEditor_Unfocused(object sender, FocusEventArgs e) //triggered when the user taps "Done" or outside of the Editor to finish the editing
        {
            if (MyEditor.Text.Equals("")) //if there is text there, leave it, if the user erased everything, put the placeholder Text back and set the TextColor to gray
            {
                MyEditor.Text = "Please provide the reason for your leave here !!";
                MyEditor.TextColor = Color.FromHex("#BFffffff");
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PickerDate.Focus();
        }

        private void PickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = PickerDate.Date.Date.ToString("dd-MM-yyyy");
        }


        private void TapGestureRecognizer_Tapped_2(object senderN, EventArgs f)
        {
            PickerDateN.Focus();
        }

        private void PickerDate_DateSelectedN(object senderN, DateChangedEventArgs f)
        {
            DateLabelN.Text = PickerDateN.Date.Date.ToString("dd-MM-yyyy");
        }
    }
}