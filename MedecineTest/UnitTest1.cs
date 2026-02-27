using System.Security.Permissions;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using MedicamentBO;

namespace MedecineTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var medicament = new Medicament(1, "Doliprane", "Zardlab");
            Assert.That(medicament != null);
        }
    }
}
