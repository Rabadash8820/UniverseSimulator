using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace Universe {    

    public class Simulator {
        // ABSTRACT DATA TYPES
        public enum Direction {
            Vertical,
            Horizontal
        }
        private struct Rank {
            public Dictionary<Direction, double> Pulls { get; set; }
            public Direction MaxDirection { get; set; }
        }

        // HIDDEN FIELDS
        private Particle[,] _lattice;
        private Random _rand;
        private Dictionary<Particle, bool> _moveAttempts;
        private double _energy;

        // CONSTRUCTORS
        public Simulator(int size, int numParticles, int numElements, double temp = 0d) {
            // Definte private variables
            _rand = new Random();
            _lattice = new Particle[size, size];
            _moveAttempts = new Dictionary<Particle, bool>();

            // Define lattice properties
            Size = size;
            ParticleCount = numParticles;
            ElementCount = numElements;
            Temperature = temp;

            initialize();
        }

        // INTERFACE
        public int Size { get; protected set; }
        public int ParticleCount { get; set; }
        public double Temperature { get; set; }
        public int ElementCount { get; protected set; }
        public IList<Particle> Particles {
            get {
                IList<Particle> particles = new List<Particle>();
                for (int x = 0; x < Size; ++x) {
                    for (int y = 0; y < Size; ++y) {
                        Particle p = _lattice[x, y];
                        if (p == null)
                            continue;
                        particles.Add(p);
                    }
                }
                return particles;
            }
        }
        public double Energy {
            get { return _energy; }
        }
        public void Iterate() {
            Dictionary<Particle, Rank> ranks = new Dictionary<Particle, Rank>();

            // Determine how strongly each Particle is being pulled in the four cardinal directions
            for (int x = 0; x < Size; ++x) {
                for (int y = 0; y < Size; ++y) {
                    Particle p = _lattice[x, y];
                    if (p == null)
                        continue;
                    
                    Rank r = getParticleRank(p);
                    ranks.Add(p, r);
                }
            }

            // Compute the energy of the system in this Iteration
            _energy = ranks.Sum(r => Math.Abs(r.Value.Pulls[r.Value.MaxDirection]));

            // Sort the particles by the max magnitude of all their pull directions
            ranks = ranks.OrderBy(r => r.Value.Pulls[r.Value.MaxDirection])
                         .ToDictionary(r => r.Key, r => r.Value);

            // Process the Particles of highest rank (and any in their way) until all have been processed
            do {
                KeyValuePair<Particle, Rank> pair = ranks.Take(1).Single();
                processRank(pair.Key, pair.Value, ref ranks);
            } while (ranks.Count > 0);
        }

        // HELPER FUNCTIONS
        private void initialize() {
            // Add a random number of random particles
            for (int p = 0; p < ParticleCount; ++p) {
                int atomicNum = _rand.Next(0, ElementCount);
                int x, y;
                do {
                    x = _rand.Next(0, Size);
                    y = _rand.Next(0, Size);
                } while (_lattice[x, y] != null);
                Particle particle = new Particle(atomicNum, x, y, Temperature);
                _lattice[x, y] = particle;
                _moveAttempts.Add(particle, false);
            }
        }
        private Rank getParticleRank(Particle particle) {
            int x = particle.Position.X;
            int y = particle.Position.Y;

            // Get the pulls in all directions
            double sumLeft = 0d;
            for (int px = 0; px < x; ++px) {
                Particle other = _lattice[px, y];
                double electronegativity = (other?.Electronegativity ?? 1d);
                sumLeft += electronegativity / Math.Abs(px - x);
            }
            double sumRight = 0d;
            for (int px = x + 1; px < Size; ++px) {
                Particle other = _lattice[px, y];
                double electronegativity = (other?.Electronegativity ?? 1d);
                sumRight += electronegativity / Math.Abs(px - x);
            }
            double sumUp = 0d;
            for (int py = 0; py < y; ++py) {
                Particle other = _lattice[x, py];
                double electronegativity = (other?.Electronegativity ?? 1d);
                sumUp += electronegativity / Math.Abs(py - y);
            }
            double sumDown = 0d;
            for (int py = y + 1; py < Size; ++py) {
                Particle other = _lattice[x, py];
                double electronegativity = (other?.Electronegativity ?? 1d);
                sumDown += electronegativity / Math.Abs(py - y);
            }

            // Store the effective pull in each direction
            Dictionary<Direction, double> pulls = new Dictionary<Direction, double>() {
                { Direction.Vertical, sumDown - sumUp },
                { Direction.Horizontal, sumRight - sumLeft },
            };

            // Get the max Direction
            double max = 0d;
            Direction maxDir = Direction.Vertical;
            double absVert = Math.Abs(pulls[Direction.Vertical]);
            if (absVert > max) {
                max = absVert;
                maxDir = Direction.Vertical;
            }
            double absHorz = Math.Abs(pulls[Direction.Horizontal]);
            if (absHorz > max) {
                max = absHorz;
                maxDir = Direction.Horizontal;
            }

            // Return the rank for this Particle
            Rank r = new Rank() {
                Pulls = pulls,
                MaxDirection = maxDir,
            };
            return r;
        }
        private bool processRank(Particle p, Rank rank, ref Dictionary<Particle, Rank> ranks) {
            _moveAttempts[p] = true;
            bool particleMoved = false;
            
            // Try to move the Particle in its preferred direction
            Direction dir = rank.MaxDirection;
            int offset = Math.Sign(rank.Pulls[dir]);
            bool canMove = canMoveInDirection(p, rank, dir, offset, ref ranks);
            if (canMove) {
                moveParticle(p, dir, offset);
                particleMoved = true;
            }

            // If unsuccessful, try to move in the other direction
            else {
                dir = (rank.MaxDirection == Direction.Vertical) ? Direction.Horizontal : Direction.Vertical;
                offset = Math.Sign(rank.Pulls[dir]);
                canMove = canMoveInDirection(p, rank, dir, offset, ref ranks);
                if (canMove) {
                    moveParticle(p, dir, offset);
                    particleMoved = true;
                }
            }

            // Either way, this Particle has been processed, so remove it from the Dictionary
            ranks.Remove(p);
            _moveAttempts[p] = false;
            return particleMoved;
        }
        private bool canMoveInDirection(Particle p, Rank rank, Direction dir, int offset, ref Dictionary<Particle, Rank> ranks) {
            int x = p.Position.X;
            int y = p.Position.Y;
                        
            // If the neighboring position is off the lattice then retun false
            bool vertMax = (dir == Direction.Vertical);
            if ( ( vertMax && (y + offset < 0 || Size <= y + offset)) ||
                 (!vertMax && (x + offset < 0 || Size <= x + offset)) )
            {
                return false;
            }

            // Otherwise, if the position is open, return true
            Particle neighbor = (vertMax ? _lattice[x, y + offset] : _lattice[x + offset, y]);
            if (neighbor == null)
                return true;

            // Recursive case: the position is occupied, so return whether or not the neighbor can move
            if (!ranks.ContainsKey(neighbor))
                return false;
            if (_moveAttempts[p])
                return true;
            bool neighborCanMove = processRank(neighbor, ranks[neighbor], ref ranks);
            return neighborCanMove;
        }
        public void moveParticle(Particle p, Direction dir, int offset) {
            int x = p.Position.X;
            int y = p.Position.Y;

            if (_lattice[x, y].Equals(p))
                _lattice[x, y] = null;
            bool vertMax = (dir == Direction.Vertical);
            if (vertMax) {
                _lattice[x, y + offset] = p;
                p.Position = new Point(x, y + offset);
            }
            else {
                _lattice[x + offset, y] = p;
                p.Position = new Point(x + offset, y);
            }
        }
        
    }

}
