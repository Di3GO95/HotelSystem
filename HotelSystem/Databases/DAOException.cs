using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Databases {
    class DAOException : Exception {
        //private static readonly long serialVersionUID = 1L;

        public DAOException(string message) : base(message) {

        }
    }
}
