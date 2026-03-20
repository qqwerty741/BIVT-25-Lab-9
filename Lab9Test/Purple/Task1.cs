//using System.Text.Json;
//using System.Linq;

//namespace Lab9Test.Purple
//{
//    [TestClass]
//    public sealed class Task1
//    {
//        private Lab9.Purple.Task1 _student;

//        private string[] _input;
//        private string[] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Purple", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Purple1")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Purple1")
//                          .GetProperty("output")
//                          .Deserialize<string[]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Purple.Task1);

//            Assert.IsTrue(type.IsClass, "Task1 must be a class");
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Purple.Purple)),
//                "Task1 must inherit from Purple");

//            Assert.IsNotNull(
//                type.GetConstructor(new[] { typeof(string) }),
//                "Constructor Task1(string input) not found"
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

//                Assert.AreEqual(_output[i], _student.Output,
//                    $"Output mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_03_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                Assert.AreEqual(_output[i], _student.ToString(),
//                    $"ToString mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_04_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var oldOutput = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input,
//                    $"ChangeText failed\nTest: {i}");

//                Assert.AreNotEqual(oldOutput, _student.Output,
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
//        public void Test_06_Length()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                Assert.AreEqual(_output[i].Length, _student.ToString().Length,
//                    $"Length mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_07_PunctuationPreserved()
//        {
//            Init(0);
//            _student.Review();

//            var input = _student.Input;
//            var output = _student.Output;

//            var inputPunct = new string(input.Where(c => !char.IsLetterOrDigit(c) && c != ' ').ToArray());
//            var outputPunct = new string(output.Where(c => !char.IsLetterOrDigit(c) && c != ' ').ToArray());

//            Assert.AreEqual(inputPunct, outputPunct,
//                "Punctuation must stay in the same places");
//        }

//        [TestMethod]
//        public void Test_08_WordsReversed()
//        {
//            Init(0);
//            _student.Review();

//            var wordsIn = _student.Input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            var wordsOut = _student.Output.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//            for (int i = 0; i < Math.Min(wordsIn.Length, wordsOut.Length); i++)
//            {
//                var cleanIn = new string(wordsIn[i].Where(char.IsLetter).ToArray());
//                var cleanOut = new string(wordsOut[i].Where(char.IsLetter).ToArray());

//                var reversed = new string(cleanIn.Reverse().ToArray());

//                Assert.AreEqual(reversed, cleanOut,
//                    $"Word not reversed\nIndex: {i}\nExpected: {reversed}\nActual: {cleanOut}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Purple.Task1(_input[i]);
//        }
//    }
//}