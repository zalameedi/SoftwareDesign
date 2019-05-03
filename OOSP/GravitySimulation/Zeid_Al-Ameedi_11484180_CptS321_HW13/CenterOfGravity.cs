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
    /// Class that encapsulates the center of gravity
    /// that other objects will rely on.
    /// </summary>
    public class CenterOfGravity
    {
        private Point m_location;
        private int m_radius;

        /// <summary>
        /// Property for the location attribute.
        /// </summary>
        public Point Location
        {
            get
            {
                return m_location;
            }
            set
            {
                if (m_location != value)
                {
                    m_location = value;
                }
            }
        }

        /// <summary>
        /// Property for the radius attribute.
        /// </summary>
        public int Radius
        {
            get
            {
                return m_radius;
            }
            set
            {
                if (m_radius != value)
                {
                    m_radius = value;
                }
            }
        }

        /// <summary>
        /// Setter for the constructor
        /// </summary>
        /// <param name="location"></param>
        /// <param name="radius"></param>
        public CenterOfGravity(Point location, int radius)
        {
            m_location = location;
            m_radius = radius;
        }

        /// <summary>
        /// Nonsetter for the constructor
        /// </summary>
        public CenterOfGravity()
        {

        }

    }
}
