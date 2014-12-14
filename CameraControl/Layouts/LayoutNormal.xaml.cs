﻿#region Licence

// Distributed under MIT License
// ===========================================================
// 
// digiCamControl - DSLR camera remote control open source software
// Copyright (C) 2014 Duka Istvan
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY,FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH 
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using CameraControl.Classes;
using CameraControl.Core;
using CameraControl.Core.Classes;
using Microsoft.VisualBasic.FileIO;
using Xceed.Wpf.Toolkit.Core.Input;
using Clipboard = System.Windows.Clipboard;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

#endregion

namespace CameraControl.Layouts
{
    /// <summary>
    /// Interaction logic for LayoutNormal.xaml
    /// </summary>
    public partial class LayoutNormal : LayoutBase
    {
        public LayoutNormal()
        {
            InitializeComponent();
            ImageLIst = ImageLIstBox;
            InitServices();
            zoombox.RelativeZoomModifiers.Clear();
            zoombox.RelativeZoomModifiers.Add(KeyModifier.None);
            zoombox.DragModifiers.Clear();
            zoombox.DragModifiers.Add(KeyModifier.None);
            zoombox.KeepContentInBounds = true;
        }

        private void zoombox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
        }

        private void zoombox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
        }

        private void zoombox_ViewStackIndexChanged(object sender, Xceed.Wpf.Toolkit.Core.IndexChangedEventArgs e)
        {
            LoadFullRes();
        }

        public override void OnImageLoaded()
        {
            Dispatcher.Invoke(new Action(() => zoombox.FitToBounds()));
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            ServiceProvider.WindowsManager.ExecuteCommand(WindowsCmdConsts.Next_Image);
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            ServiceProvider.WindowsManager.ExecuteCommand(WindowsCmdConsts.Prev_Image);
        }

    }
}