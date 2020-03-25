using MarsRover.Enums;
using MarsRover.Models.BaseModels;

namespace MarsRover.Models
{
    /// <summary>
    /// The start position
    /// </summary>
    /// <seealso cref="MarsRover.Models.BaseModels.Position" />
    public class StartPosition : Position
    {
        /// <summary>
        /// Gets or sets the compass.
        /// </summary>
        /// <value>
        /// The compass.
        /// </value>
        public Compass Compass { get; set; }
    }
}