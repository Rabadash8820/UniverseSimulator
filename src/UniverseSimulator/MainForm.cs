using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;

using Universe;

namespace UniverseSimulator {

    public partial class MainForm : Form {
        // ENCAPUSLATED FIELDS
        private StreamWriter _outputStrm;
        private Simulator _simulator;
        private Bitmap _bmp;
        private Dictionary<int, Color> _colors;
        private const short PARTICLE_SIZE = 8;
        private long _iteration;
        private bool _started;


        // CONSTRUCTORS
        public MainForm() {
            InitializeComponent();

            _colors = new Dictionary<int, Color>(20) {
                {0,Color.Red },
                {1, Color.Green },
                {2, Color.Blue },
                {3, Color.Purple },
                {4, Color.Brown },
                {5,Color.Yellow },
                {6,Color.Orange },
                {7,Color.Aquamarine },
                {8,Color.White },
                {9,Color.Gray },
                {10,Color.Lime },
                {11, Color.SkyBlue },
                {12,Color.Pink },
                {13,Color.Magenta },
                {14,Color.Tan },
                {15,Color.Olive },
                {16,Color.DarkCyan },
                {17,Color.DarkGreen },
                {18,Color.DarkBlue },
                {19,Color.Plum },
            };

            _started = false;
            _bmp = new Bitmap(1,1);
        }
        
        // EVENT HANDLERS
        private void MainPicBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(_bmp, 0, 0);
        }
        private void PlayPauseBtn_Click(object sender, EventArgs e) {
            // If this is a new run...
            if (!_started) {
                // Get parameters from the Form
                int size = (int)SizeUpDown.Value;
                int numParticles = (int)ParticlesUpDown.Value;
                double temp = (double)TempUpDown.Value;
                int numElements = (int)ElementsUpDown.Value;

                // Start the simulator on iteration 0
                _started = true;
                _iteration = 0;
                _simulator = new Simulator(size, numParticles, numElements, temp);
                _bmp = new Bitmap(PARTICLE_SIZE * size, PARTICLE_SIZE * size, PixelFormat.Format24bppRgb);

                // Set up output file
                _outputStrm = new StreamWriter("output.csv", false);
                output();

                StopBtn.Enabled = true;
            }

            bool paused = (PlayPauseBtn.Text == "Play");
            if (paused)
                play();
            else
                pause();
        }
        private void StopBtn_Click(object sender, EventArgs e) {
            stop();
        }
        private void SimulationWorker_DoWork(object sender, DoWorkEventArgs e) {
            // Define some variables so we're not allocating as much memory every loop
            int frameDur;
            DateTime start, end;
            TimeSpan elapsedTime;
            int sleepTime;

            // Run the Simulation until cancelled
            while (!SimulationWorker.CancellationPending) {
                // Do an iteration
                start = DateTime.Now;
                _simulator.Iterate();
                output();
                end = DateTime.Now;

                Invoke(new Action(() => {
                    IterationLbl.Text = $"Iteration: {++_iteration}";
                }));

                // Sleep so that the framerate is (somewhat) constant
                elapsedTime = end - start;
                frameDur = 1000 / (int)FpsUpDown.Value; // In milliseconds
                sleepTime = Math.Max(frameDur - elapsedTime.Milliseconds, 0);
                Thread.Sleep(sleepTime);
            }

            e.Cancel = true;
        }
        private void SimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled && !_started)
                IterationLbl.Text = $"Iteration: {0}";
        }
        private void SizeUpDown_ValueChanged(object sender, EventArgs e) {
            int size = (int)SizeUpDown.Value;
            ParticlesUpDown.Maximum = (int)(size * size * 0.8);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            stop();
        }

        // HELPER FUNCTIONS
        private void play() {
            toggleSimulationCtrls(true);

            SimulationWorker.RunWorkerAsync();
        }
        private void pause() {
            SimulationWorker.CancelAsync();

            toggleSimulationCtrls(false);
        }
        private void stop() {
            _started = false;
            _outputStrm.Close();

            // Adjust controls
            StopBtn.Enabled = false;
            if (PlayPauseBtn.Text == "Play")
                IterationLbl.Text = $"Iteration: {0}";
            toggleSimulationCtrls(false);
        }
        private void output() {
            // Draw the Bitmap;
            int size = _simulator.Size;
            _bmp = new Bitmap(PARTICLE_SIZE * size, PARTICLE_SIZE * size, PixelFormat.Format24bppRgb);
            IList<Particle> particles = _simulator.Particles;
            foreach (Particle p in particles) {
                for (int px = 1; px < PARTICLE_SIZE - 1; ++px) {
                    for (int py = 1; py < PARTICLE_SIZE - 1; ++py) {
                        int x = PARTICLE_SIZE * p.Position.X + px;
                        int y = PARTICLE_SIZE * p.Position.Y + py;
                        _bmp.SetPixel(x, y, _colors[p.AtomicNumber]);
                    }
                }
            }

            // Output the Energy
            Invoke(new Action(() => {
                EnergyLbl.Text = $"Energy: {_simulator.Energy:N2}";
            }));

            // Refresh the PictureBox containing this Bitmap
            Invoke(new Action(() => {
                MainPicBox.Refresh();
            }));

            // Write to File
            string str = $"{_iteration},{_simulator.Energy}";
            _outputStrm.WriteLine(str);
        }
        private void toggleSimulationCtrls(bool running) {
            PlayPauseBtn.Text = (running ? "Pause" : "Play");
        }

    }

}
