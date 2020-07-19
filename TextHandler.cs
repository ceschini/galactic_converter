using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace desafio_dell {
        public class TextHandler {
        List<Mineral> minerals = new List<Mineral>();
        List<Notation> notations = new List<Notation>();

        public void NotationsReader(string path) { 
            try
            {                    
                var text = File.ReadAllLines(path);
                string[] separators = {"representa"};

                for (int i = 0; i < text.Length; i++) {
                    if (text[i].Contains("representa")) {
                        string[] notationLine = text[i].Split(separators, StringSplitOptions.None);
                        for (int j = 0; j < notationLine.Length; j++) {
                            int k = j + 1;
                            if (k < notationLine.Length) {
                                notations.Add(new Notation(notationLine[j], notationLine[k]));
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void MineralsReader(string path) {

            try {
                var text = File.ReadAllLines(path);

                foreach (var line in text) {
                    if (line.Contains("valem")) {
                        
                        Mineral m = new Mineral();
                        var words = line.Split(' ');
                        string creditString = string.Empty;
                        string amount = string.Empty;
                        RomanConverter r = new RomanConverter();
                        
                        foreach(var word in words) {
                            for (int i = 0; i < notations.Count; i++) {
                                if (notations[i].Galactic.Contains(word)) {
                                    amount += notations[i].Roman;
                                }
                            }
                            amount = Regex.Replace(amount, @"\s+", "");
                            m.Amount = r.ConvertToArabic(amount);
                            if (char.IsUpper(word[0]))
                            {
                                m.Name = word;
                            }
                            for (int i = 0; i < word.Length; i++) {
                                if (Char.IsDigit(word[i])) {
                                    creditString += word[i];
                                }
                            }
                            if (creditString.Length > 0) {
                                m.Credits = int.Parse(creditString);
                            }
                        }
                        minerals.Add(m);
                    }
                }
            } 
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void QueriesReader(string path) {
            string answer = string.Empty;
            string question = string.Empty;
            RomanConverter r = new RomanConverter();

            try {
                var text = File.ReadAllLines(path);                
                foreach (var line in text) {
                    if (line.Contains("quanto vale")) {
                        answer = string.Empty;
                        question = string.Empty;
                        
                        var words = line.Split(' ');

                        foreach (var word in words) {

                            if (word[word.Length - 1] == '?') {
                                string newWord = word.Trim('?');
                                for (int i = 0; i < notations.Count; i++) {
                                    if (notations[i].Galactic.Contains(newWord))
                                    {
                                    question += newWord + " ";
                                    answer += notations[i].Roman;
                                    }
                                }
                            } else {
                                for (int i = 0; i < notations.Count; i++) {
                                    if (notations[i].Galactic.Contains(word))
                                    {
                                        question += word + " ";
                                        answer += notations[i].Roman;
                                    }
                                }
                            }
                        }
                        answer = Regex.Replace(answer, @"\s+", "");
                        if (answer == string.Empty) {
                            System.Console.WriteLine("Nem ideia do que isto significa!");
                        } else {
                            int ans = r.ConvertToArabic(answer);
                            System.Console.WriteLine(question + "vale " + ans);
                        }

                    } else if (line.Contains("quantos créditos")) {
                        string qtdString = string.Empty;
                        string mineral = string.Empty;
                        string newWord = string.Empty;
                        question = string.Empty;

                        var words = line.Split(' ');

                        foreach(var word in words) {
                            newWord = word;
                            if (newWord[word.Length - 1] == '?') {
                                newWord = word.Trim('?');
                            }
                            for (int i = 0; i < notations.Count; i++)
                            {
                                if (notations[i].Galactic.Contains(newWord))
                                {
                                    question += newWord + " ";
                                    qtdString += notations[i].Roman;
                                }
                            }
                            foreach (var m in minerals)
                            {
                                if(m.Name.Equals(newWord)) {
                                    mineral = newWord;
                                }
                            }
                        }
                        qtdString = Regex.Replace(qtdString, @"\s+", "");
                        int qtd = r.ConvertToArabic(qtdString);
                        int mineralAmount = 0;
                        int mineralCredit = 0;
                        CreditComputer cc = new CreditComputer();
                        Regex.Replace(mineral, @"\s+", "");
                        if (mineral == string.Empty) {
                            System.Console.WriteLine("Nem ideia do que isto significa!");
                        } else {
                            foreach (var m in minerals)
                            {
                                if (m.Name.Equals(mineral))
                                {
                                    mineralAmount = m.Amount;
                                    mineralCredit = m.Credits;
                                }
                            }
                            int credits = cc.CalculateCredits(qtd, mineralAmount, mineralCredit);
                            System.Console.WriteLine(question + mineral + " custa " + credits + " créditos");
                        }
                    }
                }
                
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}