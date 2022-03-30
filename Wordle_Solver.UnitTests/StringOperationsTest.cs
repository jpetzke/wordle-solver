using NUnit.Framework;
using Hangman_Solver;

namespace Hangman_Solver.UnitTests
{
    [TestFixture]
    public class WordlistOperationsTests
    {
        private StringOperations _operations = new StringOperations();
        [SetUp]
        public void SetUp()
        {
            _operations = new StringOperations();
        }

        [Test]
        public void GetIndex_ValidNumber_ReturnsIndex()
        {

            string[] arr = new string[] { "a", "b", "c" };
            int result = _operations.GetIndex(arr, "b");
            Assert.That(result == 1);
        }

        [Test]
        [TestCase(new string[] { "a", "b", "c" }, null)]
        [TestCase(null, "a")]
        public void GetIndex_NullArgument_ThrowsArgumentNullException(string[] array, string query)
        {
            Assert.That(() => _operations.GetIndex(array, query), Throws.ArgumentNullException);
        }

        [Test]
        public void CountCharsInString_WhenCalled_ReturnCharCount()
        {
            Assert.That(_operations.CountCharsInString("abca", 'a') == 2);
        }

        [Test]
        [TestCase("abca", null)]
        [TestCase(null, 'a')]
        public void CountCharsInString_NullArgument_ThrowsArgumentNullException(string s, char f)
        {
            Assert.That(() => _operations.CountCharsInString(s, f), Throws.ArgumentNullException);
        }

        [Test]
        public void GetStringsWithLenghFromArray_WhenCalled_ReturnStringsWithLength()
        {
            Assert.That(_operations.GetStringsWithLenghFromArray(new string[] {"a", "aa", "aaa", "bb"}, 2), Is.EqualTo(new string[] {"aa", "bb"}));
        }

        [Test]
        public void GetStringsWithCharAtIndex_WhenCalled_ReturnStringlist()
        {
            Assert.That(_operations.GetStringsWithCharAtIndex(new string[] { "aba", "bbb", "aaa" }, 1, 'b'), Is.EqualTo(new string[] { "aba", "bbb" }));
        }

        [Test]
        public void GetStringsWithCharNotAtIndex_WhenCalled_ReturnStringlist()
        {
            Assert.That(_operations.GetStringsWithNotCharAtIndex(new string[] { "aba", "bbb", "aaa" }, 1, 'b'), Is.EqualTo(new string[] { "aaa" }));
        }

        [Test]
        public void GetStringsContainingChar_WhenCalled_ReturnStrings()
        {
            Assert.That(_operations.GetStringsContainingChar(new string[] { "abc", "acc", "acb" }, 'b'), Is.EqualTo(new string[] { "abc", "acb" }));
        }

        [Test]
        public void GetStringsNotContainingChar_WhenCalled_ReturnStrings()
        {
            Assert.That(_operations.GetStringsNotContainingChar(new string[] { "abc", "acc", "acb" }, 'b'), Is.EqualTo(new string[] { "acc" }));
        }

        [Test]
        [TestCase("candy", "+----", "colab", false)]
        public void StringDoesMatch_WhenCalled_ReturnBool(string src, string cond, string chk, bool exp_res)
        {
            Assert.That(_operations.StringDoesMatch(src, cond, chk) == exp_res);
        }

    }
}