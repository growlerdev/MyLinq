namespace Linq.Extensions.Tests
{
    public class LinqTests
    {
        [Fact]
        public void MinByDouble()
        {
            var list = new List<TestObject<double>>();
            var minWidthObj = new TestObject<double> { Height = 1, Width = 3.5, Depth = 8, Qty = 1 };
            list.Add(minWidthObj);
            list.Add(new TestObject<double>{ Height = 3, Width = 6.5, Depth = 1, Qty = 5 });

            var min = list.MinBy(x => x.Width);

            Assert.Equal(minWidthObj, min);
        }

        [Fact]
        public void MinByFloat()
        {
            var list = new List<TestObject<float>>();
            var minWidthObj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.Add(minWidthObj);
            list.Add(new TestObject<float> { Height = 3, Width = 6.5f, Depth = 1, Qty = 5 });

            var min = list.MinBy(x => x.Width);

            Assert.Equal(minWidthObj, min);
        }

        [Fact]
        public void MinByInt()
        {
            var list = new List<TestObject<float>>();
            var minWidthObj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.Add(minWidthObj);
            list.Add(new TestObject<float> { Height = 3, Width = 6.5f, Depth = 1, Qty = 5 });

            var min = list.MinBy(x => x.Height);

            Assert.Equal(minWidthObj, min);
        }

        [Fact]
        public void AddMany()
        {
            var list = new List<TestObject<float>>();
            var obj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.AddMany(obj, 3);

            Assert.True(list.All(o => o.Equals(obj)));
            Assert.Equal(3, list.Count);
        }
    }
}