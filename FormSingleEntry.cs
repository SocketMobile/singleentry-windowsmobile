// Copyright 2015 Socket Mobile, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ScanAPI;

namespace SingleEntryWM
{
    public partial class SingleEntryWM : Form, ScanApiHelper.ScanApiHelper.ScanApiHelperNotification
    {
        private const int SCANAPI_TIMER_PERIOD = 100;		// milliseconds

        private ScanApiHelper.ScanApiHelper _scanApiHelper;
        private ScanApiHelper.DeviceInfo connectedDevice;
        private bool _bInitialized;

        // for the Scan Test window to receive the decoded data
        public delegate void DecodedDataOutputDelegate(string strDecodedData);
        public delegate void StandardTextOutputDelegate(string strStatus);

        public SingleEntryWM()
        {
            InitializeComponent();
            lblStatus.Text = "Initializing...";
            _scanApiHelper = new ScanApiHelper.ScanApiHelper();
            _scanApiHelper.SetNotification(this);
            _bInitialized = false;
            Load += new EventHandler(SingleEntry_Load);
        }
        private void SingleEntry_Load(object sender, System.EventArgs e)
        {
            // Start ScanAPI Helper
            _scanApiHelper.Open();
            timerScanners.Interval = SCANAPI_TIMER_PERIOD;
            timerScanners.Enabled = true;
            //timerScanners.Start();
        }
        // if ScanAPI is fully initialized then we can
        // receive ScanObject from ScanAPI.
        private void timerScanners_Tick_1(object sender, EventArgs e)
        {
            if (_bInitialized == true)
                _scanApiHelper.DoScanAPIReceive();
        }

        // ScanAPI Helper provides a series of Callbacks
        // indicating some asynchronous events has occured
        #region ScanApiHelperNotification Members

        // a scanner has connected to the host
        public void OnDeviceArrival(long result, ScanApiHelper.DeviceInfo newDevice)
        {
            if (SktScanErrors.SKTSUCCESS(result))
            {
                UpdateStatusText("New Scanner: " + newDevice.Name);
                connectedDevice = newDevice;
            }
            else
            {
                string strMsg = String.Format("Unable to open scanner, error = %d.", result);
                MessageBox.Show(strMsg, "SingleEntry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
            }


        }

        // a scanner has disconnected from the host
        public void OnDeviceRemoval(ScanApiHelper.DeviceInfo deviceRemoved)
        {
            connectedDevice = null;
            UpdateStatusText("Scanner Removed: " + deviceRemoved.Name);
        }

        // a ScanAPI error occurs.
        public void OnError(long result, string errMsg)
        {
            MessageBox.Show("ScanAPI Error: " + Convert.ToString(result) + " [" + (errMsg != null ? errMsg : "") + "]",
                "Scanner Settings", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        // some decoded data have been received
        public void OnDecodedData(ScanApiHelper.DeviceInfo device, ISktScanDecodedData decodedData)
        {
            UpdateDecodedDataText(decodedData.DataToUTF8String);
        }

        // ScanAPI is now initialized and fully functionnal
        // (ScanAPI has some internal testing that might take
        // few seconds to complete)
        public void OnScanApiInitializeComplete(long result)
        {            
            if (SktScanErrors.SKTSUCCESS(result))
            {
                _bInitialized = true;
                UpdateStatusText("SktScanAPI opened!");
            }
            else
            {
                UpdateStatusText("SktScanOpen failed!");
            }
        }
        public void UpdateStatusText(string strStatus)
        {
            if (InvokeRequired)
                Invoke(new StandardTextOutputDelegate(UpdateStatusText), new object[] { strStatus });
            else
                lblStatus.Text = strStatus;
        }
        public void UpdateDecodedDataText(string strDecodedData)
        {
            if (InvokeRequired)
                Invoke(new DecodedDataOutputDelegate(UpdateDecodedDataText), new object[] { strDecodedData });
            else
                textScannedData.Text = strDecodedData;
        }
        // ScanAPI has now terminate, it is safe to
        // close the application now
        public void OnScanApiTerminated()
        {
            //timerScanner.Stop();
            _bInitialized = false;
            Close();// we can now close this form
        }

        // the ScanAPI Helper encounters an error during
        // the retrieval of a ScanObject
        public void OnErrorRetrievingScanObject(long result)
        {
            MessageBox.Show("Unable to retrieve a ScanAPI ScanObject: " + Convert.ToString(result),
                "Scanner Settings", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        #endregion
        private void btnPair_Click(object sender, EventArgs e)
        {
        }
        private void TriggerCompleteCallback(long result, ISktScanObject scanObj)
        {
            //MessageBox.Show("In trigger complete callback");
        }
        // called on the start scan button
        private void button1_Click(object sender, EventArgs e)
        {
            if (connectedDevice != null)
                _scanApiHelper.PostStartDecode(connectedDevice, TriggerCompleteCallback);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
