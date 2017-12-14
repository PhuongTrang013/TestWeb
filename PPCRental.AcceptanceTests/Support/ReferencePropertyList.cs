using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Models;
using FluentAssertions;

namespace PPCRental.AcceptanceTests.Support
{
    public class ReferencePropertyList : Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string ID)
        {
            return this[ID.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }

        //internal object GetById(string ID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
