namespace MarsRover.Models.BaseModels
{
    /// <summary>
    /// The position
    /// </summary>
    public abstract class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position()
        {
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }

        /// <summary>
        /// Gets or sets the position x.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public int PositionX { get; set; }

        /// <summary>
        /// Gets or sets the position y.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public int PositionY { get; set; }
    }
}