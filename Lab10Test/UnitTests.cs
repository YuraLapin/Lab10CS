using Lab10Main;

namespace Lab10Test
{
    public class PersonTests
    {
        [Fact]
        public void NameOnlyConstructor()
        {
            var expected = new Person("1", 1, 1);
            var actual = new Person("1");
            Assert.Equal(expected, actual);
        }
    }
}