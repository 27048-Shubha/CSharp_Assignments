using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models.DTOs
{
    /// <summary>
    /// Represents a pair of integer values.
    /// </summary>
    public class PairDTO
    {
        /// <summary>
        /// Gets or sets the first value.
        /// </summary>
        /// <value>Value of first variable.</value>
        public int Value1 { get; set; }

        /// <summary>
        /// Gets or sets the second value.
        /// </summary>
        /// <value>Value of second variable.</value>
        public int Value2 { get; set; }
    }
}
