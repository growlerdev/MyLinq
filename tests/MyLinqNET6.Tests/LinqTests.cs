namespace MyLinq.Tests
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
        public void MaxByDouble()
        {
            var list = new List<TestObject<double>>();
            var maxWidthObj = new TestObject<double> { Height = 1, Width = 3.5, Depth = 8, Qty = 1 };
            list.Add(maxWidthObj);
            list.Add(new TestObject<double> { Height = 3, Width = 2.5, Depth = 1, Qty = 5 });

            var max = list.MaxBy(x => x.Width);

            Assert.Equal(maxWidthObj, max);
        }

        [Fact]
        public void MaxByFloat()
        {
            var list = new List<TestObject<float>>();
            var maxWidthObj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.Add(maxWidthObj);
            list.Add(new TestObject<float> { Height = 3, Width = 2.5f, Depth = 1, Qty = 5 });

            var max = list.MaxBy(x => x.Width);

            Assert.Equal(maxWidthObj, max);
        }

        [Fact]
        public void MaxByInt()
        {
            var list = new List<TestObject<float>>();
            var maxWidthObj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.Add(maxWidthObj);
            list.Add(new TestObject<float> { Height = 3, Width = 2.5f, Depth = 1, Qty = 5 });

            var max = list.MaxBy(x => x.Width);

            Assert.Equal(maxWidthObj, max);
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

        [Fact]
        public void DistinctBy()
        {
            var list = new List<TestObject<float>>();
            var obj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.AddMany(obj, 3);

            var obj2 = new TestObject<float> { Height = 2, Width = 5, Depth = 10, Qty = 2 };
            list.Add(obj2);

            var unique = list.DistinctBy(o => o.Height).ToList();

            Assert.Equal(2, unique.Count);
        }

        [Fact]
        public void IsNull()
        {
            List<TestObject<float>> list = null;

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact]
        public void IsEmpty()
        {
            List<TestObject<float>> list = new();

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact]
        public void ExceptWhere()
        {
            var list = new List<TestObject<float>>();
            var obj = new TestObject<float> { Height = 1, Width = 3.5f, Depth = 8, Qty = 1 };
            list.AddMany(obj, 3);

            var obj2 = new TestObject<float> { Height = 2, Width = 5, Depth = 10, Qty = 2 };
            list.Add(obj2);

            var check = list.ExceptWhere(o => o.Height == 2).ToList();

            Assert.True(check.All(o => o == obj));
            Assert.Equal(3, check.Count());
        }
    }
}