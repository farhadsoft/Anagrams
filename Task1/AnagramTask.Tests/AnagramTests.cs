using System;
using AnagramTask;
using NUnit.Framework;

namespace AnagramTask.Tests
{
    public class AnagramTests
    {
        [TestCase("master", new[] {"stream", "pigeon", "maters"}, ExpectedResult = new[] {"stream", "maters"})]
        [TestCase("listen", new[] {"enlists", "google", "inlets", "banana"}, ExpectedResult = new[] {"inlets"})]
        [TestCase("allergy", new[] {"gallery", "ballerina", "regally", "clergy", "largely", "leading"},
            ExpectedResult = new[] {"gallery", "regally", "largely"})]
        public string[] Detects_Anagrams(string word, string[] candidates)
        {
            var sut = new Anagram(word);
            return sut.FindAnagrams(candidates);
        }
        
        [TestCase("diaper", new[] {"hello", "world", "zombies", "pants"}, ExpectedResult = new string[] { })]
        [TestCase("good", new[] {"dog", "goody"}, ExpectedResult = new string[] { })]
        [TestCase("mass", new[] {"last"}, ExpectedResult = new string[] { })]
        public string[] Does_Not_Detect_Non_Anagrams(string word, string[] candidates)
        {
            var sut = new Anagram(word);
            return sut.FindAnagrams(candidates);
        }
        
        [TestCase("Orchestra", new[] {"cashier", "Carthorse", "radishes"}, ExpectedResult = new[] {"Carthorse"})]
        [TestCase("orchestra", new[] {"caregivers", "Carthorse", "radishes"}, ExpectedResult = new[] {"Carthorse"})]
        public string[] Detects_Anagrams_Case_Insensitively(string word, string[] candidates)
        {
            var sut = new Anagram(word);
            return sut.FindAnagrams(candidates);
        }

        [Test]
        public void Does_Not_Detect_A_Anagram_If_The_Original_Word_Is_Repeated()
        {
            var candidates = new[] {"go Go GO"};
            var sut = new Anagram("go");
            Assert.IsEmpty(sut.FindAnagrams(candidates));
        }

        [Test]
        public void Anagrams_Must_Use_All_Letters_Exactly_Once()
        {
            var candidates = new[] {"patter"};
            var sut = new Anagram("tapper");
            Assert.IsEmpty(sut.FindAnagrams(candidates));
        }
        
        [Test]
        public void Words_Are_Not_Anagrams_Of_Themselves_Case_Insensitive_()
        {
            var candidates = new[] {"BANANA", "Banana", "banana"};
            var sut = new Anagram("BANANA");
            Assert.IsEmpty(sut.FindAnagrams(candidates));
        }
        
        [Test]
        public static void Throw_ArgumentException_If_Word_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Anagram(string.Empty), "The word can not be empty.");
        }
        
        [Test]
        public static void Throw_ArgumentNullException_If_Word_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Anagram(null), "The word can not be null.");
        }
        
        [Test]
        public static void Throw_ArgumentException_If_Candidates_Is_Null()
        {
            var sut = new Anagram("banana");
            Assert.Throws<ArgumentNullException>(() => sut.FindAnagrams(null), "The list of words can not be null.");
        }
    }
}