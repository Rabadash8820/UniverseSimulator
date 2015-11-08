using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe {

    public class Particle {
        // CONSTRUCTORS
        public Particle(int atomicNum) {
            Id = new Guid();
            reset(atomicNum, new Point(0, 0), 0d);
        }
        public Particle(int atomicNum, Point position) {
            Id = new Guid();
            reset(atomicNum, position, 0d);
        }
        public Particle(int atomicNum, int x, int y) {
            Id = new Guid();
            reset(atomicNum, new Point(x, y), 0d);
        }
        public Particle(int atomicNum, double temp) {
            Id = new Guid();
            reset(atomicNum, new Point(0, 0), temp);
        }
        public Particle(int atomicNum, Point position, double temp) {
            Id = new Guid();
            reset(atomicNum, position, temp);
        }
        public Particle(int atomicNum, int x, int y, double temp) {
            Id = new Guid();
            reset(atomicNum, new Point(x, y), temp);
        }

        // INTERFACE
        public Guid Id { get; protected set; }
        public Point Position { get; set; }
        public int AtomicNumber { get; set; }
        public double Electronegativity { get; protected set; }

        // HELPER FUNCTIONS
        private void reset(int atomicNum, Point position, double temp) {
            AtomicNumber = atomicNum;
            Position = position;
            Electronegativity = getElectroNeg(AtomicNumber);
        }
        private double getElectroNeg(int atomicNum) {
            double temp = Math.Cos(Math.PI / 5d * atomicNum);
            return temp * temp;
        }
    }

}
