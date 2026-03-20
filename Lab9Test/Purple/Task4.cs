//using System.Text.Json;
//using System.Linq;

//namespace Lab9Test.Purple
//{
//    [TestClass]
//    public sealed class Task4
//    {
//        private Lab9.Purple.Task4 _student;

//        private string[] _input;
//        private (string, char)[][] _codes;
//        private string[] _output;
//        [TestInitialize]
//        public void LoadData()
//        {
//            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
//            var file = Path.Combine(folder, "Lab9Test", "Purple", "data.json");
//            var jsonText = File.ReadAllText(file);
//            var json = JsonSerializer.Deserialize<JsonElement>(jsonText);

//            var purple4 = json.GetProperty("Purple4");

//            _input = purple4.GetProperty("input").Deserialize<string[]>();
//            _output = purple4.GetProperty("output").Deserialize<string[]>();

//            // Десериализация кодов
//            var codeGroups = purple4.GetProperty("codes").EnumerateArray();
//            var listOfArrays = new List<(string, char)[]>();

//            foreach (var group in codeGroups)
//            {
//                var pairs = new List<(string, char)>();
//                foreach (var entry in group.EnumerateArray())
//                {
//                    string pair = entry.GetProperty("pair").GetString() ?? "";
//                    string codeStr = entry.GetProperty("code").GetString() ?? "";
//                    char code = string.IsNullOrEmpty(codeStr) ? '\0' : codeStr[0];
//                    pairs.Add((pair, code));
//                }
//                listOfArrays.Add(pairs.ToArray());
//            }

//            _codes = listOfArrays.ToArray();
//        }

//        [TestMethod]
//        public void Test_00_OOP()
//        {
//            var type = typeof(Lab9.Purple.Task4);

//            Assert.IsTrue(type.IsClass);
//            Assert.IsTrue(type.IsSubclassOf(typeof(Lab9.Purple.Purple)));

//            Assert.IsNotNull(type.GetConstructor(new[] { typeof(string), typeof((string, char)[]) }));
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

//        [TestMethod]
//        public void Test_03_DecodeAllCodes()
//        {
//            Init(0);
//            _student.Review();

//            var output = _student.Output;

//            foreach (var code in _codes[0])
//            {
//                Assert.IsFalse(output.Contains(code.Item2),
//                    $"Code symbol not decoded: {code.Item2}");

//                Assert.IsTrue(output.Contains(code.Item1),
//                    $"Pair not restored: {code.Item1}");
//            }
//        }

//        [TestMethod]
//        public void Test_04_ChangeText()
//        {
//            for (int i = 0; i < _input.Length; i++)
//            {
//                Init(i);
//                _student.Review();

//                var old = _student.Output;

//                var newText = _input[(i + 1) % _input.Length];
//                var newCodes = _codes[(i + 1) % _codes.Length];

//                _student.ChangeText(newText);
//                _student = new Lab9.Purple.Task4(newText, newCodes);
//                _student.Review();

//                Assert.AreEqual(newText, _student.Input);
//                Assert.AreNotEqual(old, _student.Output);
//            }
//        }

//        [TestMethod]
//        public void Test_05_TypeSafety()
//        {
//            Init(0);
//            _student.Review();

//            Assert.IsInstanceOfType(_student.Output, typeof(string));
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

//        private void Init(int i)
//        {
//            _student = new Lab9.Purple.Task4(_input[i], _codes[i]);
//        }
//    }
//}