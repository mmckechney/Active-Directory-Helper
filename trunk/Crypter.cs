using System;
using System.Security.Cryptography;
namespace ActiveDirectoryHelper.Encryption
{

	public class Crypter
	{

        private static string encrypKey = "BBD9A16B0A7D444BAA5EA1B937C3F1951617BE0B68EC4DECA86F7255E0F08C72";
        private static System.Security.Cryptography.SymmetricAlgorithm encryptionProvider = new System.Security.Cryptography.RijndaelManaged();
           //(System.Security.Cryptography.SymmetricAlgorithm)System.Security.Cryptography.CryptoConfig.CreateFromName("System.Security.Cryptography");
		
		public static string Encrypt(string plainText)
		{

			//Get the plain text in a byte array
			System.Byte[] ByteText = Crypter.StringToByteArray(plainText); 

			System.IO.MemoryStream EncStream = new System.IO.MemoryStream();

			//Get the binary format of the hash key
			System.Byte[] HashKey = Crypter.FormatKey(Crypter.encrypKey);
			System.Byte[] IVector = Crypter.FormatInitializationVector(); 

			Crypter.encryptionProvider.Key = HashKey; 
			Crypter.encryptionProvider.IV  = IVector; 

			//Create the Actual Encrypter
			System.Security.Cryptography.ICryptoTransform Encrypter = Crypter.encryptionProvider.CreateEncryptor(); 

			//Create a Stream for the transform 
			System.Security.Cryptography.CryptoStream Stream = new System.Security.Cryptography.CryptoStream(EncStream,Encrypter,System.Security.Cryptography.CryptoStreamMode.Write); 
			
			try
			{
				//Write the encrypted stream to the 
				Stream.Write(ByteText,0,ByteText.Length); 
				Stream.FlushFinalBlock(); 
				
				System.Byte[] Output = EncStream.GetBuffer(); 
			
				string Encrypted = System.Convert.ToBase64String(Output,0,(int)EncStream.Length); 
				
				return Encrypted;
			}
			finally
			{
				EncStream.Close(); 
				Stream.Close(); 
			}
			
		}

		public static string Decrypt(string cipherText)
		{

			//Get the plain text in a byte array
			System.Byte[] ByteText = System.Convert.FromBase64String(cipherText); 

			System.IO.MemoryStream EncStream = new System.IO.MemoryStream(ByteText,0,ByteText.Length);

			//Get the binary format of the hash key
			System.Byte[] HashKey = Crypter.FormatKey(Crypter.encrypKey);
			System.Byte[] IVector = Crypter.FormatInitializationVector(); 

			Crypter.encryptionProvider.Key = HashKey; 
			Crypter.encryptionProvider.IV  = IVector; 

			System.Security.Cryptography.ICryptoTransform Encrypter = Crypter.encryptionProvider.CreateDecryptor(); 

			//Create a Stream for the transform 
			System.Security.Cryptography.CryptoStream Stream = new System.Security.Cryptography.CryptoStream(EncStream,Encrypter,System.Security.Cryptography.CryptoStreamMode.Read); 

			System.IO.StreamReader PlainText = null;

			try
			{
				PlainText = new System.IO.StreamReader(Stream);
			
				return PlainText.ReadToEnd();
			}
			finally
			{
				PlainText.Close(); 
				Stream.Close(); 
			}

		}

        #region :: Private Utility Methods ::
        private static System.Byte[] FormatInitializationVector()
        {
            // The initial string of IV may be modified with any data you like
            string Temp = "TecV";
            //Generate a vector
            Crypter.encryptionProvider.GenerateIV();
            //Get a default vector for the size
            System.Byte[] TempVector = Crypter.encryptionProvider.IV;

            int IVLength = TempVector.Length;

            if (Temp.Length > IVLength)
                Temp = Temp.Substring(0, IVLength);
            else if (Temp.Length < IVLength)
                Temp = Temp.PadRight(IVLength, ' ');

            return System.Text.ASCIIEncoding.ASCII.GetBytes(Temp);
        }

        private static System.Byte[] FormatKey(string key)
        {
            string Temp;

            Temp = key;

            Crypter.encryptionProvider.GenerateKey();

            System.Byte[] TempKey = Crypter.encryptionProvider.Key;

            //Get the Length of the Generated Key
            int KeyLength = TempKey.Length;

            //We need to remove characters if the Key passed in is bigger than the Provider can handle
            if (Temp.Length > KeyLength)
                Temp = Temp.Substring(0, KeyLength);
            else if (Temp.Length <= KeyLength)
                Temp = Temp.PadRight(KeyLength);

            //convert the secret key to byte array
            return System.Text.ASCIIEncoding.ASCII.GetBytes(Temp);

        }


        private static System.Byte[] StringToByteArray(string input)
        {
            return System.Text.ASCIIEncoding.ASCII.GetBytes(input);
        }

        #endregion 
 
	}
}
