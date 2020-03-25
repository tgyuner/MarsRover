using System.Collections.Generic;
using MarsRover.Enums;

namespace MarsRover.Models
{
    /// <summary>
    /// The rover model
    /// </summary>
    public class RoverModel
    {
        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>
        /// The start position.
        /// </value>
        public StartPosition StartPosition { get; set; }

        /// <summary>
        /// Gets or sets the command list.
        /// </summary>
        /// <value>
        /// The command list.
        /// </value>
        public List<Command> CommandList { get; set; }
    }
}