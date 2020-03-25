using System.Collections.Generic;

namespace MarsRover.Models
{
    /// <summary>
    /// The rover request
    /// </summary>
    public class RoverRequest
    {
        /// <summary>
        /// Gets or sets the square.
        /// </summary>
        /// <value>
        /// The square.
        /// </value>
        public SquareModel Square { get; set; }

        /// <summary>
        /// Gets or sets the rover models.
        /// </summary>
        /// <value>
        /// The rover models.
        /// </value>
        public List<RoverModel> RoverModels { get; set; }
    }
}