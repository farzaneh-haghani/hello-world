using System.Diagnostics;

namespace FirstProject
{
    
    public class UnitTest1
    {
        [Fact]
        public void Test1() 
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test2()
        {
            Class1 c = new Class1();
            c.MyProperty2 = 5;
            Assert.Equal(5, c.MyProperty2);
        }
        [Fact]
        public void Test3()
        {
            Class1 c = new Class1();
            c.MyProperty2 = 51;
            Assert.Equal(51, c.MyProperty2);
        }
    
    }
}

