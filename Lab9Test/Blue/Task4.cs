
using System;
using System.IO;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lab9Test.Blue
{
    [TestClass]
    public sealed class Task4
    {
        private Lab9.Blue.Task4 _student;

        private string[] _input;
        private int[] _output;

        [TestInitialize]
        public void LoadData()
        {
            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var file = Path.Combine(folder, "Lab9Test", "Blue", "data.json");

            var json = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(file));

            _input = json.GetProperty("Blue4")
                         .GetProperty("input")
                         .Deserialize<string[]>();

            _output = json.GetProperty("Blue4")
                          .GetProperty("output")
                          .Deserialize<int[]>();
        }

        [TestMethod]
        public void Test_00_OOP()
        {
            var type = typeof(Lab9.Blue.Task4);

            Assert.IsTrue(type.IsClass, "Task4 must be a class");
            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Blue.Blue)),
                "Task4 must inherit from Blue");

            Assert.IsNotNull(
                type.GetConstructor(new[] { typeof(string) }),
                "Task4 must have constructor Task4(string input)"
            );

            Assert.IsNotNull(type.GetMethod("Review"),
                "Method Review() not found");

            Assert.IsNotNull(type.GetMethod("ToString"),
                "Method ToString() not found");
        }

        [TestMethod]
        public void Test_01_Input()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                Init(i);

                Assert.AreEqual(_input[i], _student.Input,
                    $"Input stored incorrectly\nTest: {i}");
            }
        }

        [TestMethod]
        public void Test_02_Output()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                Init(i);
                _student.Review();

                Assert.AreEqual(_output[i], _student.Output,
                    $"Output mismatch\nTest: {i}");
            }
        }

        [TestMethod]
        public void Test_03_ToString()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                Init(i);
                _student.Review();

                string expected = _output[i].ToString();
                string actual = _student.ToString();

                Assert.AreEqual(expected, actual,
                    $"ToString output mismatch\nTest: {i}");
            }
        }

        [TestMethod]
        public void Test_04_ChangeText()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                Init(i);
                _student.Review();

                var originalOutput = 666;

                var newText = "Проверим 600 + 60 + 6";
                _student.ChangeText(newText);

                Assert.AreEqual(newText, _student.Input,
                    $"ChangeText failed\nTest: {i}");

                Assert.AreEqual(originalOutput, _student.Output,
                    $"Output not updated after ChangeText\nTest: {i}");
            }
        }

        [TestMethod]
        public void Test_05_TypeSafety()
        {
            Init(0);
            _student.Review();

            Assert.IsInstanceOfType(_student.Output, typeof(int),
                $"Output must be int\nActual: {_student.Output.GetType()}");
        }

        [TestMethod]
        public void Test_06_Inheritance()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                Init(i);

                Assert.IsTrue(_student is Lab9.Blue.Blue,
                    $"Task4 must inherit from Blue\nTest: {i}");

                Assert.AreEqual(_input[i], _student.Input,
                    $"Input mismatch\nTest: {i}");
            }
        }

        private void Init(int i)
        {
            _student = new Lab9.Blue.Task4(_input[i]);
        }
    }
}