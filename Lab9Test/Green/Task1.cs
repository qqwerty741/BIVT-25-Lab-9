
//using System.Globalization;
//using System.Text.Json;

//namespace Lab9Test.Green
//{
//    [TestClass]
//    public sealed class Task1
//    {
//        private Lab9.Green.Task1 _student;

//        private string[] _input;
//        private string[][] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Green", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Task1")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Task1")
//                          .GetProperty("output")
//                          .Deserialize<string[][]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Green.Task1);

//            Assert.IsTrue(type.IsClass, "Task1 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Green.Green)),
//                "Task1 must inherit from Green");

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
//                    $"Input stored incorrectly\nTest: {i}\nText:\n{_input[i]}");
//            }
//        }

//        [TestMethod]
//        public void Test_02_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                var expected = _output[i]; // string[] вида "а:0.0640"
//                var actual = _student.Output; // (char,double)[]

//                Assert.AreEqual(expected.Length, actual.Length, $"Length mismatch\nTest: {i}");

//                for (int j = 0; j < expected.Length; j++)
//                {
//                    var parts = expected[j].Split(':');       // "а:0.0640" -> ["а","0.0640"]
//                    char expectedChar = parts[0][0];
//                    double.TryParse(parts[1], CultureInfo.InvariantCulture, out double expectedVal);

//                    Assert.AreEqual(expectedChar, actual[j].Item1,
//                        $"Char mismatch\nTest: {i}, Index: {j}\nExpected: {expectedChar}\nActual: {actual[j].Item1}");

//                    Assert.AreEqual(expectedVal, actual[j].Item2, 1e-4,
//                        $"Value mismatch\nTest: {i}, Index: {j}\nExpected: {expectedVal}\nActual: {actual[j].Item2}");
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

//                var expected = string.Join("\n", _student.Output.Select(x => $"{x.Item1}:{x.Item2:F4}"));
//                var actual = _student.ToString();

//                Assert.AreEqual(expected, actual,
//                    $"ToString output mismatch\nTest: {i}\nExpected:\n{expected}\nActual:\n{actual}");
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
//                    $"ChangeText failed to update Input\nTest: {i}");

//                Assert.IsFalse(originalOutput.SequenceEqual(_student.Output),
//                    $"ChangeText did not update Output\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_05_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof((char, double)[]),
//                $"Output must be of type (char,double)[]\nActual type: {_student.Output.GetType()}");
//        }

//        [TestMethod]
//        public void Test_06_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expectedLength = string.Join("\n", _student.Output.Select(x => $"{x.Item1}:{x.Item2:F4}")).Length;
//                var actualLength = _student.ToString().Length;

//                Assert.AreEqual(expectedLength, actualLength,
//                    $"Wrong ToString length\nTest: {i}\nExpected length: {expectedLength}\nActual length: {actualLength}");
//            }
//        }

//        [TestMethod]
//        public void Test_07_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(_student is Lab9.Green.Green,
//                    $"Task1 must inherit from Green\nTest: {i}");

//                Assert.AreEqual(_input[i], _student.Input,
//                    $"Input mismatch after inheritance\nTest: {i}\nText:\n{_input[i]}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Green.Task1(_input[i]);
//        }
//    }
//}