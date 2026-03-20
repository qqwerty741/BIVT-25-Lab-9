//using System;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Lab9Test.White
//{
//    [TestClass]
//    public sealed class Task4
//    {
//        private Lab9.White.Task4 _student;

//        private string[] _input;
//        private int[] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "White", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(file));

//            _input = json.GetProperty("Task4").GetProperty("input").Deserialize<string[]>();
//            _output = json.GetProperty("Task4").GetProperty("output").Deserialize<int[]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.White.Task4);
//            Assert.IsTrue(type.IsClass);
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.White.White)));
//            Assert.IsNotNull(type.GetConstructor(new[] { typeof(string) }));

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
//                Assert.AreEqual(_output[i], _student.Output);
//            }
//        }

//        [TestMethod]
//        public void Test_04_ToStringLength()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();
//                Assert.AreEqual(_student.Output.ToString().Length, _student.ToString().Length);
//            }
//        }

//        [TestMethod]
//        public void Test_05_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();
//                Assert.AreEqual(_student.Output.ToString(), _student.ToString());
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

//                Assert.AreEqual(_output[(i + 1) % _input.Length], _student.Output,
//                    $"ChangeText did not update Output\nTest: {i}\nOld Output: {originalOutput}\nNew Output: {_student.Output}");
//            }
//        }

//        [TestMethod]
//        public void Test_07_TypeSafety()
//        {
//            Init(0);
//            _student.Review();
//            Assert.IsInstanceOfType(_student.Output, typeof(int),
//                $"Output must be of type double\nActual type: {_student.Output.GetType()}");
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.White.Task4(_input[i]);
//        }
//    }
//}