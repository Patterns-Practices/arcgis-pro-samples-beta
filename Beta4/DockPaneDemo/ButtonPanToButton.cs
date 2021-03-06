﻿//Copyright 2014 Esri

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Internal.Mapping;


namespace UCSamples.DockPaneDemo
{
    
    /// <summary>
    /// Represents the Pan button
    /// </summary>
    public class ButtonPanToButton : Button
    {
        private static int _index = 0;

        protected override void OnUpdate()
        {
            if (this.Enabled)
                return;
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            this.Enabled = (dvm != null);
        }
        protected override async void OnClick()
        {
            DockpaneViewModel dvm = DockpaneUtils.FindDockPane() as DockpaneViewModel;
            if (dvm == null)
            {
                this.Enabled = false;
                return;
            }
            if (!dvm.HasBookmarksLoaded)
            {
                await dvm.LoadBookmarks();
            }
            if (dvm.Cities == null || dvm.Cities.Count() == 0)
                return;

            if (_index >= dvm.Cities.Count())
                _index = 0;

            dvm.Cities[_index++].ZoomTo();
        }
    }
}
