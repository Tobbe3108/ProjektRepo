﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
using System.IO;
using GlobalClasses;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    class LoginMethods
    {
        public static void StartNotifyAboutFailedLogin(Label label)
        {
            Thread ShowNotification = new Thread(() => NotifyAboutFailedLogin(label));
            ShowNotification.Start();
        }
        private static void NotifyAboutFailedLogin(Label label)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate { label.Show(); });
            }
            else
            {
                label.Show();
                
            }
            Thread.Sleep(2500);
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate { label.Hide(); });
            }
            else
            {
                label.Hide();

            }
            
        }

        public static Encryption Encrypt(string password)
        {
            //Salt
            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            //Hash
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);


            return new Encryption
            {
                Salt = salt,
                Hash = hash,
                EncryptedPassword = Convert.ToBase64String(hashBytes)
            };
        }

        public static bool TestPassword(string testUsername, string testPassword)
        {
            Encryption encryption = GetEncryptionFromDB(DataAccessLayerFacade.GetEncryptionByUsername(testUsername));

            var pbkdf2 = new Rfc2898DeriveBytes(testPassword, encryption.Salt, 10000);
            
            byte[] hashBytes = new byte[36];

            Array.Copy(encryption.Salt, 0, hashBytes, 0, 16);
            Array.Copy(encryption.Hash, 0, hashBytes, 16, 20);

            string encryptedTestPassword = Convert.ToBase64String(hashBytes);

            for (int i = 16; i < encryptedTestPassword.Length; i++)
            {
                if (encryption.EncryptedPassword[i] != encryptedTestPassword[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static Encryption GetEncryptionFromDB(DataTable dataTable)
        {
            return new Encryption
            {
                Hash = (byte[])dataTable.Rows[0]["hash"],
                Salt = (byte[])dataTable.Rows[0]["salt"],
                EncryptedPassword = (string)dataTable.Rows[0]["password"]
            };
        }
    }
}