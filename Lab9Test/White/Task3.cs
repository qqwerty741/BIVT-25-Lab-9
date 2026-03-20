//using System.Text.Json;

//namespace Lab9Test.White
//{
//    [TestClass]
//    public sealed class Task3
//    {
//        private Lab9.White.Task3 _student;

//        private string[] _input;
//        private string[] _output;
//        private string[,] _codes;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "White", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(file));

//            _input = json.GetProperty("Task3").GetProperty("input").Deserialize<string[]>();
//            _output = json.GetProperty("Task3").GetProperty("output").Deserialize<string[]>();

//            var codesArray = json.GetProperty("Task3").GetProperty("codes").Deserialize<string[][]>();
//            _codes = new string[codesArray.Length, 2];
//            for (int i = 0; i < codesArray.Length; i++)
//            {
//                _codes[i, 0] = codesArray[i][0];
//                _codes[i, 1] = codesArray[i][1];
//            }
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.White.Task3);

//            Assert.IsTrue(type.IsClass);
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.White.White)));
//            Assert.IsNotNull(type.GetConstructor(new[] { typeof(string), typeof(string[,]) }));

//            var baseType = typeof(Lab9.White.White);
//            Assert.IsNotNull(baseType.GetProperty("Input"));
//        }

//        [TestMethod]
//        public void Test_01_InputAndChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.AreEqual(_input[i], _student.Input);

//                string newText = _input[i] + " extra";
//                ((Lab9.White.White)_student).ChangeText(newText);
//                Assert.AreEqual(newText, _student.Input);
//            }
//        }

//        [TestMethod]
//        public void Test_02_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                Lab9.White.White w = (Lab9.White.White)_student;
//                Assert.AreEqual(_student.Input, w.Input);
//            }
//        }

//        [TestMethod]
//        public void Test_03_Output()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();
//                Assert.AreEqual(_output[i], _student.Output,
//                    $"ChangeText did not update Output\nTest: {i}\nTest Output: {_output[i]}\nUser Output: {_student.Output}");

//            }
//        }

//        [TestMethod]
//        public void Test_04_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();
//                Assert.AreEqual(_output[i].Length, _student.ToString().Length);
//            }
//        }

//        [TestMethod]
//        public void Test_05_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();
//                Assert.AreEqual(_output[i], _student.ToString());
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
//            Assert.IsInstanceOfType(_student.Output, typeof(string),
//                $"Output must be of type double\nActual type: {_student.Output.GetType()}");
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.White.Task3(_input[i], _codes);
//        }
//    }
//}