//using System.Text.Json;

//namespace Lab9Test.Blue
//{
//    [TestClass]
//    public sealed class Task1
//    {
//        private Lab9.Blue.Task1 _student;

//        private string[] _input;
//        private string[][] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Blue", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Blue1")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Blue1")
//                          .GetProperty("output")
//                          .Deserialize<string[][]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Blue.Task1);

//            Assert.IsTrue(type.IsClass, "Task1 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Blue.Blue)),
//                "Task1 must inherit from Blue");

//            Assert.IsNotNull(
//                type.GetConstructor(new[] { typeof(string) }),
//                "Task1 must have constructor Task1(string input)"
//            );

//            Assert.IsNotNull(type.GetMethod("Review"),
//                "Method Review() not found");

//            Assert.IsNotNull(type.GetMethod("ToString"),
//                "Method ToString() not found");
//        }

//        [TestMethod]
//        public void Test_01_Input()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                Assert.AreEqual(_input[i], _student.Input,
//                    $"Input stored incorrectly\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_02_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expected = _output[i];
//                var actual = _student.Output;

//                Assert.AreEqual(expected.Length, actual.Length,
//                    $"Length mismatch\nTest: {i}:\n{string.Join(Environment.NewLine, actual)}");

//                for (int j = 0; j < expected.Length; j++)
//                {
//                    Assert.AreEqual(expected[j], actual[j],
//                        $"Line mismatch\nTest: {i}, Index: {j}\nExpected: {expected[j]}\nActual: {actual[j]}");
//                }
//            }
//        }

//        [TestMethod]
//        public void Test_03_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expected = string.Join(Environment.NewLine, _output[i]);
//                var actual = _student.ToString();

//                Assert.AreEqual(expected, actual,
//                    $"ToString output mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_04_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var originalOutput = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input,
//                    $"ChangeText failed\nTest: {i}");

//                Assert.IsFalse(originalOutput.SequenceEqual(_student.Output),
//                    $"Output not updated\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_05_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof(string[]),
//                $"Output must be string[]\nActual: {_student.Output.GetType()}");
//        }
//        [TestMethod]
//        public void Test_06_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expectedLength = string.Join(Environment.NewLine, _output[i]).Length;
//                var actualLength = _student.ToString().Length;

//                Assert.AreEqual(expectedLength, actualLength,
//                    $"Wrong ToString length\nTest: {i}");
//            }
//        }
//        [TestMethod]
//        public void Test_07_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(_student is Lab9.Blue.Blue,
//                    $"Task1 must inherit from Blue\nTest: {i}");

//                Assert.AreEqual(_input[i], _student.Input,
//                    $"Input mismatch\nTest: {i}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Blue.Task1(_input[i]);
//        }
//    }
//}