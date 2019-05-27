using System;
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
        public static void StartNotifyAboutMessage(Label label)
        {
            Thread ShowNotification = new Thread(() => NotifyAboutMessage(label));
            ShowNotification.Start();
        }
        private static void NotifyAboutMessage(Label label)
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

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[64]);

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, 10000);

            //Hash
            byte[] hash = rfc.GetBytes(256);
            
            return new Encryption
            {
                Salt = salt,
                Hash = hash
            };
        }

        public static bool TestPassword(string testUsername, string testPassword)
        {
            Encryption encryption = GetEncryptionFromDB(DataAccessLayerFacade.GetEncryptionByUsername(testUsername));

            if (encryption == null)
            {
                return false;
            }

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(testPassword, encryption.Salt, 10000);

            byte[] hash = rfc.GetBytes(256);

            for (int i = 0; i < hash.Length; i++)
            {
                if (encryption.Hash[i] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private static Encryption GetEncryptionFromDB(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return new Encryption
            {
                Username = (string)dataTable.Rows[0]["username"],
                Hash = (byte[])dataTable.Rows[0]["hash"],
                Salt = (byte[])dataTable.Rows[0]["salt"]
            };
        }
    }
}
