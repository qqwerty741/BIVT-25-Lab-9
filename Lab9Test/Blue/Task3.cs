
//using System;
//using System.IO;
//using System.Text.Json;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using System.Globalization;

//namespace Lab9Test.Blue
//{
//    [TestClass]
//    public sealed class Task3
//    {
//        private Lab9.Blue.Task3 _student;

//        private string[] _input;
//        private string[][] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Blue", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Blue3")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Blue3")
//                          .GetProperty("output")
//                          .Deserialize<string[][]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Blue.Task3);

//            Assert.IsTrue(type.IsClass, "Task3 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Blue.Blue)),
//                "Task3 must inherit from Blue");

//            Assert.IsNotNull(
//                type.GetConstructor(new[] { typeof(string) }),
//                "Task3 must have constructor Task3(string input)"
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

//                var expectedLines = _output[i];
//                var actualTuples = _student.Output;

//                Assert.AreEqual(expectedLines.Length, actualTuples.Length,
//                    $"Output length mismatch\nTest: {i}\n{string.Join(" ", expectedLines)}\n{string.Join(" ", actualTuples.Select(t => t.Item1))}");

//                for (int j = 0; j < expectedLines.Length; j++)
//                {
//                    var expected = expectedLines[j].Split(':');

//                    Assert.AreEqual(expected[0][0], actualTuples[j].Item1,
//                        $"Line mismatch\nTest: {i}, Index: {j}\nExpected: {expected[0][0]}\nActual: {actualTuples[j].Item1}");


//                    Assert.AreEqual(double.Parse(expected[1], CultureInfo.InvariantCulture), actualTuples[j].Item2, 0.001,
//                        $"Line mismatch\nTest: {i}, Index: {j}\nExpected: {expected[1]}\nActual: {actualTuples[j].Item2}");
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

//                string expected = string.Join(Environment.NewLine, _output[i]);
//                string actual = _student.ToString();

//                Assert.AreEqual(expected, actual.Replace(',', '.'), true, CultureInfo.InvariantCulture,
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
//                    $"Output not updated after ChangeText\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_05_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof((char, double)[]),
//                $"Output must be (char,double)[]\nActual: {_student.Output.GetType()}");
//        }

//        [TestMethod]
//        public void Test_06_Inheritance()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);

//                Assert.IsTrue(_student is Lab9.Blue.Blue,
//                    $"Task3 must inherit from Blue\nTest: {i}");

//                Assert.AreEqual(_input[i], _student.Input,
//                    $"Input mismatch\nTest: {i}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Blue.Task3(_input[i]);
//        }
//    }
//}