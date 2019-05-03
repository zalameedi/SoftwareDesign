/*******************
 * Zeid Al-Ameedi
 * 05/02/2019
 * Cpts321 HW13 Gravity Simulation
 * Collab: Nobody
 * Bonus assignment that simulates planets orbiting
 * **************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeid_Alameedi_11484180_HW13
{
    /// <summary>
    /// Planet class that encapsulates the logic
    /// of what desginates its creation.
    /// </summary>
    public class Planet
    {
        private Point m_location;
        private CenterOfGravity m_centerOfGravity;
        private double m_distanceFromCOG;

        /// <summary>
        /// Property for our location features
        /// </summary>
        public Point Location
        {
            get
            {
                return m_location;
            }
            set
            {
                if ( m_location != value)
                {
                    m_location = value;
                }
            }
        }

        /// <summary>
        /// Property for our center of gravity feature
        /// </summary>
        public CenterOfGravity CenterOfGravity
        {
            get
            {
                return m_centerOfGravity;
            }
            set
            {
                if (m_centerOfGravity != value)
                {
                    m_centerOfGravity = value;
                }
            }
        }

        /// <summary>
        /// Property for our Distance from center of gravity
        /// attribute.
        /// </summary>
        public double DistanceFromCOG
        {
            get
            {
                return m_distanceFromCOG;
            }
            set
            {
                if (m_distanceFromCOG != value)
                {
                    m_distanceFromCOG = value;
                }
            }
        }


        /// <summary>
        /// Planet location's default property
        /// </summary>
        /// <param name="planetLocation"></param>
        public Planet(Point planetLocation)
        {
            m_location = planetLocation;
            m_distanceFromCOG = 10000000;
        }

        /// <summary>
        /// Determines and sets the center of gravity for a planet. 
        /// If no center of gravity is in range, the planet will not move.
        /// </summary>
        /// <param name="possibleCOG"></param>
        public void DetermineCOG(CenterOfGravity possibleCOG)
        {
            var d = Math.Sqrt(Math.Pow(m_location.X - possibleCOG.Location.X, 2) + Math.Pow(m_location.Y - possibleCOG.Location.Y, 2));
            var dist = Math.Abs(d);

            if (dist <= possibleCOG.Radius)
            {
                if (dist < m_distanceFromCOG)
                {
                    m_distanceFromCOG = dist;
                    m_centerOfGravity = possibleCOG;
                }
            }
        }

        /// <summary>
        /// Rotate function - moves the planet around the center of gravity
        /// </summary>
        public void RotatePlanet()
        {
            int distanceX = m_location.X - m_centerOfGravity.Location.X;
            int distanceY = m_location.Y - m_centerOfGravity.Location.Y;

            m_location.X = (int)(m_centerOfGravity.Location.X + (distanceX * (Math.Cos(5 * Math.PI / 180))) - distanceY * (Math.Sin(5 * Math.PI / 180)));
            m_location.Y = (int)(m_centerOfGravity.Location.Y + (distanceY * (Math.Cos(5 * Math.PI / 180))) + distanceX * (Math.Sin(5 * Math.PI / 180)));
        }

    }
}
