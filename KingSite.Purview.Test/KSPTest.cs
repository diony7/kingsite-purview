using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Repository;
using KingSite.BaseRepository;
using NUnit.Framework;
using KingSite.Purview.Services;
using System.Data;
using KingSite.Purview.Domain;


namespace KingSite.Purview.Test {
    [TestFixture]
    public class KSPTest {
        public void Test() {
            MembershipEx.CanDo("jerry", "Test", "AAA");           
        }               
    }
}
