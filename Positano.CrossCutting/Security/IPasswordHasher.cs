namespace Positano.CrossCutting.Security
{
    public interface IPasswordHasher
    {
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string EncryptString(string plainText);
        string DecryptString(string cipherText);
    }
}
