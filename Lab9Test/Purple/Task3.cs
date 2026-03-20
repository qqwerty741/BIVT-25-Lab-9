//using System.Text.Json;
//using System.Linq;

//namespace Lab9Test.Purple
//{
//    [TestClass]
//    public sealed class Task3
//    {
//        private Lab9.Purple.Task3 _student;

//        private string[] _input;
//        private string[] _output;

//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Purple", "data.json");

//            var json = JsonSerializer.Deserialize<JsonElement>(
//                File.ReadAllText(file));

//            _input = json.GetProperty("Purple3")
//                         .GetProperty("input")
//                         .Deserialize<string[]>();

//            _output = json.GetProperty("Purple3")
//                          .GetProperty("output")
//                          .Deserialize<string[]>();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Purple.Task3);

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

//                Assert.AreEqual(_output[i], _student.Output,
//                    $"Output mismatch\nTest: {i}");
//            }
//        }

//        [TestMethod]
//        public void Test_02_ToString()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                Assert.AreEqual(_output[i], _student.ToString(),
//                    $"ToString mismatch\nTest: {i}");
//            }
//        }

//        //[TestMethod]
//        //public void Test_03_Codes()
//        //{
//        //    for (int i = 0; i < _input.Length; i++)
//        //    {
//        //        Init(i);
//        //        _student.Review();

//        //        var actual = _student.Codes;
//        //        var expected = _codes[i];

//        //        Assert.AreEqual(expected.Length, actual.Length,
//        //            $"Codes length mismatch\nTest: {i}");

//        //        for (int j = 0; j < expected.Length; j++)
//        //        {
//        //            Assert.AreEqual(expected[j].Item1, actual[j].Item1,
//        //                $"Pair mismatch\nTest: {i}, Index: {j}");

//        //            Assert.AreEqual(expected[j].Item2, actual[j].Item2,
//        //                $"Code mismatch\nTest: {i}, Index: {j}");
//        //        }
//        //    }
//        //}

//        [TestMethod]
//        public void Test_04_CodesLimit()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsTrue(_student.Codes.Length <= 5);
//        }

//        [TestMethod]
//        public void Test_05_NoOriginalPairsInOutput()
//        {
//            Init(0);
//            _student.Review();

//            var output = _student.Output;

//            foreach (var pair in _student.Codes)
//            {
//                Assert.IsFalse(output.Contains(pair.Item1),
//                    $"Pair not replaced: {pair.Item1}");
//            }
//        }

//        [TestMethod]
//        public void Test_06_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                foreach (var pair in _student.Codes)
//                    Console.WriteLine($"{pair.Item1}:{pair.Item2}");
//                Console.WriteLine();

//                var oldOutput = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                _student.ChangeText(newText);

//                Assert.AreEqual(newText, _student.Input);
//                Assert.AreNotEqual(oldOutput, _student.Output);
//            }
//        }

//        [TestMethod]
//        public void Test_07_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof(string));
//            Assert.IsInstanceOfType(_student.Codes, typeof((string, char)[]));
//        }

//        [TestMethod]
//        public void Test_08_CodeSymbolsNotInOriginal()
//        {
//            Init(0);
//            _student.Review();

//            var input = _student.Input;

//            foreach (var code in _student.Codes)
//            {
//                Assert.IsFalse(input.Contains(code.Item2),
//                    $"Code symbol already exists in input: {code.Item2}");
//            }
//        }

//        private void Init(int i)
//        {
//            _student = new Lab9.Purple.Task3(_input[i]);
//        }
//    }
//}