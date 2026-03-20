//using System.Text.Json;

//namespace Lab9Test.White
//{
//    [TestClass]
//    public sealed class Task1
//    {
//        private Lab9.White.Task1 _student;

//        private string[] _input;
//        private double[] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

//            var file = Path.Combine(folder, "Lab9Test", "White", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Task1")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Task1")
//                          .GetProperty("output")
//                          .Deserialize<double[]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.White.Task1);

//            Assert.IsTrue(type.IsClass, "Task1 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.White.White)),
//                "Task1 must inherit from White");

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

//                Assert.AreEqual(
//                    _input[i],
//                    _student.Input,
//                    $"Input stored incorrectly\nTest: {i}\nText:\n{_input[i]}"
//                );
//            }
//        }

//        [TestMethod]
//        public void Test_02_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(
//                    _student is Lab9.White.White,
//                    $"Task1 must inherit from White\nTest: {i}"
//                );

//                Assert.AreEqual(
//                    _input[i],
//                    _student.Input,
//                    $"Input mismatch after inheritance\nTest: {i}\nText:\n{_input[i]}"
//                );
//            }
//        }

//        [TestMethod]
//        public void Test_03_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                Assert.AreEqual(
//                    _output[i],
//                    _student.Output,
//                    $"Wrong result\nTest: {i}\nText:\n{_input[i]}\nExpected: {_output[i]}\nActual: {_student.Output}"
//                );
//            }
//        }

//        [TestMethod]
//        public void Test_04_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                var expectedLength = _student.Output.ToString().Length;
//                var actualLength = _student.ToString().Length;

//                Assert.AreEqual(
//                    expectedLength,
//                    actualLength,
//                    $"Wrong ToString length\nTest: {i}\nText:\n{_input[i]}\nExpected length: {expectedLength}\nActual length: {actualLength}"
//                );
//            }
//        }

//        [TestMethod]
//        public void Test_05_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                var expected = _student.Output.ToString();
//                var actual = _student.ToString();

//                Assert.AreEqual(
//                    expected,
//                    actual,
//                    $"Wrong ToString result\nTest: {i}\nText:\n{_input[i]}\nExpected: {expected}\nActual: {actual}"
//                );
//            }
//        }
//        [TestMethod]
//        public void Test_06_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();
//                var originalOutput = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input,
//                    $"ChangeText failed to update Input\nTest: {i}\nExpected:\n{newText}\nActual:\n{_student.Input}");

//                Assert.AreNotEqual(originalOutput, _student.Output,
//                    $"ChangeText did not update Output\nTest: {i}\nOld Output: {originalOutput}\nNew Output: {_student.Output}");
//            }
//        }

//        [TestMethod]
//        public void Test_07_TypeSafety()
//        {
//            Init(0);
//            _student.Review();
//            Assert.IsInstanceOfType(_student.Output, typeof(double),
//                $"Output must be of type double\nActual type: {_student.Output.GetType()}");
//        }
//        private void Init(int i)
//        {
//            _student = new Lab9.White.Task1(_input[i]);
//        }
//    }
//}