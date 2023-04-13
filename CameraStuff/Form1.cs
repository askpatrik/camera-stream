using System;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Camera;

namespace CameraStuff
{
    public partial class Form1 : Form
    {
        private IIPCamera _camera;
        private DrawingImageProvider _imageProvider = new DrawingImageProvider();
        private MediaConnector _connector = new MediaConnector();
        private VideoViewerWF _videoViewerWF1;

        public Form1()
        {
            //In the constructor (public Form1()), the UI is initialized by creating a new instance of
            //VideoViewerWF control and adding it to a Panel control (panel1). This creates a video player
            //UI element that can display the camera's video feed.

            InitializeComponent();

            // Create video viewer UI control
            _videoViewerWF1 = new VideoViewerWF();
            _videoViewerWF1.Name = "videoViewerWF1";
            _videoViewerWF1.Size = panel1.Size;
            panel1.Controls.Add(_videoViewerWF1);

            // Bind the camera image to the UI control
            _videoViewerWF1.SetImageProvider(_imageProvider);

            //The _videoViewerWF1.SetImageProvider(_imageProvider); line binds the camera's image to the UI control.
            //This means that the video player will display the video stream that comes from the image provider _imageProvider.
        }

        // Connect camera video channel to image provider and start
        private void connectBtn_Click(object sender, EventArgs e)
        {

            //In the connectBtn_Click event handler, the IP camera is created using the IPCameraFactory.GetCamera method.
            //This method takes three parameters: the camera's RTSP stream URL, the username for accessing the camera (if any),
            //and the password for accessing the camera (if any). These parameters are used to create a new instance of the IPCamera class.

            _camera = IPCameraFactory.GetCamera("rtsp://{IP number}/stream1", "", "");

            //The _connector.Connect method is called to connect the camera's video channel to the image provider _imageProvider.
            //This creates a connection between the camera and the video player UI control.
            _connector.Connect(_camera.VideoChannel, _imageProvider);

            //The _camera.Start() method is called to start the camera's video stream.
            _camera.Start();

            //Finally, the _videoViewerWF1.Start() method is called to start the video player UI control.
            //This displays the video feed from the camera in the UI control.
            _videoViewerWF1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
