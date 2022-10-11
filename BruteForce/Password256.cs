using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BruteForce
{
    internal class Hash256BruteForce
    {
        public readonly string password256;
        private char[] alphabet;
        private char[] password;
        private List<Action> actions;

        public bool isMatched { get; private set; } = false;
        public Hash256BruteForce(string password256)
        {
            this.password256 = password256;
            alphabet = Info.GetAlphabet();
            password = new char[5];
            actions = new List<Action>(){
                           () => SelectionPassword(),
                           () => SelectionPasswordFromEndAlphabet(),
                           () => SelectionPassword(true),
                           () => SelectionPasswordFromEndAlphabet(false)
                       };
        }

        public void Start()
        {
            while(!isMatched)
            {
                if (Info.ThreadsCount > 0 && actions.Count > 0)
                {
                    lock(actions)
                    {
                        Info.ThreadsCount--;
                        Thread thread = new Thread(actions[0].Invoke);
                        actions.RemoveAt(0);
                        thread.Start();
                    }
                }
            }

            if(Info.InitialThreadsCount>4)
            {
                Info.ThreadsCount++;
            }
        }

        public void SelectionPassword(bool fromEnd = false)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    for (int k = 0; k < alphabet.Length; k++)
                    {
                        for (int l = 0; l < alphabet.Length; l++)
                        {
                            for (int z = 0; z < alphabet.Length; z++)
                            {
                                if (isMatched)
                                {
                                    Info.ThreadsCount++;
                                    return;
                                }
                                if(fromEnd)
                                { 
                                    password[0] = alphabet[i];
                                    password[1] = alphabet[j];
                                    password[2] = alphabet[k];
                                    password[3] = alphabet[l];
                                    password[4] = alphabet[z];
                                }
                                else
                                {
                                    password[0] = alphabet[z];
                                    password[1] = alphabet[l];
                                    password[2] = alphabet[k];
                                    password[3] = alphabet[j];
                                    password[4] = alphabet[i];
                                }

                                string result = string.Concat(password);
                                byte[] bytes = Encoding.ASCII.GetBytes(result);
                                byte[] hashBytes;

                                using (SHA256 sha256 = SHA256.Create())
                                {
                                    hashBytes = sha256.ComputeHash(bytes);
                                }

                                StringBuilder sb = new StringBuilder();
                                foreach (var byt in hashBytes)
                                {
                                    sb.Append(byt.ToString("x2"));
                                }
                                string hashString = sb.ToString();

                                if (password256 == hashString)
                                {
                                    Console.WriteLine("Пароль: " + result + "   SHA256: " + password256);
                                    isMatched = true;
                                    Info.ThreadsCount++;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            Info.ThreadsCount++;
        }

        public void SelectionPasswordFromEndAlphabet(bool fromEnd = false)
        {
            for (int i = 25; i > -1; i--)
            {
                for (int j = 25; j > -1; j--)
                {
                    for (int k = 25; k > -1; k--)
                    {
                        for (int l = 25; l > -1; l--)
                        {
                            for (int z = 25; z > -1; z--)
                            {
                                if (isMatched)
                                {
                                    Info.ThreadsCount++;
                                    return;
                                }
                                if (fromEnd)
                                {
                                    password[0] = alphabet[i];
                                    password[1] = alphabet[j];
                                    password[2] = alphabet[k];
                                    password[3] = alphabet[l];
                                    password[4] = alphabet[z];
                                }
                                else
                                {
                                    password[0] = alphabet[z];
                                    password[1] = alphabet[l];
                                    password[2] = alphabet[k];
                                    password[3] = alphabet[j];
                                    password[4] = alphabet[i];
                                }

                                string result = string.Concat(password);
                                byte[] bytes = Encoding.ASCII.GetBytes(result);
                                byte[] hashBytes;

                                using (SHA256 sha256 = SHA256.Create())
                                {
                                    hashBytes = sha256.ComputeHash(bytes);
                                }

                                StringBuilder sb = new StringBuilder();
                                foreach (var byt in hashBytes)
                                {
                                    sb.Append(byt.ToString("x2"));
                                }
                                string hashString = sb.ToString();

                                if (password256 == hashString)
                                {
                                    Console.WriteLine("Пароль: " + result + "   SHA256: " + password256);
                                    isMatched = true;
                                    Info.ThreadsCount++;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            Info.ThreadsCount++;
        }
    }
}
