using System;
using System.Collections.Generic;

namespace desafio_dell {
    public class RomanConverter {
        Dictionary<char,int> romans = new Dictionary<char,int>() {
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000}
        };
        // valores repetiram x vezes
        bool repeat1 = false;
        bool repeat2 = false;
        bool repeat3 = false;
        bool err = false;
        private void CheckRepeat(int curr, int next) {
            // testes para evitar repetições incorretas
            if (curr == next) {
                if (curr == 500 || curr == 50 || curr == 5) {
                    err = true;
                }
            }
            
            if (curr == next && repeat3)
            {
                err = true;
            }
            else if (curr == next && repeat2)
            {
                repeat3 = true;
            }
            else if (curr == next && repeat1)
            {
                repeat2 = true;
            }
            else if (curr == next)
            {
                repeat1 = true;
            }
        }

        private void ResetRepeat() {
            repeat1 = false;
            repeat2 = false;
            repeat3 = false;
        }

        private void CheckSubtr(int curr, int next) {
            if (next == 1) {
                if (curr != 5 && curr != 10) {
                    err = true;
                }
            } else if (next == 10) {
                if (curr != 50 && curr != 100) {
                    err = true;
                }
            } else if(next == 100) {
               if (curr != 500 && curr != 1000) {
                   err = true;
               } 
            }
            else if (next == 5 && next == 50 && next == 500) {
                err = true;
            }
        }

        public int ConvertToArabic(string roman) {

        char[] arr = roman.ToCharArray();
        int curr = 0; // recebe valor atual 
        int next = 0; // recebe próximo valor (direita para esquerda)
        int arabic = 0; // recebe soma total
        bool skip = false; // true quando deve pular iteração
        

        for (int i = arr.Length - 1; i > -1; i--) {
            if (skip == true) {
                skip = false;
                continue;
            }

            romans.TryGetValue(arr[i], out curr);
            
            if (i > 0) {
                romans.TryGetValue(arr[i - 1], out next);
            } else {
                next = 0;
            }

            CheckRepeat(curr, next);

            // se atual for maior que o próximo
            // subtraír e pular aquela iteração
            if (curr > next) {
                CheckSubtr(curr, next);
                arabic += (curr - next);
                skip = true;
                ResetRepeat();
            } else {
                if (curr != next) {
                    ResetRepeat();
                }
                arabic += curr;
            }           
        }

        if (err) {
            return -1;
        } 

        return arabic;
        }
    }
}