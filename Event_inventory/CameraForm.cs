using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using SixLabors.ImageSharp;

namespace Event_inventory
{
    public partial class CameraForm : Form
    {
        public string ScannedBarcode { get; private set; }

        public CameraForm()
        {
            InitializeComponent();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            SimulateBarcodeScanning();
        }
    }

    private void SimulateBarcodeScanning()
    {
        // Simulate scanning a barcode using the camera
        // For demonstration purposes, generate a random barcode
        Random random = new Random();
        ScannedBarcode = random.Next(100000, 999999).ToString();

        // Close the form after simulating the scan
        DialogResult = DialogResult.OK;
        Close();
    }
}
}
}
