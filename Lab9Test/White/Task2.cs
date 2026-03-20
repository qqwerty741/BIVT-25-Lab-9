//using System.Text.Json;

//namespace Lab9Test.White
//{
//    [TestClass]
//    public sealed class Task2
//    {
//        private Lab9.White.Task2 _student;

//        private string[] _input;
//        private string[][] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

//            var file = Path.Combine(folder, "Lab9Test", "White", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Task2")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Task2")
//                          .GetProperty("output")
//                          .Deserialize<string[][]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.White.Task2);

//            Assert.IsTrue(type.IsClass);
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.White.White)));

//            Assert.IsNotNull(
//                type.GetConstructor(new[] { typeof(string) })
//            );

//            Assert.IsNotNull(type.GetMethod("Review"));
//            Assert.IsNotNull(type.GetMethod("ToString"));
//        }

//        [TestMethod]
//        public void Test_01_Input()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.AreEqual(_input[i], _student.Input);
//            }
//        }

//        [TestMethod]
//        public void Test_02_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(_student is Lab9.White.White);
//                Assert.AreEqual(_input[i], _student.Input);
//            }
//        }
//        [TestMethod]
//        public void Test_03_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var student = _student.Output;

//                Assert.AreEqual(
//                    _output[i].Length,
//                    student.GetLength(0),
//                    $"Wrong number of rows\nTest: {i}\nText:\n{_input[i]}"
//                );

//                for (int j = 0; j < _output[i].Length; j++)
//                {
//                    var parts = _output[i][j].Split(':');
//                    int expectedLeft = int.Parse(parts[0]);
//                    int expectedRight = int.Parse(parts[1]);

//                    int actualLeft = student[j, 0];
//                    int actualRight = student[j, 1];

//                    Assert.AreEqual(
//                        expectedLeft,
//                        actualLeft,
//                        $"Mismatch in row {j}, column 0\nTest: {i}\nText:\n{_input[i]}\nExpected: {expectedLeft}\nActual: {actualLeft}"
//                    );

//                    Assert.AreEqual(
//                        expectedRight,
//                        actualRight,
//                        $"Mismatch in row {j}, column 1\nTest: {i}\nText:\n{_input[i]}\nExpected: {expectedRight}\nActual: {actualRight}"
//                    );
//                }
//            }
//        }

//        [TestMethod]
//        public void Test_04_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                var expected = string.Join(Environment.NewLine, _output[i]);

//                Assert.AreEqual(
//                    expected.Length,
//                    _student.ToString().Length
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

//                var expected = string.Join(Environment.NewLine, _output[i]);

//                Assert.AreEqual(
//                    expected,
//                    _student.ToString(),
//                    $"Wrong ToString\nTest: {i}\nText:\n{_input[i]}"
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
//            Assert.IsInstanceOfType(_student.Output, typeof(int[,]),
//                $"Output must be of type double\nActual type: {_student.Output.GetType()}");
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.White.Task2(_input[i]);
//        }
//    }
//}