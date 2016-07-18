using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFS.Domain.Entities;

namespace GFS.Domain.Abstract
{
    public interface IFuneralFormProcessor
    {
        void ProcessOrder(FuneralItem cart, Claims shippingDetails);
    }
}
