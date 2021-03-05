using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Entities.Base
{
    /// <summary>
    /// Base class, that represents Entity
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Identifier for entities
        /// </summary>
        public int Id { get; set; }
    }
}
