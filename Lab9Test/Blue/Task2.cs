
//using System;
//using System.IO;
//using System.Text.Json;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Lab9Test.Blue
//{
//    [TestClass]
//    public sealed class Task2
//    {
//        private Lab9.Blue.Task2 _student;

//        private string[] _inputText;
//        private string[] _inputSequence;
//        private string[] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Blue", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _inputText = json.GetProperty("Blue2")
//                             .GetProperty("inputText")
//                             .Deserialize<string[]>();

//            _inputSequence = json.GetProperty("Blue2")
//                                 .GetProperty("inputSequence")
//                                 .Deserialize<string[]>();

//            _output = json.GetProperty("Blue2")
//                          .GetProperty("output")
//                          .Deserialize<string[]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Blue.Task2);

//            Assert.IsTrue(type.IsClass, "Task2 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Blue.Blue)),
//                "Task2 must inherit from Blue");

//            Assert.IsNotNull(
//                type.GetConstructor(new[] { typeof(string), typeof(string) }),
//                "Task2 must have constructor Task2(string inputText, string sequence)"
//            );

//            Assert.IsNotNull(type.GetMethod("Review"),
//                "Method Review() not found");

//            Assert.IsNotNull(type.GetMethod("ToString"),
//                "Method ToString() not found");
//        }

//        [TestMethod]
//        public void Test_01_Input()
//        {
//            for (int i = 0; i < _inputText.Length; i++)
//            {
//                Init(i);

//                Assert.AreEqual(_inputText[i], _student.Input,
//                    $"Input stored incorrectly\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_02_Output()
//        {
//            for (int i = 0; i < _inputText.Length; i++)
//            {
//                Init(i);

//                _student.Review();

//                var expected = _output[i];
//                var actual = _student.Output;

//                Assert.AreEqual(expected, actual,
//                    $"Output mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_03_ToString()
//        {
//            for (int i = 0; i < _inputText.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var expected = _output[i];
//                var actual = _student.ToString();

//                Assert.AreEqual(expected, actual,
//                    $"ToString output mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_04_ChangeText()
//        {
//            for (int i = 0; i < _inputText.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var originalOutput = _student.Output;

//                var newText = _inputText[(i + 1) % _inputText.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input,
//                    $"ChangeText failed\nTest: {i}");

//                Assert.AreNotEqual(originalOutput, _student.Output,
//                    $"Output not updated after ChangeText\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_05_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof(string),
//                $"Output must be string\nActual: {_student.Output.GetType()}");
//        }

//        [TestMethod]
//        public void Test_06_Inheritance()
//        {
//            for (int i = 0; i < _inputText.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(_student is Lab9.Blue.Blue,
//                    $"Task2 must inherit from Blue\nTest: {i}");

//                Assert.AreEqual(_inputText[i], _student.Input,
//                    $"Input mismatch\nTest: {i}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Blue.Task2(_inputText[i], _inputSequence[i]);
//        }
//    }
//}