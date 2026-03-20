//using System.Text.Json;
//using System.Linq;

//namespace Lab9Test.Purple
//{
//    [TestClass]
//    public sealed class Task2
//    {
//        private Lab9.Purple.Task2 _student;

//        private string[] _input;
//        private string[][] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Purple", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Purple2")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Purple2")
//                          .GetProperty("output")
//                          .Deserialize<string[][]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Purple.Task2);

//            Assert.IsTrue(type.IsClass);
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Purple.Purple)));

//            Assert.IsNotNull(type.GetConstructor(new[] { typeof(string) }));
//            Assert.IsNotNull(type.GetMethod("Review"));
//            Assert.IsNotNull(type.GetMethod("ToString"));
//        }

//        [TestMethod]
//        public void Test_01_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var actual = _student.Output;
//                var expected = _output[i];

//                Assert.AreEqual(expected.Length, actual.Length,
//                    $"Line count mismatch\nTest: {i}");

//                for (int j = 0; j < expected.Length; j++)
//                {
//                    Assert.AreEqual(expected[j], actual[j],
//                        $"Line mismatch\nTest: {i}, Line: {j}");
//                }
//            }
//        }

//        [TestMethod]
//        public void Test_02_LineLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                for (int j = 0; j < _output[i].Length; j++)
//                {
//                    Assert.AreEqual(_output[i][j].Length, _student.Output[j].Length,
//                        $"Line length must be 50\nActual: {_student.Output[j].Length}\nLine: {_student.Output[j]}");
//                }
//            }
//        }

//        [TestMethod]
//        public void Test_03_NoWordBreak()
//        {
//            Init(0);
//            _student.Review();

//            foreach (var line in _student.Output)
//            {
//                Assert.IsFalse(line.StartsWith(" "),
//                    "Line starts with space");

//                Assert.IsFalse(line.EndsWith(" "),
//                    "Line ends with space");
//            }
//        }

//        [TestMethod]
//        public void Test_04_SpacesDistributed()
//        {
//            Init(0);
//            _student.Review();

//            foreach (var line in _student.Output)
//            {
//                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//                if (words.Length <= 1) continue;

//                int spaces = line.Count(c => c == ' ');
//                int minSpaces = (50 - words.Sum(w => w.Length)) / (words.Length - 1);

//                Assert.IsTrue(spaces >= minSpaces,
//                    $"Spaces distributed incorrectly\nLine: {line}");
//            }
//        }

//        [TestMethod]
//        public void Test_05_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expected = string.Join(Environment.NewLine, _output[i]);
//                var actual = _student.ToString();

//                Assert.AreEqual(expected, actual,
//                    $"ToString mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_06_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var old = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input,
//                    $"ChangeText failed\nTest: {i}");

//                Assert.IsFalse(old.SequenceEqual(_student.Output),
//                    $"Output not updated\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_07_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof(string[]),
//                $"Output must be string[]\nActual: {_student.Output.GetType()}");
//        }

//        [TestMethod]
//        public void Test_08_ToStringLength()
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

//        private void Init(int i)
//        {
//            _student = new Lab9.Purple.Task2(_input[i]);
//        }
//    }
//}