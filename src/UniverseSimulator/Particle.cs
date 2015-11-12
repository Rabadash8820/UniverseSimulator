using System;
using System.Drawing;

namespace Universe {

    public class Particle {
        // CONSTRUCTORS
        public Particle(int atomicNum) {
            initialize(atomicNum, new Point(0, 0), 0d);
        }
        public Particle(int atomicNum, Point position) {
            initialize(atomicNum, position, 0d);
        }
        public Particle(int atomicNum, int x, int y) {
            initialize(atomicNum, new Point(x, y), 0d);
        }
        public Particle(int atomicNum, double temp) {
            initialize(atomicNum, new Point(0, 0), temp);
        }
        public Particle(int atomicNum, Point position, double temp) {
            initialize(atomicNum, position, temp);
        }
        public Particle(int atomicNum, int x, int y, double temp) {
            initialize(atomicNum, new Point(x, y), temp);
        }

        // INTERFACE
        public Guid Id { get; protected set; }
        public Point Position { get; set; }
        public int AtomicNumber { get; set; }
        public double Electronegativity { get; protected set; }
        public override bool Equals(object obj) {
            if (!base.Equals(obj))
                return false;

            Particle that = obj as Particle;
            bool equal = (this.Id == that.Id);
            return equal;
        }

        // HELPER FUNCTIONS
        private void initialize(int atomicNum, Point position, double temp) {
            Id = Guid.NewGuid();
            reset(atomicNum, position, temp);
        }
        private void reset(int atomicNum, Point position, double temp) {
            AtomicNumber = atomicNum;
            Position = position;
            Electronegativity = getElectroNeg(AtomicNumber);
        }
        private double getElectroNeg(int atomicNum) {
            double derp = Math.Cos(Math.PI / 5d * atomicNum);
            return derp * derp;
        }
    }

}
