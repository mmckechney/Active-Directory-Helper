using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveDirectoryHelper
{
    [Flags]
    public enum AdsUserFlags
    {
        Script = 1,                  // 0x1
        AccountDisabled = 2,              // 0x2
        HomeDirectoryRequired = 8,           // 0x8 
        AccountLockedOut = 16,             // 0x10
        PasswordNotRequired = 32,           // 0x20
        PasswordCannotChange = 64,           // 0x40
        EncryptedTextPasswordAllowed = 128,      // 0x80
        TempDuplicateAccount = 256,          // 0x100
        NormalAccount = 512,              // 0x200
        InterDomainTrustAccount = 2048,        // 0x800
        WorkstationTrustAccount = 4096,        // 0x1000
        ServerTrustAccount = 8192,           // 0x2000
        PasswordDoesNotExpire = 65536,         // 0x10000
        MnsLogonAccount = 131072,           // 0x20000
        SmartCardRequired = 262144,          // 0x40000
        TrustedForDelegation = 524288,         // 0x80000
        AccountNotDelegated = 1048576,         // 0x100000
        UseDesKeyOnly = 2097152,            // 0x200000
        DontRequirePreauth = 4194304,          // 0x400000
        PasswordExpired = 8388608,           // 0x800000
        TrustedToAuthenticateForDelegation = 16777216, // 0x1000000
        NoAuthDataRequired = 33554432         // 0x2000000
    }
    public class AdsUserFlagsListed
    {
        public static string GetTextList(int flagValue)
        {
            if (flagValue == -1)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            string[] names = Enum.GetNames(typeof(AdsUserFlags));
            for (int j = 0; j < names.Length; j++)
            {
                if (Convert.ToBoolean(flagValue & (int)Enum.Parse(typeof(AdsUserFlags), names[j])))
                    sb.Append(names[j] + ", ");
            }
            if(sb.Length > 2)
                sb.Length = sb.Length - 2;
            return sb.ToString();
        }
    }
}
